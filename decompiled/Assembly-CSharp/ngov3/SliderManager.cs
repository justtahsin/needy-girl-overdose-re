using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
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
		((UnityEvent<float>)(object)slider.onValueChanged).AddListener((UnityAction<float>)delegate
		{
			ValueChangeDisp();
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)status.currentValue, (Action<int>)delegate(int x)
		{
			NewValue(x);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)status.maxValue, (Action<int>)delegate(int x)
		{
			NewMaxValue(x);
		}), ((Component)this).gameObject);
		if (isSummingDelta)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)status.todaysDelta, (Action<int>)delegate(int x)
			{
				NewDelta(x);
			}), ((Component)this).gameObject);
		}
		else
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)status.delta, (Action<int>)delegate(int x)
			{
				NewDelta(x);
			}), ((Component)this).gameObject);
		}
	}

	private void NewValue(int newValue)
	{
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => slider.value), (DOSetter<float>)delegate(float x)
		{
			slider.value = x;
		}, (float)newValue, 0.4f), (Ease)8));
		TweenExtensions.Play<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(statusTopic, getTopic(status.statusType, newValue), 0.6f, true, (ScrambleMode)0, (string)null));
	}

	private void NewMaxValue(int newValue)
	{
		slider.maxValue = newValue;
	}

	private void NewDelta(int newValue)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if (newValue == 0)
		{
			((Component)icon).gameObject.SetActive(true);
			((Component)diffText).gameObject.SetActive(false);
			return;
		}
		((Component)diffText).gameObject.SetActive(true);
		((Component)icon).gameObject.SetActive(false);
		if (newValue > 0)
		{
			((Graphic)diffText).color = Color32.op_Implicit(new Color32((byte)82, (byte)124, (byte)231, byte.MaxValue));
			diffText.text = "+" + newValue;
		}
		else
		{
			((Graphic)diffText).color = Color32.op_Implicit(new Color32((byte)231, (byte)82, (byte)82, byte.MaxValue));
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
