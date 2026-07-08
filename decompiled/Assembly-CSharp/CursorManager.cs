using Cysharp.Threading.Tasks;
using DG.Tweening;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : SingletonMonoBehaviour<CursorManager>
{
	[Header("\ufffdV\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffd\u0303J\ufffd\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdZ\ufffdb\ufffdg")]
	public Camera cameraMain;

	[Header("\ufffdJ\ufffd[\ufffd\ufffd\ufffd\ufffdړ\ufffd\ufffdX\ufffds\ufffd[\ufffdh")]
	[SerializeField]
	private float _horizontalSpeed = 800f;

	[SerializeField]
	private float _verticalSpeed = 800f;

	[SerializeField]
	private float _slowMoveRate = 0.5f;

	[SerializeField]
	[Header("\ufffdJ\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffdRectTransform")]
	private RectTransform _cursorRect;

	[SerializeField]
	private SwitchInputModule inputModule;

	[SerializeField]
	private Rigidbody2D rigidbody2;

	[Header("\ufffdJ\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffdImage")]
	[SerializeField]
	private Image cursorImage;

	private Texture2D _defaultCursorTexture;

	[Header("\ufffd\ufffdʒ[\ufffd\ufffd\ufffdf\ufffdpRect")]
	[SerializeField]
	private RectTransform _boundaries;

	private Vector2 _minPos = Vector2.zero;

	private Vector2 _maxPos = Vector2.zero;

	private float _movementX;

	private float _movementY;

	private Player _player;

	private Vector3 tPos2;

	public Vector3 CursorPosition => Input.mousePosition;

	public Vector3 CursorWorldPosition => RectTransformUtility.WorldToScreenPoint(cameraMain, Input.mousePosition);

	protected override void Awake()
	{
		base.Awake();
		_player = ReInput.players.GetPlayer(0);
	}

	private void Start()
	{
		DisableLiveCursorMode();
		_defaultCursorTexture = cursorImage.sprite.texture;
		_minPos.x = _boundaries.rect.width / 2f * -1f;
		_maxPos.x = _boundaries.rect.width / 2f - 10f;
		_minPos.y = _boundaries.rect.height / 2f * -1f + 5f;
		_maxPos.y = _boundaries.rect.height / 2f;
	}

	private void Update()
	{
		tPos2 = Input.mousePosition;
		Vector2 anchoredPosition = RectTransformUtility.WorldToScreenPoint(cameraMain, tPos2);
		_cursorRect.anchoredPosition = anchoredPosition;
	}

	public void EnableLiveCursorMode()
	{
		rigidbody2.simulated = true;
	}

	public void DisableLiveCursorMode()
	{
		rigidbody2.simulated = false;
	}

	public void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
	{
		Cursor.SetCursor(texture, hotspot, cursorMode);
	}

	public async UniTaskVoid MoveToAsync(Vector3 position, float duration)
	{
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cameraMain, position);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_boundaries, screenPoint, cameraMain, out var localPoint);
		await _cursorRect.DOLocalMove(localPoint, duration).Play();
	}

	public void SetCursorShowHide(bool show)
	{
		cursorImage.enabled = show;
	}

	public void MoveCursorToCenter()
	{
		_cursorRect.anchoredPosition = Vector2.zero;
	}
}
