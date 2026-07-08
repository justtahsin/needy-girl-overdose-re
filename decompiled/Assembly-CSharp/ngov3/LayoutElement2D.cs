using System;
using UniRx;
using UnityEngine;

namespace ngov3;

public class LayoutElement2D : MonoBehaviour, ILayoutElement2D
{
	[SerializeField]
	private LayoutElement2DType layoutElement2DType;

	private RectTransform rect;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	public LayoutElement2DType LayoutElement2DType => layoutElement2DType;

	public RectTransform RectTransform => rect;

	public IObservable<Unit> OnDestroyObservable => onDestroySubject;

	private void OnDestroy()
	{
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
	}

	private void Awake()
	{
		rect = GetComponent<RectTransform>();
	}
}
