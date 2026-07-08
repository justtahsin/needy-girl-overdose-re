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
		_windowSettingView.SetActive(value: true);
		_vibrationSettingView.SetActive(value: false);
		IObservable<float> source = _bgmValueSlider.OnValueChangedAsObservable().Share();
		IObservable<float> source2 = _seValueSlider.OnValueChangedAsObservable().Share();
		initialBgmVolume = SingletonMonoBehaviour<Settings>.Instance.BgmVolume;
		initialSeVolume = SingletonMonoBehaviour<Settings>.Instance.SeVolume;
		source.Select((float v) => v).Subscribe(delegate(float v)
		{
			float value = Mathf.Floor(v) * 0.01f;
			_audioManager.ChangeVolume(SoundCategory.BGM, value);
			_audioManager.ChangeVolume(SoundCategory.BANK, value);
			_bgmValueText.text = Mathf.FloorToInt(v).ToString();
		}).AddTo(base.gameObject);
		source2.Select((float v) => v * 0.01f).Subscribe(delegate(float v)
		{
			_audioManager.ChangeSeVolume(v);
			_seValueText.text = Mathf.FloorToInt(v * 100f).ToString();
		}).AddTo(base.gameObject);
		source2.Distinct().ThrottleFrame(100).Skip(1)
			.Subscribe(delegate
			{
				_audioManager.PlaySeByType(SoundType.SE_per);
			})
			.AddTo(base.gameObject);
		_dismissButton.OnClickAsObservable().Subscribe(delegate
		{
			ResetVolume();
			Close();
		}).AddTo(base.gameObject);
		_submitButton.OnClickAsObservable().Subscribe(delegate
		{
			OnSubmit();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType v)
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
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.Resolution.Subscribe(delegate(ResolutionType v)
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
		}).AddTo(base.gameObject);
		_bgmValueSlider.value = SingletonMonoBehaviour<Settings>.Instance.BgmVolume * 100f;
		_seValueSlider.value = SingletonMonoBehaviour<Settings>.Instance.SeVolume * 100f;
		OnLanguageChanged();
		SingletonMonoBehaviour<Settings>.Instance.VibrationType.Subscribe(delegate(VibrationType v)
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
		}).AddTo(base.gameObject);
		GetComponentInParent<IWindow>()._close.OnClickAsObservable().Subscribe(delegate
		{
			ResetVolume();
		}).AddTo(base.gameObject);
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
		_submitButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_dismissButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_vibrationTitle.text = NgoEx.SystemTextFromType(SystemTextType.System_Vibration, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	public List<GameObject> GetSelectableObjects()
	{
		if (_selectableObjects != null)
		{
			return _selectableObjects;
		}
		_selectableObjects = new List<GameObject>();
		_selectableObjects.Add(_bgmValueSlider.handleRect.gameObject);
		_selectableObjects.Add(_seValueSlider.handleRect.gameObject);
		_selectableObjects.Add(_jp.graphic.gameObject);
		_selectableObjects.Add(_en.graphic.gameObject);
		_selectableObjects.Add(_cn.graphic.gameObject);
		_selectableObjects.Add(_ko.graphic.gameObject);
		_selectableObjects.Add(_tw.graphic.gameObject);
		_selectableObjects.Add(_vn.graphic.gameObject);
		_selectableObjects.Add(_fr.graphic.gameObject);
		_selectableObjects.Add(_it.graphic.gameObject);
		_selectableObjects.Add(_ge.graphic.gameObject);
		_selectableObjects.Add(_sp.graphic.gameObject);
		_selectableObjects.Add(_max.graphic.gameObject);
		_selectableObjects.Add(_equal.graphic.gameObject);
		_selectableObjects.Add(_windowed.graphic.gameObject);
		_selectableObjects.Add(_dismissButton.gameObject);
		_selectableObjects.Add(_submitButton.gameObject);
		return _selectableObjects;
	}
}
