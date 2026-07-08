using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3.Effect;

public sealed class DayAndNight : MonoBehaviour
{
	private ReactiveProperty<int> _dayIndex;

	private ReactiveProperty<int> _dayPart;

	[SerializeField]
	private Button _Daypass;

	[SerializeField]
	private Image Right;

	[SerializeField]
	private Image Left;

	[SerializeField]
	private Sprite Noon;

	[SerializeField]
	private Sprite Twilight;

	[SerializeField]
	private Sprite Night;

	private int nowPart = 100;

	private const float CAMERAVIEWPOINT = 0.1260417f;

	private Volume blur;

	private void Awake()
	{
		blur = ((Component)this).GetComponent<Volume>();
	}

	private void Start()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		ReactiveProperty<int> delta = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status status) => status.statusType == StatusType.DayPart).delta;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_dayPart, (Action<int>)delegate(int value)
		{
			DayToNight(value);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)delta, (Action<int>)delegate(int value)
		{
			DayToNight(_dayPart.Value + value);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_dayIndex, (Action<int>)delegate
		{
			DayToNight(_dayPart.Value);
		}), ((Component)this).gameObject);
		if ((Object)(object)_Daypass != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_Daypass), (Action<Unit>)delegate
			{
				dayPass();
			}), ((Component)this).gameObject);
		}
	}

	private void DayToNight(int dayPart)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		if (nowPart == dayPart)
		{
			return;
		}
		nowPart = dayPart;
		float weight = 1f;
		switch (dayPart)
		{
		case 0:
			Right.sprite = Noon;
			Left.sprite = Noon;
			TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
			{
				blur.weight = x;
			}, 0f, 2.2f), (Ease)18)));
			break;
		case 1:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_Notification);
			TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
			{
				blur.weight = x;
			}, 1f, 0.2f), (Ease)17)), (TweenCallback)delegate
			{
				Right.sprite = Twilight;
				Left.sprite = Twilight;
			}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
			{
				blur.weight = x;
			}, 0f, 3.2f), (Ease)18)));
			break;
		case 2:
		case 3:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_Notification);
			TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
			{
				blur.weight = x;
			}, 1f, 0.2f), (Ease)17)), (TweenCallback)delegate
			{
				Right.sprite = Night;
				Left.sprite = Night;
			}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
			{
				blur.weight = x;
			}, 0f, 3.2f), (Ease)18)));
			break;
		}
	}

	private void dayPass()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
	}
}
