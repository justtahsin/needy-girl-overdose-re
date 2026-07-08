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
		rect = GetComponent<RectTransform>();
		parentRect = base.transform.parent.GetComponent<RectTransform>();
		_cover.OnClickAsObservable().Subscribe(delegate
		{
			Touched();
		}).AddTo(_cover);
		_MovableGrabber.OnBeginDragAsObservable2D.Subscribe(delegate
		{
			Touched();
		}).AddTo(base.gameObject);
		(from _ in _MovableGrabber.OnBeginDragAsObservable2D.Where((PointerEventData e) => rect).SelectMany(_MovableGrabber.OnDragAsObservable2D).TakeUntil(_MovableGrabber.OnEndDragAsObservable2D)
				.TakeWhile((PointerEventData e) => rect)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).Pairwise().RepeatUntilDestroy(this).Subscribe(OnDrag)
			.AddTo(_MovableGrabber);
	}

	protected virtual void OnDrag(Pair<Vector3> positions)
	{
		SetHomingPos(positions);
	}

	public virtual void Touched()
	{
	}

	protected virtual void SetHomingPos(Pair<Vector3> positions)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(positions.Previous);
		Vector3 vector2 = Camera.main.ScreenToWorldPoint(positions.Current);
		Vector3 vector3 = vector - vector2;
		base.transform.position = base.transform.position - vector3;
		float x = rect.localPosition.x;
		float y = rect.localPosition.y;
		float f = Mathf.Clamp(x, LeftBorder, RightBorder);
		float f2 = Mathf.Clamp(y, UnderBorder, BelowBorder);
		rect.localPosition = new Vector3(Mathf.Round(f), Mathf.Round(f2), rect.localPosition.z);
	}
}
