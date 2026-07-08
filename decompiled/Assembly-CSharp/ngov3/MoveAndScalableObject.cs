using System;
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		base.Awake();
		rect.sizeDelta = new Vector2((float)_firstWidth, (float)_firstHeight);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_BottomEdge), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_BottomEdge)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_BottomEdge)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_BottomEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: false, isVertical: true);
		}), (Component)(object)_BottomEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_TopEdge), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_TopEdge)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_TopEdge)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_TopEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: false, isVertical: true, isRight: true, isBottom: false);
		}), (Component)(object)_TopEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_RightEdge), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_RightEdge)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_RightEdge)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_RightEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: false);
		}), (Component)(object)_RightEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_LeftEdge), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_LeftEdge)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_LeftEdge)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_LeftEdge))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: false, isRight: false);
		}), (Component)(object)_LeftEdge);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_rightBottomPoint), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_rightBottomPoint)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_rightBottomPoint)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_rightBottomPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: true);
		}), (Component)(object)_rightBottomPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_leftBottomPoint), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_leftBottomPoint)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_leftBottomPoint)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_leftBottomPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: true, isRight: false);
		}), (Component)(object)_leftBottomPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_rightTopPoint), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_rightTopPoint)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_rightTopPoint)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_rightTopPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: true, isRight: true, isBottom: false);
		}), (Component)(object)_rightTopPoint);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(ObservableTriggerExtensions.OnBeginDragAsObservable((UIBehaviour)(object)_leftTopPoint), ObservableTriggerExtensions.OnDragAsObservable((UIBehaviour)(object)_leftTopPoint)), ObservableTriggerExtensions.OnEndDragAsObservable((UIBehaviour)(object)_leftTopPoint)), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)_leftTopPoint))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 p)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			OnResize(p, isHorizontal: true, isVertical: true, isRight: false, isBottom: false);
		}), (Component)(object)_leftTopPoint);
	}

	public float AreaSize()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return rect.sizeDelta.x * rect.sizeDelta.y;
	}

	public void OnResize(Vector3 position, bool isHorizontal, bool isVertical, bool isRight = true, bool isBottom = true)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
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
