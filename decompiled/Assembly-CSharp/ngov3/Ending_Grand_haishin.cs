using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ngov3;

public class Ending_Grand_haishin : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Grand_haishin _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Grand_haishin ending_Grand_haishin = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0124;
					}
					AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
					PostEffectManager.Instance.SetShader(EffectType.BloomLight);
					PostEffectManager.Instance.SetShaderWeight(0.17f);
					val2 = ((LiveScenario)ending_Grand_haishin).StartScenario();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__3>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				AchievementStatsUpdater.UpdateStats("Ending_Grand");
				SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
				val2 = UniTask.Delay(Constants.SLOW * 200, false, (PlayerLoopTiming)8, default(CancellationToken), false);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__3>(ref val, ref this);
					return;
				}
				goto IL_0124;
				IL_0124:
				((Awaiter)(ref val)).GetResult();
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

	private Bloom _bloomLight;

	protected override void Awake()
	{
		base.Awake();
		PostEffectManager.Instance.BloomLight.profile.TryGet<Bloom>(ref _bloomLight);
		title = "";
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend1"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend2"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin003", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend3"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_grandend3"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
	}

	private void Update()
	{
		((VolumeParameter<float>)(object)_bloomLight.intensity).value = 6f + Random.Range(0f, 4f);
	}

	[AsyncStateMachine(typeof(_003CStartScenario_003Ed__3))]
	public override UniTask StartScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartScenario_003Ed__3 _003CStartScenario_003Ed__4 = default(_003CStartScenario_003Ed__3);
		_003CStartScenario_003Ed__4._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartScenario_003Ed__4._003C_003E4__this = this;
		_003CStartScenario_003Ed__4._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__4._003C_003Et__builder)).Start<_003CStartScenario_003Ed__3>(ref _003CStartScenario_003Ed__4);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__4._003C_003Et__builder)).Task;
	}
}
