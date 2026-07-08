using DG.Tweening;
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
		blur = GetComponent<Volume>();
	}

	private void Start()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		ReactiveProperty<int> delta = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status status) => status.statusType == StatusType.DayPart).delta;
		_dayPart.Subscribe(delegate(int value)
		{
			DayToNight(value);
		}).AddTo(base.gameObject);
		delta.Subscribe(delegate(int value)
		{
			DayToNight(_dayPart.Value + value);
		}).AddTo(base.gameObject);
		_dayIndex.Subscribe(delegate
		{
			DayToNight(_dayPart.Value);
		}).AddTo(base.gameObject);
		if (_Daypass != null)
		{
			_Daypass.OnClickAsObservable().Subscribe(delegate
			{
				dayPass();
			}).AddTo(base.gameObject);
		}
	}

	private void DayToNight(int dayPart)
	{
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
			DOTween.Sequence().Append(DOTween.To(() => weight, delegate(float x)
			{
				blur.weight = x;
			}, 0f, 2.2f).SetEase(Ease.OutExpo)).Play();
			break;
		case 1:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_Notification);
			DOTween.Sequence().Append(DOTween.To(() => weight, delegate(float x)
			{
				blur.weight = x;
			}, 1f, 0.2f).SetEase(Ease.InExpo)).AppendCallback(delegate
			{
				Right.sprite = Twilight;
				Left.sprite = Twilight;
			})
				.Append(DOTween.To(() => weight, delegate(float x)
				{
					blur.weight = x;
				}, 0f, 3.2f).SetEase(Ease.OutExpo))
				.Play();
			break;
		case 2:
		case 3:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_Notification);
			DOTween.Sequence().Append(DOTween.To(() => weight, delegate(float x)
			{
				blur.weight = x;
			}, 1f, 0.2f).SetEase(Ease.InExpo)).AppendCallback(delegate
			{
				Right.sprite = Night;
				Left.sprite = Night;
			})
				.Append(DOTween.To(() => weight, delegate(float x)
				{
					blur.weight = x;
				}, 0f, 3.2f).SetEase(Ease.OutExpo))
				.Play();
			break;
		}
	}

	private void dayPass()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
	}
}
