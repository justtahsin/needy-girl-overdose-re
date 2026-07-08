using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(Fader2D))]
public class Tooltip2D : MonoBehaviour, ITooltip, IFader
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDOFade_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Tooltip2D _003C_003E4__this;

		public float duration;

		public float endValue;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Tooltip2D tooltip2D = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = tooltip2D.fader2D.DOFade(duration, endValue, cancellationToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDOFade_003Ed__21>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	protected float RIGHTBORDER = 9f;

	protected float LEFTBORDER = -9f;

	protected float DOWNBORDER = -5f;

	protected float UPBORDER = 5f;

	[SerializeField]
	private SpriteRenderer icon;

	[SerializeField]
	private TMP_Text speaker;

	[SerializeField]
	private TMP_Text contentText;

	[SerializeField]
	private Sprite osIcon;

	[SerializeField]
	private Sprite ameIcon;

	[SerializeField]
	protected RectTransform rect;

	[SerializeField]
	private RectTransform baloonRect;

	[SerializeField]
	protected RectTransform leftUp;

	[SerializeField]
	protected RectTransform rightDown;

	[SerializeField]
	private Fader2D fader2D;

	protected RectTransform BaloonRect => baloonRect;

	public void SetData(TooltipType type, Vector3 pos, bool isHoming, string nakamiText = "")
	{
		if (type == TooltipType.None)
		{
			contentText.text = nakamiText;
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			return;
		}
		TooltipMaster.Param toolTip = NgoEx.getToolTip(type);
		contentText.text = NgoEx.GetToolTipText(toolTip, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		if (toolTip.Speaker == "Os")
		{
			icon.sprite = osIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Os, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if ((Object)(object)icon != (Object)null)
		{
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	public void Awake()
	{
		rect = ((Component)this).GetComponent<RectTransform>();
	}

	public virtual void SetHomingPos()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)rect == (Object)null))
		{
			SetBaloonPos();
			Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
			Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
			position.z = ((Transform)rect).position.z;
			((Transform)rect).position = position;
			float num = Mathf.Max(((Transform)rightDown).position.x - RIGHTBORDER, 0f);
			float num2 = Mathf.Max(((Transform)leftUp).position.y - UPBORDER, 0f);
			if (num > 0f || num2 > 0f)
			{
				position.x -= num;
				position.y -= num2;
				((Transform)rect).position = position;
			}
		}
	}

	public void SetPos(Vector3 pos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localPosition = pos;
	}

	public virtual void SetBaloonPos()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)BaloonRect != (Object)null)
		{
			BaloonRect.anchoredPosition = new Vector2(BaloonRect.sizeDelta.x / 2f, BaloonRect.sizeDelta.y / 2f);
		}
	}

	[AsyncStateMachine(typeof(_003CDOFade_003Ed__21))]
	public UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		_003CDOFade_003Ed__21 _003CDOFade_003Ed__22 = default(_003CDOFade_003Ed__21);
		_003CDOFade_003Ed__22._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDOFade_003Ed__22._003C_003E4__this = this;
		_003CDOFade_003Ed__22.duration = duration;
		_003CDOFade_003Ed__22.endValue = endValue;
		_003CDOFade_003Ed__22.cancellationToken = cancellationToken;
		_003CDOFade_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__22._003C_003Et__builder)).Start<_003CDOFade_003Ed__21>(ref _003CDOFade_003Ed__22);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__22._003C_003Et__builder)).Task;
	}

	public void SetAlpha(float alpha)
	{
		fader2D.SetAlpha(alpha);
	}
}
