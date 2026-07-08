using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class SliderManager : MonoBehaviour
{
	[SerializeField]
	private StatusType type;

	[SerializeField]
	private Slider slider;

	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private TMP_Text diffText;

	[SerializeField]
	private TMP_Text value;

	[SerializeField]
	private TMP_Text statusTopic;

	[SerializeField]
	private bool isSummingDelta;

	private Status status;

	private void Start()
	{
		Initialize();
	}

	public void SetType(StatusType type)
	{
		this.type = type;
		Initialize();
	}

	private void Initialize()
	{
		status = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status s) => s.statusType == type);
		slider.maxValue = status.maxValue.Value;
		slider.minValue = status.minValue;
		slider.value = status.currentValue.Value;
		ValueChangeDisp();
		label.text = NgoEx.StatusLabelFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		icon.sprite = LoadStatusData.ReadstatusContent(type)?.StatusIcon;
		slider.onValueChanged.AddListener(delegate
		{
			ValueChangeDisp();
		});
		status.currentValue.Subscribe(delegate(int x)
		{
			NewValue(x);
		}).AddTo(base.gameObject);
		status.maxValue.Subscribe(delegate(int x)
		{
			NewMaxValue(x);
		}).AddTo(base.gameObject);
		if (isSummingDelta)
		{
			status.todaysDelta.Subscribe(delegate(int x)
			{
				NewDelta(x);
			}).AddTo(base.gameObject);
		}
		else
		{
			status.delta.Subscribe(delegate(int x)
			{
				NewDelta(x);
			}).AddTo(base.gameObject);
		}
	}

	private void NewValue(int newValue)
	{
		DOTween.To(() => slider.value, delegate(float x)
		{
			slider.value = x;
		}, newValue, 0.4f).SetEase(Ease.InCubic).Play();
		statusTopic.DOText(getTopic(status.statusType, newValue), 0.6f).Play();
	}

	private void NewMaxValue(int newValue)
	{
		slider.maxValue = newValue;
	}

	private void NewDelta(int newValue)
	{
		if (newValue == 0)
		{
			icon.gameObject.SetActive(value: true);
			diffText.gameObject.SetActive(value: false);
			return;
		}
		diffText.gameObject.SetActive(value: true);
		icon.gameObject.SetActive(value: false);
		if (newValue > 0)
		{
			diffText.color = new Color32(82, 124, 231, byte.MaxValue);
			diffText.text = "+" + newValue;
		}
		else
		{
			diffText.color = new Color32(231, 82, 82, byte.MaxValue);
			diffText.text = newValue.ToString();
		}
	}

	public void ValueChangeDisp()
	{
		value.text = slider.value.ToString();
		if (status.dispAsPercent)
		{
			value.text = (slider.value / 100f).ToString();
		}
	}

	public void UpdateStatusToNumber()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(type, Mathf.CeilToInt(slider.value));
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
}
