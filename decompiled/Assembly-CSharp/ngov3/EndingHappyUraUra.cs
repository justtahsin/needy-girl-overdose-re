using Cysharp.Threading.Tasks;
using DG.Tweening;
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
		_uraUraHint.DOFade(1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad)
			.Play();
		Sequence sequence = DOTween.Sequence();
		sequence.OnStart(delegate
		{
			_followers.SetActive(value: false);
			_tweets.SetActive(value: true);
			_tweet1.gameObject.SetActive(value: false);
			_tweet2.gameObject.SetActive(value: false);
			_tweet3.gameObject.SetActive(value: false);
			_tweet4.gameObject.SetActive(value: false);
			_tweet5.gameObject.SetActive(value: false);
		}).AppendCallback(delegate
		{
			_tweet1.gameObject.SetActive(value: true);
		}).Append(_tweet1.DOFade(1f, 2.2f))
			.AppendCallback(delegate
			{
				_tweet2.gameObject.SetActive(value: true);
			})
			.Append(_tweet2.DOFade(1f, 2.2f))
			.AppendCallback(delegate
			{
				_tweet3.gameObject.SetActive(value: true);
			})
			.Append(_tweet3.DOFade(1f, 2.2f))
			.AppendCallback(delegate
			{
				_tweet4.gameObject.SetActive(value: true);
			})
			.Append(_tweet4.DOFade(1f, 2.2f))
			.AppendCallback(delegate
			{
				_tweet5.gameObject.SetActive(value: true);
			})
			.Append(_tweet5.DOFade(1f, 2.2f));
		_uraUraAccount.OnClickAsObservable().Subscribe(delegate
		{
			sequence.Play();
		}).AddTo(_uraUraAccount);
		_followRequest.OnClickAsObservable().Subscribe(async delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
			await UniTask.Delay(Constants.MIDDLE);
			AudioManager.Instance.PlaySeByType(SoundType.SE_Error);
			_blocked.alpha = 1f;
			_blocked.blocksRaycasts = true;
			await UniTask.Delay(Constants.MIDDLE);
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			AchievementStatsUpdater.UpdateStats("Ending_Happy");
		}).AddTo(_followRequest);
	}
}
