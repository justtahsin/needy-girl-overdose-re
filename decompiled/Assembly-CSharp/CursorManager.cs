using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : SingletonMonoBehaviour<CursorManager>
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CMoveToAsync_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public CursorManager _003C_003E4__this;

		public Vector3 position;

		public float duration;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			CursorManager cursorManager = _003C_003E4__this;
			try
			{
				TweenAwaiter val3;
				if (num != 0)
				{
					Vector2 val = RectTransformUtility.WorldToScreenPoint(cursorManager.cameraMain, position);
					Vector2 val2 = default(Vector2);
					RectTransformUtility.ScreenPointToLocalPointInRectangle(cursorManager._boundaries, val, cursorManager.cameraMain, ref val2);
					val3 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMove((Transform)(object)cursorManager._cursorRect, Vector2.op_Implicit(val2), duration, false)));
					if (!((TweenAwaiter)(ref val3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val3;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CMoveToAsync_003Ed__26>(ref val3, ref this);
						return;
					}
				}
				else
				{
					val3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TweenAwaiter)(ref val3)).GetResult();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

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

	public Vector3 CursorWorldPosition => Vector2.op_Implicit(RectTransformUtility.WorldToScreenPoint(cameraMain, Input.mousePosition));

	protected override void Awake()
	{
		base.Awake();
		_player = ReInput.players.GetPlayer(0);
	}

	private void Start()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		DisableLiveCursorMode();
		_defaultCursorTexture = cursorImage.sprite.texture;
		ref Vector2 minPos = ref _minPos;
		Rect rect = _boundaries.rect;
		minPos.x = ((Rect)(ref rect)).width / 2f * -1f;
		ref Vector2 maxPos = ref _maxPos;
		rect = _boundaries.rect;
		maxPos.x = ((Rect)(ref rect)).width / 2f - 10f;
		ref Vector2 minPos2 = ref _minPos;
		rect = _boundaries.rect;
		minPos2.y = ((Rect)(ref rect)).height / 2f * -1f + 5f;
		ref Vector2 maxPos2 = ref _maxPos;
		rect = _boundaries.rect;
		maxPos2.y = ((Rect)(ref rect)).height / 2f;
	}

	private void Update()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Cursor.SetCursor(texture, hotspot, cursorMode);
	}

	[AsyncStateMachine(typeof(_003CMoveToAsync_003Ed__26))]
	public UniTaskVoid MoveToAsync(Vector3 position, float duration)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CMoveToAsync_003Ed__26 _003CMoveToAsync_003Ed__27 = default(_003CMoveToAsync_003Ed__26);
		_003CMoveToAsync_003Ed__27._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CMoveToAsync_003Ed__27._003C_003E4__this = this;
		_003CMoveToAsync_003Ed__27.position = position;
		_003CMoveToAsync_003Ed__27.duration = duration;
		_003CMoveToAsync_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CMoveToAsync_003Ed__27._003C_003Et__builder)).Start<_003CMoveToAsync_003Ed__26>(ref _003CMoveToAsync_003Ed__27);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CMoveToAsync_003Ed__27._003C_003Et__builder)).Task;
	}

	public void SetCursorShowHide(bool show)
	{
		((Behaviour)cursorImage).enabled = show;
	}

	public void MoveCursorToCenter()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_cursorRect.anchoredPosition = Vector2.zero;
	}
}
