using System;
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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_plusLove), (Action<Unit>)delegate
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 10);
		}), (Component)(object)_plusLove);
	}
}
