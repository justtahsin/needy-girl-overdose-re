using System;
using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ControllPanelView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _bgmText;

	[SerializeField]
	private TMP_Text _bgmValueText;

	[SerializeField]
	private Slider _bgmValueSlider;

	[SerializeField]
	private TMP_Text _seText;

	[SerializeField]
	private TMP_Text _seValueText;

	[SerializeField]
	private Slider _seValueSlider;

	[SerializeField]
	private TMP_Text _languageTitle;

	[SerializeField]
	private ToggleGroup _languageToggleGroup;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

	private LanguageType _bufferLanguageType;

	[SerializeField]
	private Toggle _jp;

	[SerializeField]
	private Toggle _en;

	[SerializeField]
	private Toggle _cn;

	[SerializeField]
	private Toggle _ko;

	[SerializeField]
	private Toggle _tw;

	[SerializeField]
	private Toggle _vn;

	[SerializeField]
	private Toggle _fr;

	[SerializeField]
	private Toggle _it;

	[SerializeField]
	private Toggle _ge;

	[SerializeField]
	private Toggle _sp;

	[SerializeField]
	private Toggle _ru;

	[SerializeField]
	private TMP_Text _ResolutionTitle;

	[SerializeField]
	private TMP_Text _maxTitle;

	[SerializeField]
	private TMP_Text _equalTitle;

	[SerializeField]
	private TMP_Text _windowedTitle;

	[SerializeField]
	private Toggle _max;

	[SerializeField]
	private Toggle _equal;

	[SerializeField]
	private Toggle _windowed;

	[SerializeField]
	private TMP_Text _vibrationTitle;

	[SerializeField]
	private Toggle _vibrationOn;

	[SerializeField]
	private Toggle _vibrationOff;

	[SerializeField]
	private GameObject _windowSettingView;

	[SerializeField]
	private GameObject _vibrationSettingView;

	private AudioManager _audioManager;

	private float initialBgmVolume;

	private float initialSeVolume;

	private List<GameObject> _selectableObjects;

	public void Awake()
	{
		_audioManager = AudioManager.Instance;
	}

	public void Start()
	{
		_windowSettingView.SetActive(true);
		_vibrationSettingView.SetActive(false);
		IObservable<float> observable = Observable.Share<float>(UnityUIComponentExtensions.OnValueChangedAsObservable(_bgmValueSlider));
		IObservable<float> observable2 = Observable.Share<float>(UnityUIComponentExtensions.OnValueChangedAsObservable(_seValueSlider));
		initialBgmVolume = SingletonMonoBehaviour<Settings>.Instance.BgmVolume;
		initialSeVolume = SingletonMonoBehaviour<Settings>.Instance.SeVolume;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Select<float, float>(observable, (Func<float, float>)((float v) => v)), (Action<float>)delegate(float v)
		{
			float value = Mathf.Floor(v) * 0.01f;
			_audioManager.ChangeVolume(SoundCategory.BGM, value);
			_audioManager.ChangeVolume(SoundCategory.BANK, value);
			_bgmValueText.text = Mathf.FloorToInt(v).ToString();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Select<float, float>(observable2, (Func<float, float>)((float v) => v * 0.01f)), (Action<float>)delegate(float v)
		{
			_audioManager.ChangeSeVolume(v);
			_seValueText.text = Mathf.FloorToInt(v * 100f).ToString();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Skip<float>(Observable.ThrottleFrame<float>(Observable.Distinct<float>(observable2), 100, (FrameCountType)0), 1), (Action<float>)delegate
		{
			_audioManager.PlaySeByType(SoundType.SE_per);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_dismissButton), (Action<Unit>)delegate
		{
			ResetVolume();
			Close();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_submitButton), (Action<Unit>)delegate
		{
			OnSubmit();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType v)
		{
			switch (v)
			{
			case LanguageType.JP:
				_jp.isOn = true;
				break;
			case LanguageType.EN:
				_en.isOn = true;
				break;
			case LanguageType.CN:
				_cn.isOn = true;
				break;
			case LanguageType.KO:
				_ko.isOn = true;
				break;
			case LanguageType.TW:
				_tw.isOn = true;
				break;
			case LanguageType.VN:
				_vn.isOn = true;
				break;
			case LanguageType.FR:
				_fr.isOn = true;
				break;
			case LanguageType.IT:
				_it.isOn = true;
				break;
			case LanguageType.GE:
				_ge.isOn = true;
				break;
			case LanguageType.SP:
				_sp.isOn = true;
				break;
			case LanguageType.RU:
				_ru.isOn = true;
				break;
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<ResolutionType>((IObservable<ResolutionType>)SingletonMonoBehaviour<Settings>.Instance.Resolution, (Action<ResolutionType>)delegate(ResolutionType v)
		{
			switch (v)
			{
			case ResolutionType.FullScreen:
				_max.isOn = true;
				break;
			case ResolutionType.Toubai:
				_equal.isOn = true;
				break;
			case ResolutionType.Window:
				_windowed.isOn = true;
				break;
			}
		}), ((Component)this).gameObject);
		_bgmValueSlider.value = SingletonMonoBehaviour<Settings>.Instance.BgmVolume * 100f;
		_seValueSlider.value = SingletonMonoBehaviour<Settings>.Instance.SeVolume * 100f;
		OnLanguageChanged();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<VibrationType>((IObservable<VibrationType>)SingletonMonoBehaviour<Settings>.Instance.VibrationType, (Action<VibrationType>)delegate(VibrationType v)
		{
			switch (v)
			{
			case VibrationType.On:
				_vibrationOn.isOn = true;
				break;
			case VibrationType.Off:
				_vibrationOff.isOn = true;
				break;
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).GetComponentInParent<IWindow>()._close), (Action<Unit>)delegate
		{
			ResetVolume();
		}), ((Component)this).gameObject);
	}

	private void Close()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.ControlPanel));
	}

	private void ResetVolume()
	{
		SingletonMonoBehaviour<Settings>.Instance.BgmVolume = initialBgmVolume;
		SingletonMonoBehaviour<Settings>.Instance.SeVolume = initialSeVolume;
		_audioManager.ChangeVolume(SoundCategory.BGM, initialBgmVolume);
		_audioManager.ChangeVolume(SoundCategory.BANK, initialBgmVolume);
		_audioManager.ChangeSeVolume(initialSeVolume);
	}

	private void OnSubmit()
	{
		LanguageType lang = LanguageType.JP;
		if (_jp.isOn)
		{
			lang = LanguageType.JP;
		}
		else if (_en.isOn)
		{
			lang = LanguageType.EN;
		}
		else if (_cn.isOn)
		{
			lang = LanguageType.CN;
		}
		else if (_ko.isOn)
		{
			lang = LanguageType.KO;
		}
		else if (_tw.isOn)
		{
			lang = LanguageType.TW;
		}
		else if (_vn.isOn)
		{
			lang = LanguageType.VN;
		}
		else if (_fr.isOn)
		{
			lang = LanguageType.FR;
		}
		else if (_it.isOn)
		{
			lang = LanguageType.IT;
		}
		else if (_ge.isOn)
		{
			lang = LanguageType.GE;
		}
		else if (_sp.isOn)
		{
			lang = LanguageType.SP;
		}
		else if (_ru.isOn)
		{
			lang = LanguageType.RU;
		}
		if (_max.isOn)
		{
			SingletonMonoBehaviour<Settings>.Instance.Resolution.Value = ResolutionType.FullScreen;
		}
		else if (_equal.isOn)
		{
			SingletonMonoBehaviour<Settings>.Instance.Resolution.Value = ResolutionType.Toubai;
		}
		else if (_windowed.isOn)
		{
			SingletonMonoBehaviour<Settings>.Instance.Resolution.Value = ResolutionType.Window;
		}
		SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(lang);
		SingletonMonoBehaviour<Settings>.Instance.BgmVolume = _bgmValueSlider.value * 0.01f;
		SingletonMonoBehaviour<Settings>.Instance.SeVolume = _seValueSlider.value * 0.01f;
		SingletonMonoBehaviour<Settings>.Instance.SetResolution();
		SingletonMonoBehaviour<Settings>.Instance.Save();
		Close();
	}

	private void OnLanguageChanged()
	{
		_bgmText.text = NgoEx.SystemTextFromType(SystemTextType.Config_BGM, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_seText.text = NgoEx.SystemTextFromType(SystemTextType.Config_SE, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_languageTitle.text = NgoEx.SystemTextFromType(SystemTextType.Config_Language, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_submitButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_dismissButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_vibrationTitle.text = NgoEx.SystemTextFromType(SystemTextType.System_Vibration, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	public List<GameObject> GetSelectableObjects()
	{
		if (_selectableObjects != null)
		{
			return _selectableObjects;
		}
		_selectableObjects = new List<GameObject>();
		_selectableObjects.Add(((Component)_bgmValueSlider.handleRect).gameObject);
		_selectableObjects.Add(((Component)_seValueSlider.handleRect).gameObject);
		_selectableObjects.Add(((Component)_jp.graphic).gameObject);
		_selectableObjects.Add(((Component)_en.graphic).gameObject);
		_selectableObjects.Add(((Component)_cn.graphic).gameObject);
		_selectableObjects.Add(((Component)_ko.graphic).gameObject);
		_selectableObjects.Add(((Component)_tw.graphic).gameObject);
		_selectableObjects.Add(((Component)_vn.graphic).gameObject);
		_selectableObjects.Add(((Component)_fr.graphic).gameObject);
		_selectableObjects.Add(((Component)_it.graphic).gameObject);
		_selectableObjects.Add(((Component)_ge.graphic).gameObject);
		_selectableObjects.Add(((Component)_sp.graphic).gameObject);
		_selectableObjects.Add(((Component)_max.graphic).gameObject);
		_selectableObjects.Add(((Component)_equal.graphic).gameObject);
		_selectableObjects.Add(((Component)_windowed.graphic).gameObject);
		_selectableObjects.Add(((Component)_dismissButton).gameObject);
		_selectableObjects.Add(((Component)_submitButton).gameObject);
		return _selectableObjects;
	}
}
