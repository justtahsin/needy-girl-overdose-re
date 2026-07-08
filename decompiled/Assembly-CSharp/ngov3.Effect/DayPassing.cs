using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3.Effect;

public class DayPassing : MonoBehaviour, IDayPassing
{
	[SerializeField]
	public CanvasGroup DayPassingCanvas;

	[SerializeField]
	private Button ClickToSkip;

	[SerializeField]
	private RectTransform ArrowImageRect;

	[SerializeField]
	private RectTransform CalendarScroll;

	[SerializeField]
	private TMP_Text DayView;

	private ReactiveProperty<int> _dayIndex;

	private ReactiveProperty<int> _dayPart;

	[SerializeField]
	private Volume Noise;

	private Sequence sequence;

	private Sequence ypsequence;

	private bool playingAnimation;

	private void Start()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		_dayIndex.Where((int d) => d < 31).Subscribe(delegate
		{
			dayPass(_dayIndex.Value, 0, 0);
		}).AddTo(base.gameObject);
		DayPassingCanvas.alpha = 0f;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
		Noise.weight = 0f;
	}

	private void SkipDayPass()
	{
		if (playingAnimation)
		{
			sequence.Kill(complete: true);
			endAnimation();
		}
	}

	public async UniTask yearsPass(bool isBackObi = true)
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
		if (!playingAnimation)
		{
			playingAnimation = true;
			ypsequence = DOTween.Sequence().OnStart(delegate
			{
				DayPassingCanvas.alpha = 0.5f;
				DayPassingCanvas.interactable = true;
				DayPassingCanvas.blocksRaycasts = true;
				Noise.weight = 0.02f;
				DayView.text = NgoEx.DayText(_dayIndex.Value - 1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				CalendarScroll.gameObject.SetActive(value: false);
			}).Append(DayPassingCanvas.DOFade(1f, 0.01f).SetEase(Ease.InSine))
				.Append(DayView.DOText("????", 4f, richTextEnabled: false, ScrambleMode.Numerals))
				.Join(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 1f, 0.2f).SetEase(Ease.InExpo))
				.Append(DayPassingCanvas.DOFade(0f, 0.4f).SetEase(Ease.InSine))
				.AppendCallback(delegate
				{
					endAnimationNotbackShortcuts(isBackObi);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayIndex, 100);
				})
				.Join(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 0f, 0.2f).SetEase(Ease.OutExpo));
			await ypsequence.Play();
		}
	}

	private void dayPass(int dayIndex, int dayPart, int previousDayPart)
	{
		if (!playingAnimation)
		{
			playingAnimation = true;
			int previousDay = ((dayPart == 0) ? (dayIndex - 1) : dayIndex);
			sequence = DOTween.Sequence().OnStart(delegate
			{
				DayPassingCanvas.alpha = 1f;
				DayPassingCanvas.interactable = true;
				DayPassingCanvas.blocksRaycasts = true;
				Noise.weight = 0.02f;
				DayView.text = NgoEx.DayText(previousDay, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
			}).Append(CalendarScroll.DOLocalMoveX(-188f * (float)previousDay - 48f * (float)previousDayPart - 75.200005f, 0.0001f, snapping: true).SetEase(Ease.InSine))
				.Append(ArrowImageRect.DOLocalMoveY(-28f, 0.4f, snapping: true).SetRelative(isRelative: true))
				.AppendCallback(delegate
				{
					SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
				})
				.Append(CalendarScroll.DOLocalMoveX(-188f * (float)dayIndex - 48f * (float)dayPart - 75.200005f, 0.4f, snapping: true).SetEase(Ease.InOutSine))
				.AppendCallback(delegate
				{
					DayView.text = NgoEx.DayText(dayIndex, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					AudioManager.Instance.PlaySeByType(SoundType.SE_Notification);
				})
				.AppendCallback(delegate
				{
					UnloadAssets().Forget();
				})
				.AppendInterval(0.9f)
				.Append(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 1f, 0.2f).SetEase(Ease.InExpo))
				.Join(ArrowImageRect.DOLocalMoveY(28f, 0.4f, snapping: true).SetEase(Ease.InOutCubic).SetRelative(isRelative: true))
				.Append(DayPassingCanvas.DOFade(0f, 0.4f).SetEase(Ease.InSine))
				.AppendCallback(delegate
				{
					endAnimation();
				})
				.Append(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 0f, 0.2f).SetEase(Ease.OutExpo))
				.Play();
		}
	}

	private void endAnimation(bool isBackObi = true)
	{
		playingAnimation = false;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1)
		{
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		}
	}

	private void endAnimationNotbackShortcuts(bool isBackObi = true)
	{
		playingAnimation = false;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
	}

	private async UniTask UnloadAssets()
	{
		LoadWebcamData.DeleteAllCache();
		await Resources.UnloadUnusedAssets().ToUniTask();
	}
}
