using System;
using System.Collections.Generic;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class GraphManager : MonoBehaviour
{
	[SerializeField]
	private StatusType type;

	[SerializeField]
	private Text label;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private Text diffText;

	[SerializeField]
	private Text value;

	[SerializeField]
	private Text MaxValue;

	[SerializeField]
	private Text statusTopic;

	[SerializeField]
	private bool isSummingDelta;

	[SerializeField]
	private GameObject graphBg;

	[SerializeField]
	private GameObject balloon;

	[SerializeField]
	private float interval = 4f;

	[SerializeField]
	private float tmpTime;

	[SerializeField]
	private List<float> history = new List<float>();

	[SerializeField]
	private List<RectTransform> graphBars = new List<RectTransform>();

	private Status status;

	private Tweener tweener;

	private Transform balloonTr;

	private bool updateWithTween = true;

	private Sequence balloonTweenSequence;

	private void Awake()
	{
		Initialize();
		tweener = TweenSettingsExtensions.SetRecyclable<Tweener>(TweenSettingsExtensions.SetLoops<Tweener>(ShortcutExtensions.DOShakePosition(((Component)value).gameObject.transform, 0.2f, 5f, 10, 90f, true, true), -1), true);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			label.text = NgoEx.StatusLabelFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}), ((Component)this).gameObject);
	}

	public void SetType(StatusType type)
	{
		this.type = type;
		Initialize();
	}

	private void Update()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
		{
			UpdateGraph();
			return;
		}
		tmpTime += Time.deltaTime;
		if (tmpTime >= interval)
		{
			UpdateGraph();
			tmpTime = 0f;
		}
	}

	private void UpdateGraph()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (type != StatusType.Follower)
		{
			history.Add((float)status.currentValue.Value / (float)status.maxValue.Value);
			if (history.Count > 30)
			{
				history.RemoveAt(0);
			}
			for (int i = 0; i < 30; i++)
			{
				((Transform)graphBars[i]).localScale = new Vector3(1f, history[i], 1f);
			}
		}
	}

	private void Initialize()
	{
		status = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status s) => s.statusType == type);
		label.text = NgoEx.StatusLabelFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		icon.sprite = LoadStatusData.ReadstatusContent(type).StatusIcon;
		balloonTr = balloon.transform;
		NewValue(status.currentValue.Value, 0);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe(Observable.Zip((IObservable<int>)status.currentValue, Observable.Skip<int>((IObservable<int>)status.currentValue, 1), (int x, int y) => new
		{
			OldValue = x,
			NewValue = y
		}), t =>
		{
			NewValue(t.NewValue, t.OldValue);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)status.maxValue, (Action<int>)delegate(int x)
		{
			NewMaxValue(x);
		}), ((Component)this).gameObject);
		for (int num = 0; num <= 30; num++)
		{
			history.Add(0f);
		}
	}

	private void NewValue(int newValue, int oldValue)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		if (!updateWithTween)
		{
			NewValueDirectly(newValue, oldValue);
			return;
		}
		int num = newValue - oldValue;
		string text = ((num > 0) ? $"+{num}" : num.ToString());
		balloonTweenSequence = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Join(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			balloon.SetActive(true);
			((Component)statusTopic).gameObject.SetActive(false);
			((Component)diffText).gameObject.SetActive(true);
			diffText.text = "";
		}), (Tween)(object)DOTweenModuleUI.DOText(diffText, text, 0.2f, true, (ScrambleMode)4, (string)null)), (Tween)(object)DOTweenModuleUI.DOText(value, newValue.ToString(), 0.6f, true, (ScrambleMode)4, (string)null)), 1f), (Tween)(object)ShortcutExtensions.DOLocalMoveX(balloon.transform, -38f, 0.2f, true)), (TweenCallback)delegate
		{
			if (type != StatusType.Follower)
			{
				((Component)diffText).gameObject.SetActive(false);
				statusTopic.text = getTopic(status.statusType, newValue);
				((Component)statusTopic).gameObject.SetActive(true);
			}
		}), 4f), (Tween)(object)ShortcutExtensions.DOLocalMoveX(balloon.transform, -140f, 0.001f, true)), (TweenCallback)delegate
		{
			balloon.gameObject.SetActive(false);
		}));
		if ((type == StatusType.Stress && newValue >= 80) || (type == StatusType.Yami && newValue == 0) || (type == StatusType.Love && newValue == 0) || (type == StatusType.Love && newValue == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love)))
		{
			((Graphic)value).color = new Color(77f / 85f, 0.32156864f, 0.32156864f, 1f);
			TweenExtensions.Play<Tweener>(tweener);
		}
		else
		{
			((Graphic)value).color = new Color(0.3019608f, 7f / 51f, 69f / 85f, 1f);
			TweenExtensions.Pause<Tweener>(tweener);
		}
	}

	private void NewValueDirectly(int newValue, int oldValue)
	{
		int num = newValue - oldValue;
		string text = ((num > 0) ? $"+{num}" : num.ToString());
		diffText.text = text;
		value.text = newValue.ToString();
	}

	private void NewMaxValue(int newValue)
	{
		MaxValue.text = "/" + newValue;
	}

	private void NewDelta(int newValue)
	{
		if (newValue == 0)
		{
			((Component)icon).gameObject.SetActive(true);
			return;
		}
		((Component)icon).gameObject.SetActive(false);
		_ = 0;
	}

	private string getTopic(StatusType type, int value)
	{
		return type switch
		{
			StatusType.Stress => TopicStress(value, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			StatusType.Love => TopicLove(value, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			StatusType.Yami => TopicYami(value, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			_ => "", 
		};
	}

	private static string TopicStress(int value, LanguageType lang)
	{
		if (value < 20)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Stress00, lang);
		}
		if (value < 40)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Stress20, lang);
		}
		if (value < 60)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Stress40, lang);
		}
		if (value < 80)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Stress60, lang);
		}
		return NgoEx.StatusTextFromType(StatusTextType.Status_Stress80, lang);
	}

	private static string TopicLove(int value, LanguageType lang)
	{
		if (value < 20)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Affection00, lang);
		}
		if (value < 40)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Affection20, lang);
		}
		if (value < 60)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Affection40, lang);
		}
		if (value < 80)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Affection60, lang);
		}
		return NgoEx.StatusTextFromType(StatusTextType.Status_Affection80, lang);
	}

	private static string TopicYami(int value, LanguageType lang)
	{
		if (value < 20)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Mental00, lang);
		}
		if (value < 40)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Mental20, lang);
		}
		if (value < 60)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Mental40, lang);
		}
		if (value < 80)
		{
			return NgoEx.StatusTextFromType(StatusTextType.Status_Mental60, lang);
		}
		return NgoEx.StatusTextFromType(StatusTextType.Status_Mental80, lang);
	}

	public void SetTooltip(bool onoff)
	{
		TooltipCaller component = ((Component)this).GetComponent<TooltipCaller>();
		if ((Object)(object)component != (Object)null)
		{
			component.isShowTooltip = onoff;
		}
	}

	public void OnReadyToOutOfOrder()
	{
		updateWithTween = false;
		balloon.SetActive(false);
		TweenExtensions.Kill((Tween)(object)balloonTweenSequence, true);
		((Behaviour)graphBg.GetComponent<HorizontalLayoutGroup>()).enabled = false;
	}

	public void OnGoOutOfOrder()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Vector3 localPosition = balloonTr.localPosition;
		localPosition.x = -38f;
		balloonTr.localPosition = localPosition;
		((Component)statusTopic).gameObject.SetActive(false);
		balloon.SetActive(true);
		((Component)diffText).gameObject.SetActive(true);
	}
}
