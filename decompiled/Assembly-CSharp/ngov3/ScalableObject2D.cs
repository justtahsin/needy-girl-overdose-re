using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

[RequireComponent(typeof(RectSizeChangerFromCursorPostion))]
[RequireComponent(typeof(RectSizeSyncSpriteRendererSizeExtensions))]
public class ScalableObject2D : MovableObject2D
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
		base.Awake();
		RectSizeChangerFromCursorPostion rectSizeChangerFromCursorPostion = GetComponent<RectSizeChangerFromCursorPostion>();
		rect.sizeDelta = new Vector2(_firstWidth, _firstHeight);
		_leftBottomPoint.OnEndDragAsObservable2D.Merge().Merge(_rightBottomPoint.OnEndDragAsObservable2D).Merge(_rightTopPoint.OnEndDragAsObservable2D)
			.Merge(_leftTopPoint.OnEndDragAsObservable2D)
			.Merge(_BottomEdge.OnEndDragAsObservable2D)
			.Merge(_RightEdge.OnEndDragAsObservable2D)
			.Merge(_LeftEdge.OnEndDragAsObservable2D)
			.Merge(_TopEdge.OnEndDragAsObservable2D)
			.Subscribe(delegate
			{
				rectSizeChangerFromCursorPostion.RestCursorPostion();
			})
			.AddTo(this);
		(from _ in _BottomEdge.OnBeginDragAsObservable2D.SelectMany(_BottomEdge.OnDragAsObservable2D).TakeUntil(_BottomEdge.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _BottomEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.TOP);
		}).AddTo(_BottomEdge);
		(from _ in _TopEdge.OnBeginDragAsObservable2D.SelectMany(_TopEdge.OnDragAsObservable2D).TakeUntil(_TopEdge.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _TopEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.BOTTOM);
		}).AddTo(_TopEdge);
		(from _ in _RightEdge.OnBeginDragAsObservable2D.SelectMany(_RightEdge.OnDragAsObservable2D).TakeUntil(_RightEdge.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _RightEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.LEFT);
		}).AddTo(_RightEdge);
		(from _ in _LeftEdge.OnBeginDragAsObservable2D.SelectMany(_LeftEdge.OnDragAsObservable2D).TakeUntil(_LeftEdge.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _LeftEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.RIGHT);
		}).AddTo(_LeftEdge);
		(from _ in _rightBottomPoint.OnBeginDragAsObservable2D.SelectMany(_rightBottomPoint.OnDragAsObservable2D).TakeUntil(_rightBottomPoint.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _rightBottomPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.TOP_LEFT);
		}).AddTo(_rightBottomPoint);
		(from _ in _leftBottomPoint.OnBeginDragAsObservable2D.SelectMany(_leftBottomPoint.OnDragAsObservable2D).TakeUntil(_leftBottomPoint.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _leftBottomPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.TOP_RIGHT);
		}).AddTo(_leftBottomPoint);
		(from _ in _rightTopPoint.OnBeginDragAsObservable2D.SelectMany(_rightTopPoint.OnDragAsObservable2D).TakeUntil(_rightTopPoint.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _rightTopPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.BOTTOM_LEFT);
		}).AddTo(_rightTopPoint);
		(from _ in _leftTopPoint.OnBeginDragAsObservable2D.SelectMany(_leftTopPoint.OnDragAsObservable2D).TakeUntil(_leftTopPoint.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => _leftTopPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			rectSizeChangerFromCursorPostion.ChageRectSizeFromCursorPostion(p, RectSizeSyncPivot.BOTTOM_RIGHT);
		}).AddTo(_leftTopPoint);
	}
}
