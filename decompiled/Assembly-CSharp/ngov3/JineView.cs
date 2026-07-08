using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineView : MonoBehaviour
{
	private EventManager _event;

	[SerializeField]
	private GameObject _blink;

	[SerializeField]
	private Button ToBottom;

	[SerializeField]
	private JineCell AmeJine;

	[SerializeField]
	private JineCell PiJine;

	[SerializeField]
	private JineCell Separator;

	[SerializeField]
	private JineCell TimeSeparator;

	[SerializeField]
	private RectTransform _jineWaku;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private GameObject _padding;

	[SerializeField]
	private CanvasGroup _piHenji;

	[SerializeField]
	private GameObject _piStamp;

	[SerializeField]
	private GameObject _piOptions;

	[SerializeField]
	private GameObject _piOptionContent;

	[SerializeField]
	private GameObject _piFreeform;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Button _submit;

	[SerializeField]
	private bool isAmeHead = true;

	private List<GameObject> _selectableObjects = new List<GameObject>();

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	public async UniTask Awake()
	{
		foreach (JineData item in SingletonMonoBehaviour<JineManager>.Instance.GetNewest())
		{
			makeJine(item, 0, isNew: false);
		}
		await ForceScrollToLatest();
		SingletonMonoBehaviour<JineManager>.Instance.waitStatus.Subscribe(delegate(JineManager.WaitStatusType value)
		{
			SwitchJineStatus(value);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> JineData)
		{
			await makeJine(JineData.Value, 0);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<JineManager>.Instance.OnStartOptions.Subscribe(delegate(CollectionAddEvent<JineData> l)
		{
			showOptions();
			AddOptions(l.Value);
		}).AddTo(base.gameObject);
		_submit.OnClickAsObservable().Subscribe(delegate
		{
			sendMessage(_inputField.text);
		}).AddTo(_submit);
		ToBottom.OnClickAsObservable().Subscribe(async delegate
		{
			await ForceScrollToLatest();
		}).AddTo(ToBottom);
	}

	private void SwitchJineStatus(JineManager.WaitStatusType value)
	{
		_selectableObjects.Clear();
		switch (value)
		{
		case JineManager.WaitStatusType.Stamp:
			showStamp();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView>().First().SelectableObjects);
			break;
		case JineManager.WaitStatusType.Option:
		{
			showOptions();
			if (_piOptionContent.transform.childCount == 0)
			{
				foreach (JineData option in SingletonMonoBehaviour<JineManager>.Instance.options)
				{
					AddOptions(option);
				}
			}
			JineCell[] componentsInChildren = _piOptionContent.GetComponentsInChildren<JineCell>();
			foreach (JineCell jineCell in componentsInChildren)
			{
				_selectableObjects.Add(jineCell.gameObject);
			}
			break;
		}
		case JineManager.WaitStatusType.FreeForm:
			showMessage();
			break;
		case JineManager.WaitStatusType.ChooseAction:
			showStamp();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView>().First().SelectableObjects);
			break;
		default:
			hideReactions();
			break;
		}
	}

	public async UniTask makeJine(JineData Ids, int page, bool isNew = true)
	{
		JineDrawable jineDrawable = JineDataConverter.convertJineDataToDrawable(Ids, isAmeHead);
		switch (jineDrawable.JineUserType)
		{
		case JineUserType.ame:
			await Object.Instantiate(AmeJine, _jineWaku).setData(jineDrawable);
			isAmeHead = false;
			break;
		case JineUserType.pi:
		{
			JineCell jineCell = Object.Instantiate(PiJine, _jineWaku);
			int kidokMilliSecond = ((!isNew) ? 1 : 800);
			await jineCell.setData(jineDrawable, kidokMilliSecond);
			isAmeHead = true;
			break;
		}
		case JineUserType.separator:
			Object.Instantiate(Separator, _jineWaku).setDay(jineDrawable.Day);
			isAmeHead = true;
			break;
		case JineUserType.timeSeparator:
			Object.Instantiate(TimeSeparator, _jineWaku).setDayPart(jineDrawable.Day);
			isAmeHead = true;
			break;
		case JineUserType.eventSeparator:
			await Object.Instantiate(TimeSeparator, _jineWaku).setData(jineDrawable);
			isAmeHead = true;
			break;
		}
		if (Ids.id != JineType.Event_LongLINE001 && Ids.id != JineType.Event_LongLINE002 && Ids.id != JineType.Event_LongLINE003 && Ids.id != JineType.Event_LongLINE004 && Ids.id != JineType.Event_LongLINE005)
		{
			if (jineDrawable.JineUserType == JineUserType.pi)
			{
				ForceScrollToLatest();
			}
			else
			{
				ScrollToLatest();
			}
		}
	}

	public void LoadJine(int startFromNewest, int endFromNewest)
	{
		int count = SingletonMonoBehaviour<JineManager>.Instance.history.Count;
		if (startFromNewest >= count || startFromNewest > endFromNewest)
		{
			return;
		}
		foreach (JineData item in SingletonMonoBehaviour<JineManager>.Instance.GetHistoryRange(startFromNewest, endFromNewest))
		{
			JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(item);
			switch (nakami.JineUserType)
			{
			case JineUserType.ame:
				Object.Instantiate(AmeJine, _jineWaku).setData(nakami);
				break;
			case JineUserType.pi:
				Object.Instantiate(PiJine, _jineWaku).setData(nakami, 0);
				break;
			}
		}
	}

	public async UniTask ScrollToLatest()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Completed)
		{
			await ForceScrollToLatest();
		}
		else if (!(_scrollRect.verticalNormalizedPosition > 0.15f) || SingletonMonoBehaviour<JineManager>.Instance.history.Count <= 20)
		{
			await ForceScrollToLatest();
		}
		else
		{
			ToBottom.gameObject.SetActive(value: true);
		}
	}

	public async UniTask ForceScrollToLatest()
	{
		ToBottom.gameObject.SetActive(value: false);
		await _scrollRect.DOVerticalNormalizedPos(0f, 0.15f, snapping: true).SetEase(Ease.InQuad).Play();
		_scrollRect.verticalNormalizedPosition = 0f;
	}

	public void showStamp()
	{
		clearOptions();
		showPihenji();
		_piStamp.SetActive(value: true);
		_piOptions.SetActive(value: false);
		_piFreeform.SetActive(value: false);
		ScrollToLatest();
	}

	public void showOptions()
	{
		showPihenji();
		_piStamp.SetActive(value: false);
		_piOptions.SetActive(value: true);
		_piFreeform.SetActive(value: false);
		ScrollToLatest();
	}

	public void AddOptions(JineType opt)
	{
		JineData OptData = new JineData(opt, JineUserType.pi);
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell jineCell = Object.Instantiate(PiJine, _piOptionContent.transform);
		jineCell.setData(nakami, -1);
		jineCell.gameObject.transform.Find("Balloon").gameObject.GetComponent<Image>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell.gameObject.transform.Find("Balloon").Find("Tail").gameObject.GetComponent<Image>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell.transform.GetComponentInChildren<Button>().OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		})
			.AddTo(jineCell);
	}

	public void AddOptions(JineData OptData)
	{
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell jineCell = Object.Instantiate(PiJine, _piOptionContent.transform);
		jineCell.setData(nakami, -1);
		jineCell.gameObject.transform.Find("Balloon").gameObject.GetComponent<Image>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell.gameObject.transform.Find("Balloon").Find("Tail").gameObject.GetComponent<Image>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell.transform.GetComponentInChildren<Button>().OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		})
			.AddTo(jineCell);
	}

	private void clearOptions()
	{
		for (int i = 0; i < _piOptionContent.transform.childCount; i++)
		{
			Object.Destroy(_piOptionContent.transform.GetChild(i).gameObject);
		}
	}

	public void showMessage()
	{
		_piStamp.SetActive(value: false);
		showPihenji();
		clearOptions();
		_piFreeform.SetActive(value: true);
		ScrollToLatest();
	}

	public void sendMessage(string msg)
	{
		if (!(msg == ""))
		{
			_inputField.text = string.Empty;
			hidePihenji();
			_piFreeform.SetActive(value: false);
			SingletonMonoBehaviour<JineManager>.Instance.EndMessage(msg);
			ScrollToLatest();
		}
	}

	public void hideReactions()
	{
		hidePihenji();
		clearOptions();
		_piStamp.SetActive(value: false);
		_piOptions.SetActive(value: false);
		_piFreeform.SetActive(value: false);
		ScrollToLatest();
	}

	private void hidePihenji()
	{
		_piHenji.DOFade(0f, 0.4f).SetEase(Ease.InOutCirc).Play();
	}

	private void showPihenji()
	{
		_piHenji.DOFade(1f, 0.4f).SetEase(Ease.InOutCirc).Play();
	}
}
