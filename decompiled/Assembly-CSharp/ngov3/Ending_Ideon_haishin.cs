using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Ideon_haishin : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Ideon_haishin _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Ideon_haishin ending_Ideon_haishin = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_ideon);
					UniTask val = ((LiveScenario)ending_Ideon_haishin).StartScenario();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__4>(ref val2, ref this);
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
				PostEffectManager.Instance.SetShader(EffectType.SatujinNoise);
				SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Ideon_afterHaishin>();
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

	private bool isEnd;

	private int light;

	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		((Component)_Live._HaisinSkip).gameObject.SetActive(false);
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
		{
			_Live.Speed = 3;
		}
		else
		{
			_Live.Speed = 0;
		}
		((Component)_Live._HaisinSpeed).gameObject.SetActive(false);
		_Live.SetSpeedLock(isLock: true);
		_Live.isGuideEnable = false;
		SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		title = NgoEx.TenTalk("Ideon_000", _lang);
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide_in"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_004", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_005", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide2_loop"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_007", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_reaction1"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end000", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end001", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_010", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_017", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end023", _lang)));
		playing.Add(new Playing(ChanceEffectType.Ide, "ide_invoke"));
		playing.Add(new Playing(SoundType.SE_ideonSound, isloop: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_020", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_021", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ide_invoke"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
	}

	private void Update()
	{
		light++;
		if (isEnd && light > 1200)
		{
			PostEffectManager.Instance.SetShaderWeight((float)(light - 1200) / 100f);
		}
		else
		{
			PostEffectManager.Instance.SetShaderWeight(0f);
		}
	}

	[AsyncStateMachine(typeof(_003CStartScenario_003Ed__4))]
	public override UniTask StartScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartScenario_003Ed__4 _003CStartScenario_003Ed__5 = default(_003CStartScenario_003Ed__4);
		_003CStartScenario_003Ed__5._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartScenario_003Ed__5._003C_003E4__this = this;
		_003CStartScenario_003Ed__5._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__5._003C_003Et__builder)).Start<_003CStartScenario_003Ed__4>(ref _003CStartScenario_003Ed__5);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__5._003C_003Et__builder)).Task;
	}
}
