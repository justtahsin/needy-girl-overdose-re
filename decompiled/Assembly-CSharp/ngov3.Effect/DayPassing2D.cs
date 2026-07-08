using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;

namespace ngov3.Effect;

public class DayPassing2D : MonoBehaviour, IDayPassing
{
	[SerializeField]
	private SpriteRenderersFader _spriteFader;

	[SerializeField]
	private TMPTextsFader _tmpFader;

	[SerializeField]
	private GameObject _raycastBlocker;

	[SerializeField]
	private RectTransform ArrowImageRect;

	[SerializeField]
	private RectTransform CalendarScroll;

	[SerializeField]
	private TMP_Text DayView;

	[SerializeField]
	private SpriteRenderer _heartSprite;

	private ReactiveProperty<int> _dayIndex;

	private ReactiveProperty<int> _dayPart;

	[SerializeField]
	private Volume Noise;

	private Sequence sequence;

	private Sequence ypsequence;

	private bool playingAnimation;

	private async UniTask Start()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		_heartSprite.gameObject.SetActive(value: false);
		_spriteFader.Alpha = 1f;
		_tmpFader.Alpha = 0f;
		Noise.weight = 0f;
		_raycastBlocker.SetActive(value: true);
		await UniTask.DelayFrame(5);
		_tmpFader.Alpha = 1f;
		_heartSprite.gameObject.SetActive(value: true);
		_dayIndex.Where((int d) => d < 31).Subscribe(delegate
		{
			dayPass(_dayIndex.Value, 0, 0);
		}).AddTo(base.gameObject);
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
				_spriteFader.Alpha = 0.5f;
				_tmpFader.Alpha = 0.5f;
				_raycastBlocker.SetActive(value: true);
				Noise.weight = 0.02f;
				DayView.text = NgoEx.DayText(_dayIndex.Value - 1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				CalendarScroll.gameObject.SetActive(value: false);
			}).Append(DOTween.To(() => _spriteFader.Alpha, delegate(float x)
			{
				_spriteFader.Alpha = x;
			}, 1f, 0.01f).SetEase(Ease.InSine))
				.Join(DOTween.To(() => _tmpFader.Alpha, delegate(float x)
				{
					_tmpFader.Alpha = x;
				}, 1f, 0.01f).SetEase(Ease.InSine))
				.Append(DayView.DOText("????", 4f, richTextEnabled: false, ScrambleMode.Numerals))
				.Join(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 1f, 0.2f).SetEase(Ease.InExpo))
				.Append(DOTween.To(() => _spriteFader.Alpha, delegate(float x)
				{
					_spriteFader.Alpha = x;
				}, 0f, 0.4f).SetEase(Ease.InSine))
				.Join(DOTween.To(() => _tmpFader.Alpha, delegate(float x)
				{
					_tmpFader.Alpha = x;
				}, 0f, 0.4f).SetEase(Ease.InSine))
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
				_spriteFader.Alpha = 1f;
				_tmpFader.Alpha = 1f;
				_raycastBlocker.SetActive(value: true);
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
					UnloadAssets();
				})
				.AppendInterval(0.9f)
				.Append(DOTween.To(() => Noise.weight, delegate(float x)
				{
					Noise.weight = x;
				}, 1f, 0.2f).SetEase(Ease.InExpo))
				.Join(ArrowImageRect.DOLocalMoveY(28f, 0.4f, snapping: true).SetEase(Ease.InOutCubic).SetRelative(isRelative: true))
				.Append(DOTween.To(() => _spriteFader.Alpha, delegate(float x)
				{
					_spriteFader.Alpha = x;
				}, 0f, 0.4f).SetEase(Ease.InSine))
				.Join(DOTween.To(() => _tmpFader.Alpha, delegate(float x)
				{
					_tmpFader.Alpha = x;
				}, 0f, 0.4f).SetEase(Ease.InSine))
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
		_raycastBlocker.SetActive(value: false);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1)
		{
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		}
	}

	private void endAnimationNotbackShortcuts(bool isBackObi = true)
	{
		playingAnimation = false;
		_raycastBlocker.SetActive(value: false);
	}

	private void UnloadAssets()
	{
		LoadWebcamData.DeleteAllCache();
	}
}
