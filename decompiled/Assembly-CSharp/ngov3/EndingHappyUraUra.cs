using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class EndingHappyUraUra : MonoBehaviour
{
	[SerializeField]
	private GameObject _followers;

	[SerializeField]
	private Button _uraUraAccount;

	[SerializeField]
	private CanvasGroup _uraUraHint;

	[SerializeField]
	private GameObject _tweets;

	[SerializeField]
	private CanvasGroup _tweet1;

	[SerializeField]
	private CanvasGroup _tweet2;

	[SerializeField]
	private CanvasGroup _tweet3;

	[SerializeField]
	private CanvasGroup _tweet4;

	[SerializeField]
	private CanvasGroup _tweet5;

	[SerializeField]
	private CanvasGroup _blocked;

	[SerializeField]
	private Button _followRequest;

	[SerializeField]
	private CanvasGroup _antenCover;

	private void Awake()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(_uraUraHint, 1f, 1f), -1, (LoopType)1), (Ease)7));
		Sequence sequence = DOTween.Sequence();
		TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.OnStart<Sequence>(sequence, (TweenCallback)delegate
		{
			_followers.SetActive(false);
			_tweets.SetActive(true);
			((Component)_tweet1).gameObject.SetActive(false);
			((Component)_tweet2).gameObject.SetActive(false);
			((Component)_tweet3).gameObject.SetActive(false);
			((Component)_tweet4).gameObject.SetActive(false);
			((Component)_tweet5).gameObject.SetActive(false);
		}), (TweenCallback)delegate
		{
			((Component)_tweet1).gameObject.SetActive(true);
		}), (Tween)(object)DOTweenModuleUI.DOFade(_tweet1, 1f, 2.2f)), (TweenCallback)delegate
		{
			((Component)_tweet2).gameObject.SetActive(true);
		}), (Tween)(object)DOTweenModuleUI.DOFade(_tweet2, 1f, 2.2f)), (TweenCallback)delegate
		{
			((Component)_tweet3).gameObject.SetActive(true);
		}), (Tween)(object)DOTweenModuleUI.DOFade(_tweet3, 1f, 2.2f)), (TweenCallback)delegate
		{
			((Component)_tweet4).gameObject.SetActive(true);
		}), (Tween)(object)DOTweenModuleUI.DOFade(_tweet4, 1f, 2.2f)), (TweenCallback)delegate
		{
			((Component)_tweet5).gameObject.SetActive(true);
		}), (Tween)(object)DOTweenModuleUI.DOFade(_tweet5, 1f, 2.2f));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_uraUraAccount), (Action<Unit>)delegate
		{
			TweenExtensions.Play<Sequence>(sequence);
		}), (Component)(object)_uraUraAccount);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_followRequest), (Action<Unit>)async delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
			await UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			AudioManager.Instance.PlaySeByType(SoundType.SE_Error);
			_blocked.alpha = 1f;
			_blocked.blocksRaycasts = true;
			await UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			AchievementStatsUpdater.UpdateStats("Ending_Happy");
		}), (Component)(object)_followRequest);
	}
}
