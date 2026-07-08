using System;
using UniRx;
using UnityEngine;

namespace ngov3;

public class PreLoadLayoutElement2D : MonoBehaviour, ILayoutElement2D
{
	[SerializeField]
	private LayoutElement2DType layoutElement2DType;

	[SerializeField]
	private RectTransform rect;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	public LayoutElement2DType LayoutElement2DType => layoutElement2DType;

	public RectTransform RectTransform => rect;

	public IObservable<Unit> OnDestroyObservable => (IObservable<Unit>)onDestroySubject;

	private void OnDestroy()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
	}

	private void Awake()
	{
	}
}
