using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class MoveAndScalableObject : MovableObject
{
	public int _firstWidth = 600;

	public int _firstHeight = 600;

	public const float MINHEIGHT = 60f;

	public const float MINWIDTH = 120f;

	[SerializeField]
	protected Button _leftBottomPoint;

	[SerializeField]
	protected Button _rightBottomPoint;

	[SerializeField]
	protected Button _rightTopPoint;

	[SerializeField]
	protected Button _leftTopPoint;

	[SerializeField]
	protected Button _BottomEdge;

	[SerializeField]
	protected Button _RightEdge;

	[SerializeField]
	protected Button _LeftEdge;

	[SerializeField]
	protected Button _TopEdge;

	[SerializeField]
	private Texture2D _horizontal;

	[SerializeField]
	private Texture2D _vertical;

	[SerializeField]
	private Texture2D _diagonal1;

	[SerializeField]
	private Texture2D _diagonal2;

	public override void Awake()
	{
		base.Awake();
		rect.sizeDelta = new Vector2(_firstWidth, _firstHeight);
		(from _ in _BottomEdge.OnBeginDragAsObservable().SelectMany(_BottomEdge.OnDragAsObservable()).TakeUntil(_BottomEdge.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _BottomEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: false, isVertical: true);
		}).AddTo(_BottomEdge);
		(from _ in _TopEdge.OnBeginDragAsObservable().SelectMany(_TopEdge.OnDragAsObservable()).TakeUntil(_TopEdge.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _TopEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: false, isVertical: true, isRight: true, isBottom: false);
		}).AddTo(_TopEdge);
		(from _ in _RightEdge.OnBeginDragAsObservable().SelectMany(_RightEdge.OnDragAsObservable()).TakeUntil(_RightEdge.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _RightEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: false);
		}).AddTo(_RightEdge);
		(from _ in _LeftEdge.OnBeginDragAsObservable().SelectMany(_LeftEdge.OnDragAsObservable()).TakeUntil(_LeftEdge.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _LeftEdge)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: false, isRight: false);
		}).AddTo(_LeftEdge);
		(from _ in _rightBottomPoint.OnBeginDragAsObservable().SelectMany(_rightBottomPoint.OnDragAsObservable()).TakeUntil(_rightBottomPoint.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _rightBottomPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: true);
		}).AddTo(_rightBottomPoint);
		(from _ in _leftBottomPoint.OnBeginDragAsObservable().SelectMany(_leftBottomPoint.OnDragAsObservable()).TakeUntil(_leftBottomPoint.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _leftBottomPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: true, isRight: false);
		}).AddTo(_leftBottomPoint);
		(from _ in _rightTopPoint.OnBeginDragAsObservable().SelectMany(_rightTopPoint.OnDragAsObservable()).TakeUntil(_rightTopPoint.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _rightTopPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: true, isRight: true, isBottom: false);
		}).AddTo(_rightTopPoint);
		(from _ in _leftTopPoint.OnBeginDragAsObservable().SelectMany(_leftTopPoint.OnDragAsObservable()).TakeUntil(_leftTopPoint.OnEndDragAsObservable())
				.TakeWhile((PointerEventData e) => _leftTopPoint)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 p)
		{
			OnResize(p, isHorizontal: true, isVertical: true, isRight: false, isBottom: false);
		}).AddTo(_leftTopPoint);
	}

	public float AreaSize()
	{
		return rect.sizeDelta.x * rect.sizeDelta.y;
	}

	public void OnResize(Vector3 position, bool isHorizontal, bool isVertical, bool isRight = true, bool isBottom = true)
	{
		if (_isMovable)
		{
			float x = position.x;
			float y = position.y;
			float x2 = rect.sizeDelta.x;
			float y2 = rect.sizeDelta.y;
			float y3 = (isBottom ? 1f : 0f);
			float num = (float)Screen.width / 1920f;
			if (!isRight)
			{
				rect.SetPivotWithKeepingPosition(1f, y3);
				x2 = (isHorizontal ? (rect.anchoredPosition.x + 242f - Mathf.Abs(x) / num) : rect.sizeDelta.x);
			}
			else
			{
				rect.SetPivotWithKeepingPosition(0f, y3);
				x2 = (isHorizontal ? (0f - (rect.anchoredPosition.x + 242f) + Mathf.Abs(x) / num) : rect.sizeDelta.x);
			}
			y2 = ((!isBottom) ? (isVertical ? (0f - rect.anchoredPosition.y - ((float)Screen.height - y) / num) : rect.sizeDelta.y) : (isVertical ? (rect.anchoredPosition.y + ((float)Screen.height - y) / num) : rect.sizeDelta.y));
			x2 = Mathf.Max(x2, 120f);
			y2 = Mathf.Max(y2, 60f);
			rect.sizeDelta = new Vector2(x2, y2);
			rect.SetPivotWithKeepingPosition(0f, 1f);
		}
	}
}
