using System;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class MovableObject : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	public Texture2D handCursor;

	protected float _firstPosx;

	protected float _firstPosy;

	public const float RIGHTBORDER = 0f;

	public const float LEFTBORDER = 1436f;

	public const float BELOWBORDER = 60f;

	public const float UNDERBORDER = 1080f;

	private Vector2 deltaValue = Vector2.zero;

	[SerializeField]
	protected Button _MovableGrabber;

	[SerializeField]
	protected Button _cover;

	protected RectTransform rect;

	protected float scaleFactor = 1f;

	protected bool _isMovable = true;

	private RectTransform parentRect;

	public virtual void Awake()
	{
		if ((Object)(object)SingletonMonoBehaviour<WindowManager>.Instance.MainCanvas != (Object)null)
		{
			scaleFactor = SingletonMonoBehaviour<WindowManager>.Instance.MainCanvas.scaleFactor;
		}
		else
		{
			scaleFactor = ((Component)this).GetComponentInParent<Canvas>().scaleFactor;
		}
		rect = ((Component)this).GetComponent<RectTransform>();
		Transform transform = ((Component)((Transform)rect).parent).transform;
		parentRect = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		Button cover = _cover;
		if (cover != null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(cover), (Action<Unit>)delegate
			{
				Touched();
			}), (Component)(object)_cover);
		}
		Button movableGrabber = _MovableGrabber;
		if (movableGrabber != null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(movableGrabber), (Action<Unit>)delegate
			{
				Touched();
			}), (Component)(object)_MovableGrabber);
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(ObservableTriggerExtensions.OnRectTransformDimensionsChangeAsObservable((Component)(object)parentRect), (Action<Unit>)delegate
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			AdjustPosition(((Transform)rect).localPosition.x, ((Transform)rect).localPosition.y);
		}), (Component)(object)_MovableGrabber);
	}

	protected void setInteractiveCursor()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(handCursor, Vector2.zero, (CursorMode)0);
	}

	protected void setNormalCursor()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, (CursorMode)0);
	}

	public virtual void Touched()
	{
	}

	public void OnBeginDrag(PointerEventData _data)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		deltaValue = Vector2.zero;
		AudioManager.Instance.PlaySeByType(SoundType.SE_pill_guiiin);
	}

	public void OnEndDrag(PointerEventData _data)
	{
		if (_isMovable)
		{
			AudioManager.Instance.StopByType(SoundType.SE_pill_guiiin);
			AudioManager.Instance.PlaySeByType(SoundType.SE_poko);
		}
	}

	public void OnDrag(PointerEventData data)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (_isMovable)
		{
			deltaValue = data.delta;
			float nowx = ((Transform)rect).localPosition.x + deltaValue.x;
			float nowy = ((Transform)rect).localPosition.y + deltaValue.y;
			AdjustPosition(nowx, nowy);
		}
	}

	private void AdjustPosition(float nowx, float nowy)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		Rect val = parentRect.rect;
		float num = Mathf.Clamp(nowx, 0f, ((Rect)(ref val)).width);
		val = parentRect.rect;
		float num2 = Mathf.Clamp(nowy, 60f, ((Rect)(ref val)).height);
		((Transform)rect).localPosition = new Vector3(Mathf.Round(num), Mathf.Round(num2), ((Transform)rect).localPosition.z);
	}
}
