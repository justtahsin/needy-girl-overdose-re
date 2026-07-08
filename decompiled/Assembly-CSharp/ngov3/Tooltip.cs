using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Tooltip : MonoBehaviour, ITooltip, IFader
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDOFade_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Tooltip _003C_003E4__this;

		public float endValue;

		public float duration;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Tooltip tooltip = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = DOTweenAsyncExtensions.WithCancellation((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(tooltip.canvas, endValue, duration)), cancellationToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDOFade_003Ed__17>(ref val2, ref this);
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

	protected float RIGHTBORDER;

	protected float LEFTBORDER = 1436f;

	protected float BELOWBORDER;

	protected float UNDERBORDER = 1080f;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private TMP_Text speaker;

	[SerializeField]
	private TMP_Text contentText;

	[SerializeField]
	private Sprite osIcon;

	[SerializeField]
	private Sprite ameIcon;

	[SerializeField]
	public CanvasGroup canvas;

	[SerializeField]
	public RectTransform rect;

	public bool isHoming = true;

	public void Awake()
	{
		rect = ((Component)this).GetComponent<RectTransform>();
	}

	public void SetPos(Vector3 pos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localPosition = pos;
	}

	public virtual void SetHomingPos()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
		cursorPosition.z = 10f;
		Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
		((Component)this).transform.position = position;
		float x = ((Transform)rect).localPosition.x;
		float y = ((Transform)rect).localPosition.y;
		float num = Mathf.Clamp(x, RIGHTBORDER, LEFTBORDER - rect.sizeDelta.x);
		float num2 = Mathf.Clamp(y, BELOWBORDER + rect.sizeDelta.y, UNDERBORDER);
		((Transform)rect).localPosition = new Vector3(Mathf.Round(num), Mathf.Round(num2), 0f);
	}

	public void SetData(TooltipType type, Vector3 pos, bool isHoming, string nakamiText = "")
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		if (type == TooltipType.None)
		{
			contentText.text = nakamiText;
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			TooltipMaster.Param toolTip = NgoEx.getToolTip(type);
			contentText.text = NgoEx.GetToolTipText(toolTip, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			if (toolTip.Speaker == "Os")
			{
				icon.sprite = osIcon;
				speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Os, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				icon.sprite = ameIcon;
				speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
		SetPos(pos);
	}

	public void SetBaloonPos()
	{
	}

	[AsyncStateMachine(typeof(_003CDOFade_003Ed__17))]
	public UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		_003CDOFade_003Ed__17 _003CDOFade_003Ed__18 = default(_003CDOFade_003Ed__17);
		_003CDOFade_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDOFade_003Ed__18._003C_003E4__this = this;
		_003CDOFade_003Ed__18.duration = duration;
		_003CDOFade_003Ed__18.endValue = endValue;
		_003CDOFade_003Ed__18.cancellationToken = cancellationToken;
		_003CDOFade_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__18._003C_003Et__builder)).Start<_003CDOFade_003Ed__17>(ref _003CDOFade_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__18._003C_003Et__builder)).Task;
	}

	public void SetAlpha(float alpha)
	{
		canvas.alpha = alpha;
	}
}
