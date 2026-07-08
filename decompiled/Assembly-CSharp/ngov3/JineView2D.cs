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

public class JineView2D : MonoBehaviour, IApp2D, IScrollable2D, IClickable, IStorable
{
	[SerializeField]
	private Button2D ToBottom;

	[SerializeField]
	private JineCell2D AmeJine;

	[SerializeField]
	private JineCell2D PiJine;

	[SerializeField]
	private JineCell2D PiJineWithButton;

	[SerializeField]
	private JineCell2D Separator;

	[SerializeField]
	private JineCell2D TimeSeparator;

	[SerializeField]
	private RectTransform _jineWaku;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private Fader2D _piHenji;

	[SerializeField]
	private GameObject _piStamp;

	[SerializeField]
	private GameObject _piOptions;

	[SerializeField]
	private GameObject _piOptionContent;

	[SerializeField]
	private Canvas _piFreeform;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Button _submit;

	[SerializeField]
	private bool isAmeHead = true;

	[SerializeField]
	private VerticalGridLayout2D contentsVerticalGridLayout;

	[SerializeField]
	private VerticalLayoutGroup optionsVerticalLayoutGroup;

	private List<JineCell2D> _jineCells = new List<JineCell2D>();

	private List<GameObject> _selectableObjects = new List<GameObject>();

	[SerializeField]
	private RewiredScrollReceiver rewiredScrollReceiver;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private RectTransform viewPortRect;

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	public RewiredScrollReceiver RewiredScrollReceiver => rewiredScrollReceiver;

	public ScrollRect ScrollRect => scrollRect;

	public void SetSortOrder(int order)
	{
		_piFreeform.sortingOrder = order;
	}

