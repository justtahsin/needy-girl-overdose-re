using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

public class MovableObject2D : MonoBehaviour
{
	protected float scaleFactor = 1f;

	protected RectTransform rect;

	private RectTransform parentRect;

	[SerializeField]
	protected DraggableObject _MovableGrabber;

	[SerializeField]
	protected Button2D _cover;

	private float LeftBorder => 0f - (parentRect.sizeDelta.x / 2f - rect.sizeDelta.x / 2f);

	private float RightBorder => parentRect.sizeDelta.x / 2f - rect.sizeDelta.x / 2f;

	private float BelowBorder => parentRect.sizeDelta.y / 2f - rect.sizeDelta.y / 2f;

	private float UnderBorder => 0f - (parentRect.sizeDelta.y / 2f - rect.sizeDelta.y / 2f);

	protected virtual void Awake()
	{
		rect = ((Component)this).GetComponent<RectTransform>();
		parentRect = ((Component)((Component)this).transform.parent).GetComponent<RectTransform>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(_cover.OnClickAsObservable(), (Action<Unit>)delegate
		{
			Touched();
		}), (Component)(object)_cover);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(_MovableGrabber.OnBeginDragAsObservable2D, (Action<PointerEventData>)delegate
		{
			Touched();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Pair<Vector3>>(Observable.RepeatUntilDestroy<Pair<Vector3>>(Observable.Pairwise<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(Observable.Where<PointerEventData>(_MovableGrabber.OnBeginDragAsObservable2D, (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)rect))), _MovableGrabber.OnDragAsObservable2D), _MovableGrabber.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)rect))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition))), (Component)(object)this), (Action<Pair<Vector3>>)OnDrag), (Component)(object)_MovableGrabber);
	}

	protected virtual void OnDrag(Pair<Vector3> positions)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		SetHomingPos(positions);
	}

	public virtual void Touched()
	{
	}

	protected virtual void SetHomingPos(Pair<Vector3> positions)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Camera.main.ScreenToWorldPoint(positions.Previous);
		Vector3 val2 = Camera.main.ScreenToWorldPoint(positions.Current);
		Vector3 val3 = val - val2;
		((Component)this).transform.position = ((Component)this).transform.position - val3;
		float x = ((Transform)rect).localPosition.x;
		float y = ((Transform)rect).localPosition.y;
		float num = Mathf.Clamp(x, LeftBorder, RightBorder);
		float num2 = Mathf.Clamp(y, UnderBorder, BelowBorder);
		((Transform)rect).localPosition = new Vector3(Mathf.Round(num), Mathf.Round(num2), ((Transform)rect).localPosition.z);
	}
}
