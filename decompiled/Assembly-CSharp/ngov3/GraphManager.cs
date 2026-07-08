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
		tweener = value.gameObject.transform.DOShakePosition(0.2f, 5f, 10, 90f, snapping: true).SetLoops(-1).SetRecyclable(recyclable: true);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			label.text = NgoEx.StatusLabelFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}).AddTo(base.gameObject);
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
		if (type != StatusType.Follower)
		{
			history.Add((float)status.currentValue.Value / (float)status.maxValue.Value);
			if (history.Count > 30)
			{
				history.RemoveAt(0);
			}
			for (int i = 0; i < 30; i++)
			{
				graphBars[i].localScale = new Vector3(1f, history[i], 1f);
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
		status.currentValue.Zip(status.currentValue.Skip(1), (int x, int y) => new
		{
			OldValue = x,
			NewValue = y
		}).Subscribe(t =>
		{
			NewValue(t.NewValue, t.OldValue);
		}).AddTo(base.gameObject);
		status.maxValue.Subscribe(delegate(int x)
		{
			NewMaxValue(x);
		}).AddTo(base.gameObject);
		for (int num = 0; num <= 30; num++)
		{
			history.Add(0f);
		}
	}

	private void NewValue(int newValue, int oldValue)
	{
		if (!updateWithTween)
		{
			NewValueDirectly(newValue, oldValue);
			return;
		}
		int num = newValue - oldValue;
		string endValue = ((num > 0) ? $"+{num}" : num.ToString());
		balloonTweenSequence = DOTween.Sequence().OnStart(delegate
		{
			balloon.SetActive(value: true);
			statusTopic.gameObject.SetActive(value: false);
			diffText.gameObject.SetActive(value: true);
			diffText.text = "";
		}).Append(diffText.DOText(endValue, 0.2f, richTextEnabled: true, ScrambleMode.Numerals))
			.Append(value.DOText(newValue.ToString(), 0.6f, richTextEnabled: true, ScrambleMode.Numerals))
			.AppendInterval(1f)
			.Join(balloon.transform.DOLocalMoveX(-38f, 0.2f, snapping: true))
			.AppendCallback(delegate
			{
				if (type != StatusType.Follower)
				{
					diffText.gameObject.SetActive(value: false);
					statusTopic.text = getTopic(status.statusType, newValue);
					statusTopic.gameObject.SetActive(value: true);
				}
			})
			.AppendInterval(4f)
			.Append(balloon.transform.DOLocalMoveX(-140f, 0.001f, snapping: true))
			.OnComplete(delegate
			{
				balloon.gameObject.SetActive(value: false);
			})
			.Play();
		if ((type == StatusType.Stress && newValue >= 80) || (type == StatusType.Yami && newValue == 0) || (type == StatusType.Love && newValue == 0) || (type == StatusType.Love && newValue == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love)))
		{
			value.color = new Color(77f / 85f, 0.32156864f, 0.32156864f, 1f);
			tweener.Play();
		}
		else
		{
			value.color = new Color(0.3019608f, 7f / 51f, 69f / 85f, 1f);
			tweener.Pause();
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
			icon.gameObject.SetActive(value: true);
			return;
		}
		icon.gameObject.SetActive(value: false);
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
		TooltipCaller component = GetComponent<TooltipCaller>();
		if (component != null)
		{
			component.isShowTooltip = onoff;
		}
	}

	public void OnReadyToOutOfOrder()
	{
		updateWithTween = false;
		balloon.SetActive(value: false);
		balloonTweenSequence.Kill(complete: true);
		graphBg.GetComponent<HorizontalLayoutGroup>().enabled = false;
	}

	public void OnGoOutOfOrder()
	{
		Vector3 localPosition = balloonTr.localPosition;
		localPosition.x = -38f;
		balloonTr.localPosition = localPosition;
		statusTopic.gameObject.SetActive(value: false);
		balloon.SetActive(value: true);
		diffText.gameObject.SetActive(value: true);
	}
}