	public async UniTask Awake()
	{
		List<JineData> list = new List<JineData>(SingletonMonoBehaviour<JineManager>.Instance.GetNewest());
		list.Reverse();
		foreach (JineData item in list)
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

	public void OnPicked()
	{
		int num = _jineCells.Count - SingletonMonoBehaviour<JineManager>.Instance.JineCountOnLoad;
		if (num > 0)
		{
			List<JineCell2D> range = _jineCells.GetRange(0, num);
			_jineCells.RemoveRange(0, num);
			foreach (JineCell2D item in range)
			{
				Object.Destroy(item.gameObject);
			}
		}
		ToBottom.gameObject.SetActive(value: false);
	}

	public void OnStored()
	{
		_scrollRect.verticalNormalizedPosition = 0f;
	}

	private void SwitchJineStatus(JineManager.WaitStatusType value)
	{
		switch (value)
		{
		case JineManager.WaitStatusType.Stamp:
			showStamp();
			_selectableObjects.Clear();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView2D>().First().SelectableObjects);
			break;
		case JineManager.WaitStatusType.FreeForm:
			showMessage();
			break;
		case JineManager.WaitStatusType.ChooseAction:
			showStamp();
			_selectableObjects.Clear();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView2D>().First().SelectableObjects);
			break;
		default:
			hideReactions();
			break;
		case JineManager.WaitStatusType.Option:
			break;
		}
	}

	public async UniTask makeJine(JineData Ids, int page, bool isNew = true)
	{
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(Ids, isAmeHead);
		Debug.Log($"<color=green>{Ids.id}:{nakami.BodyJp}</color>");
		JineCell2D jineCell2D = null;
		switch (nakami.JineUserType)
		{
		case JineUserType.ame:
			jineCell2D = Object.Instantiate(AmeJine, _jineWaku);
			jineCell2D.setData(nakami);
			isAmeHead = false;
			break;
		case JineUserType.pi:
		{
			jineCell2D = Object.Instantiate(PiJine, _jineWaku);
			int kidokMilliSecond = ((!isNew) ? 1 : 800);
			jineCell2D.setData(nakami, kidokMilliSecond);
			isAmeHead = true;
			break;
		}
		case JineUserType.separator:
			jineCell2D = Object.Instantiate(Separator, _jineWaku);
			jineCell2D.setDay(nakami.Day);
			isAmeHead = true;
			break;
		case JineUserType.timeSeparator:
			jineCell2D = Object.Instantiate(TimeSeparator, _jineWaku);
			jineCell2D.setDayPart(nakami.Day);
			isAmeHead = true;
			break;
		case JineUserType.eventSeparator:
			jineCell2D = Object.Instantiate(TimeSeparator, _jineWaku);
			jineCell2D.setData(nakami);
			isAmeHead = true;
			break;
		}
		jineCell2D.SetUpMask(viewPortRect);
		contentsVerticalGridLayout.AddLayoutObject(jineCell2D);
		_jineCells.Add(jineCell2D);
		if (Ids.id != JineType.Event_LongLINE001 && Ids.id != JineType.Event_LongLINE002 && Ids.id != JineType.Event_LongLINE003 && Ids.id != JineType.Event_LongLINE004 && Ids.id != JineType.Event_LongLINE005)
		{
			if (nakami.JineUserType == JineUserType.pi)
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
			{
				JineCell2D jineCell2D2 = Object.Instantiate(AmeJine, _jineWaku);
				_jineCells.Add(jineCell2D2);
				contentsVerticalGridLayout.AddLayoutObject(jineCell2D2);
				jineCell2D2.setData(nakami);
				jineCell2D2.SetUpMask(viewPortRect);
				break;
			}
			case JineUserType.pi:
			{
				JineCell2D jineCell2D = Object.Instantiate(PiJine, _jineWaku);
				_jineCells.Add(jineCell2D);
				contentsVerticalGridLayout.AddLayoutObject(jineCell2D);
				jineCell2D.setData(nakami, 0);
				jineCell2D.SetUpMask(viewPortRect);
				break;
			}
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
		await (_scrollRect?.DOVerticalNormalizedPos(0f, 0.15f, snapping: true).SetEase(Ease.InQuad).OnComplete(delegate
		{
			_scrollRect.verticalNormalizedPosition = 0f;
		})
			.Play());
	}

	public void showStamp()
	{
		clearOptions();
		showPihenji();
		_piStamp.SetActive(value: true);
		_piOptions.SetActive(value: false);
		_piFreeform.gameObject.SetActive(value: false);
		ScrollToLatest();
	}

	public void showOptions()
	{
		showPihenji();
		_piStamp.SetActive(value: false);
		_piOptions.SetActive(value: true);
		_piFreeform.gameObject.SetActive(value: false);
		ScrollToLatest();
	}

	public async void AddOptions(JineType opt)
	{
		JineData OptData = new JineData(opt, JineUserType.pi);
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell2D jineCell2D = Object.Instantiate(PiJineWithButton, _piOptionContent.transform);
		_selectableObjects.Add(jineCell2D.BalloonRend.gameObject);
		jineCell2D.setData(nakami, -1);
		jineCell2D.gameObject.transform.Find("Balloon").gameObject.GetComponent<SpriteRenderer>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell2D.gameObject.transform.Find("Balloon").Find("Tail").gameObject.GetComponent<SpriteRenderer>().DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo)
			.Play();
		jineCell2D.transform.GetComponentInChildren<Button>().OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		})
			.AddTo(jineCell2D);
	}

	public async void AddOptions(JineData OptData)
	{
		if (_piOptionContent.transform.childCount == 0)
		{
			_selectableObjects.Clear();
		}
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell2D jineCell2D = Object.Instantiate(PiJineWithButton, _piOptionContent.transform);
		_selectableObjects.Add(jineCell2D.BalloonRend.gameObject);
		jineCell2D.setData(nakami, -1);
		jineCell2D.BalloonRend.DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo).Play();
		jineCell2D.TailRend.DOColor(new Color(0.8f, 1f, 0f), 1.2f).SetLoops(-1, LoopType.Yoyo).Play();
		jineCell2D.transform.GetComponentInChildren<Button>().OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		})
			.AddTo(jineCell2D);
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
		_piFreeform.gameObject.SetActive(value: true);
		SetSortOrder(40);
		ScrollToLatest();
	}

	public void sendMessage(string msg)
	{
		if (!(msg == ""))
		{
			_inputField.text = string.Empty;
			hidePihenji();
			_piFreeform.gameObject.SetActive(value: false);
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
		_piFreeform.gameObject.SetActive(value: false);
		ScrollToLatest();
		_selectableObjects.Clear();
	}

	private void hidePihenji()
	{
		_piHenji.DOFade(0.4f, 0f, Ease.InOutCirc, this.GetCancellationTokenOnDestroy()).Forget();
	}

	private void showPihenji()
	{
		_piHenji.DOFade(0.4f, 0.5f, Ease.InOutCirc, this.GetCancellationTokenOnDestroy()).Forget();
	}

	public void Click()
	{
	}
}
