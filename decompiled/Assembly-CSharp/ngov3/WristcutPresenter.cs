using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(WristcutView))]
public sealed class WristcutPresenter : MonoBehaviour
{
	private WristcutModel _model;

	private WristcutView _view;

	public void Awake()
	{
		_view = GetComponent<WristcutView>();
		OnStartWristcutGame().Forget();
	}

	public async UniTask OnStartWristcutGame()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		_model = new WristcutModel(status);
		_view.OnStartGame(status, _model.CutCount);
		_view.OnGoButton.Subscribe(_model.OnCut).AddTo(base.gameObject);
		await _view.OnGoButton;
	}
}
