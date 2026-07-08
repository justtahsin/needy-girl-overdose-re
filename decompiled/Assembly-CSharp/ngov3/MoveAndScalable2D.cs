using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

[RequireComponent(typeof(RectSizeChangerFromCursorPostion))]
[RequireComponent(typeof(RectSizeSyncSpriteRendererSizeExtensions))]
public class MoveAndScalable2D : MovableObject2D
{
	public int _firstWidth = 600;

	public int _firstHeight = 600;

	public const float MINHEIGHT = 60f;

	public const float MINWIDTH = 120f;

	[SerializeField]
	protected DraggableObject _leftBottomPoint;

	[SerializeField]
	protected DraggableObject _rightBottomPoint;

	[SerializeField]
	protected DraggableObject _rightTopPoint;

	[SerializeField]
	protected DraggableObject _leftTopPoint;

	[SerializeField]
	protected DraggableObject _BottomEdge;

	[SerializeField]
	protected DraggableObject _RightEdge;

	[SerializeField]
	protected DraggableObject _LeftEdge;

	[SerializeField]
	protected DraggableObject _TopEdge;

	protected override void Awake()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		base.Awake();
		RectSizeChangerFromCursorPostion rectSizeChangerFromCursorPostion = ((Component)this).GetComponent<RectSizeChangerFromCursorPostion>();
		rect.sizeDelta = new Vector2((float)_firstWidth, (float)_firstHeight);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(Observable.Merge<PointerEventData>(_leftBottomPoint.OnEndDragAsObservable2D, Array.Empty<IObservable<PointerEventData>>()), new IObservable<PointerEventData>[1] { _rightBottomPoint.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _rightTopPoint.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _leftTopPoint.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _BottomEdge.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _RightEdge.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _LeftEdge.OnEndDragAsObservable2D }), new IObservable<PointerEventData>[1] { _TopEdge.OnEndDragAsObservable2D }), (Action<PointerEventData>)delegate
		{
			rectSizeChangerFromCursorPostion.RestCursorPostion();
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_BottomEdge.OnBeginDragAsObservable2D, _BottomEdge.OnDragAsObservable2D), _BottomEdge.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_BottomEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.TOP);
		}), (Component)(object)_BottomEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_TopEdge.OnBeginDragAsObservable2D, _TopEdge.OnDragAsObservable2D), _TopEdge.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_TopEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.BOTTOM);
		}), (Component)(object)_TopEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_RightEdge.OnBeginDragAsObservable2D, _RightEdge.OnDragAsObservable2D), _RightEdge.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_RightEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.LEFT);
		}), (Component)(object)_RightEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_LeftEdge.OnBeginDragAsObservable2D, _LeftEdge.OnDragAsObservable2D), _LeftEdge.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_LeftEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.RIGHT);
		}), (Component)(object)_LeftEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_rightBottomPoint.OnBeginDragAsObservable2D, _rightBottomPoint.OnDragAsObservable2D), _rightBottomPoint.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_rightBottomPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.TOP_LEFT);
		}), (Component)(object)_rightBottomPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_leftBottomPoint.OnBeginDragAsObservable2D, _leftBottomPoint.OnDragAsObservable2D), _leftBottomPoint.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_leftBottomPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.TOP_RIGHT);
		}), (Component)(object)_leftBottomPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_rightTopPoint.OnBeginDragAsObservable2D, _rightTopPoint.OnDragAsObservable2D), _rightTopPoint.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_rightTopPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.BOTTOM_LEFT);
		}), (Component)(object)_rightTopPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(_leftTopPoint.OnBeginDragAsObservable2D, _leftTopPoint.OnDragAsObservable2D), _leftTopPoint.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_leftTopPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(Vector2.op_Implicit(p), RectSizeSyncPivot.BOTTOM_RIGHT);
		}), (Component)(object)_leftTopPoint);
	}
}
