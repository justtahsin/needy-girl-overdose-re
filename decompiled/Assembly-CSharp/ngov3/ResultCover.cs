using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ResultCover : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _cover;

	[SerializeField]
	private RectTransform _obi;

	[SerializeField]
	private Button _next;

	[SerializeField]
	private TMP_Text _buttonLabel;

	[SerializeField]
	private TMP_Text _message;

	private Sequence sequence;

	public void Awake()
	{
		_next.OnClickAsObservable().Subscribe(delegate
		{
			EndResult();
		}).AddTo(_next);
	}

	public void StartResult(string message)
	{
		SingletonMonoBehaviour<EventManager>.Instance.isResulting.Value = true;
		DOTween.Sequence().OnStart(delegate
		{
			_cover.alpha = 0f;
			_cover.interactable = true;
			_cover.blocksRaycasts = true;
			_obi.localPosition = new Vector3(0f, 0f, 0f);
			_next.transform.localPosition = new Vector3(720f, 0f, 0f);
			_cover.gameObject.transform.SetAsLastSibling();
			_message.text = message;
		}).Append(_cover.DOFade(1f, 0.4f))
			.Append(_obi.DOLocalMoveY(980f, 0.4f, snapping: true).SetEase(Ease.InOutBounce))
			.AppendCallback(delegate
			{
				IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManagerforResult);
				SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
			})
			.Append(_next.transform.DOLocalMoveY(160f, 0.4f, snapping: true))
			.OnComplete(delegate
			{
				_cover.interactable = true;
			})
			.Play();
	}

	public async UniTask EndResult()
	{
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		await UniTask.Delay(800);
		_cover.interactable = false;
		_cover.blocksRaycasts = false;
		await _cover.DOFade(0f, 0.1f).Play();
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManagerforResult));
		SingletonMonoBehaviour<EventManager>.Instance.isResulting.Value = false;
	}
}
