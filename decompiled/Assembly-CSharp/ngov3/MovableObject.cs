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
		if (SingletonMonoBehaviour<WindowManager>.Instance.MainCanvas != null)
		{
			scaleFactor = SingletonMonoBehaviour<WindowManager>.Instance.MainCanvas.scaleFactor;
		}
		else
		{
			scaleFactor = GetComponentInParent<Canvas>().scaleFactor;
		}
		rect = GetComponent<RectTransform>();
		parentRect = rect.parent.transform as RectTransform;
		_cover?.OnClickAsObservable().Subscribe(delegate
		{
			Touched();
		}).AddTo(_cover);
		_MovableGrabber?.OnClickAsObservable().Subscribe(delegate
		{
			Touched();
		}).AddTo(_MovableGrabber);
		parentRect.OnRectTransformDimensionsChangeAsObservable().Subscribe(delegate
		{
			AdjustPosition(rect.localPosition.x, rect.localPosition.y);
		}).AddTo(_MovableGrabber);
	}

	protected void setInteractiveCursor()
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
	}

	protected void setNormalCursor()
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

	public virtual void Touched()
	{
	}

	public void OnBeginDrag(PointerEventData _data)
	{
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
		if (_isMovable)
		{
			deltaValue = data.delta;
			float nowx = rect.localPosition.x + deltaValue.x;
			float nowy = rect.localPosition.y + deltaValue.y;
			AdjustPosition(nowx, nowy);
		}
	}

	private void AdjustPosition(float nowx, float nowy)
	{
		float f = Mathf.Clamp(nowx, 0f, parentRect.rect.width);
		float f2 = Mathf.Clamp(nowy, 60f, parentRect.rect.height);
		rect.localPosition = new Vector3(Mathf.Round(f), Mathf.Round(f2), rect.localPosition.z);
	}
}
