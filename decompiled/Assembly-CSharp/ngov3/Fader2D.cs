using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Fader2D : MonoBehaviour, IFader
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDOFade_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Fader2D _003C_003E4__this;

		public float endValue;

		public float duration;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Fader2D CS_0024_003C_003E8__locals2 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = DOTweenAsyncExtensions.WithCancellation((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => CS_0024_003C_003E8__locals2.alpha), (DOSetter<float>)delegate(float alpha)
					{
						CS_0024_003C_003E8__locals2.alpha = alpha;
					}, endValue, duration)), cancellationToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDOFade_003Ed__6>(ref val2, ref this);
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDOFade_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Fader2D _003C_003E4__this;

		public float endValue;

		public float duration;

		public Ease ease;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Fader2D CS_0024_003C_003E8__locals2 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = DOTweenAsyncExtensions.WithCancellation((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => CS_0024_003C_003E8__locals2.alpha), (DOSetter<float>)delegate(float alpha)
					{
						CS_0024_003C_003E8__locals2.alpha = alpha;
					}, endValue, duration), ease)), cancellationToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDOFade_003Ed__7>(ref val2, ref this);
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

	[SerializeField]
	private List<SpriteRenderer> spriteRendererList;

	[SerializeField]
	private List<TMP_Text> textList;

	[SerializeField]
	[Range(0f, 1f)]
	private float alpha = 1f;

	public float Alpha => alpha;

	public void SetAlpha(float alpha)
	{
		this.alpha = alpha;
		spriteRendererList.ForEach(delegate(SpriteRenderer s)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			Color color = s.color;
			color.a = alpha;
			s.color = color;
		});
		textList.ForEach(delegate(TMP_Text t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			Color color = ((Graphic)t).color;
			color.a = alpha;
			((Graphic)t).color = color;
		});
	}

	[AsyncStateMachine(typeof(_003CDOFade_003Ed__6))]
	public UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		_003CDOFade_003Ed__6 _003CDOFade_003Ed__8 = default(_003CDOFade_003Ed__6);
		_003CDOFade_003Ed__8._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDOFade_003Ed__8._003C_003E4__this = this;
		_003CDOFade_003Ed__8.duration = duration;
		_003CDOFade_003Ed__8.endValue = endValue;
		_003CDOFade_003Ed__8.cancellationToken = cancellationToken;
		_003CDOFade_003Ed__8._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__8._003C_003Et__builder)).Start<_003CDOFade_003Ed__6>(ref _003CDOFade_003Ed__8);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__8._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDOFade_003Ed__7))]
	public UniTask DOFade(float duration, float endValue, Ease ease, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		_003CDOFade_003Ed__7 _003CDOFade_003Ed__8 = default(_003CDOFade_003Ed__7);
		_003CDOFade_003Ed__8._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDOFade_003Ed__8._003C_003E4__this = this;
		_003CDOFade_003Ed__8.duration = duration;
		_003CDOFade_003Ed__8.endValue = endValue;
		_003CDOFade_003Ed__8.ease = ease;
		_003CDOFade_003Ed__8.cancellationToken = cancellationToken;
		_003CDOFade_003Ed__8._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__8._003C_003Et__builder)).Start<_003CDOFade_003Ed__7>(ref _003CDOFade_003Ed__8);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDOFade_003Ed__8._003C_003Et__builder)).Task;
	}

	private void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => Alpha))), (Action<float>)delegate(float alpha)
		{
			spriteRendererList.ForEach(delegate(SpriteRenderer s)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				Color color = s.color;
				color.a = alpha;
				s.color = color;
			});
			textList.ForEach(delegate(TMP_Text t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				Color color = ((Graphic)t).color;
				color.a = alpha;
				((Graphic)t).color = color;
			});
		}), ((Component)this).gameObject);
	}
}
