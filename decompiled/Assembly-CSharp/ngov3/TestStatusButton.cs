using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TestStatusButton : MonoBehaviour
{
	[SerializeField]
	private Button _plusLove;

	private StatusManager _status;

	public void Awake()
	{
		_plusLove.OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 10);
		}).AddTo(_plusLove);
	}
}
