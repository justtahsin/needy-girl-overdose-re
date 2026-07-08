using System;
using UniRx;
using UnityEngine;

namespace ngov3;

public interface ILayoutElement2D
{
	LayoutElement2DType LayoutElement2DType { get; }

	RectTransform RectTransform { get; }

	IObservable<Unit> OnDestroyObservable { get; }
}
