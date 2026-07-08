using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;
using UnityEngine.Rendering;

namespace ngov3;

public class Ending_DarkAngel_haishin : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_DarkAngel_haishin _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_DarkAngel_haishin ending_DarkAngel_haishin = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
					((Behaviour)GameObject.Find("InvertVolume").GetComponent<Volume>()).enabled = true;
					UniTask val = ((LiveScenario)ending_DarkAngel_haishin).StartScenario();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val2, ref this);
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
				NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
				AchievementStatsUpdater.UpdateStats("Ending_DarkAngel");
				SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
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

	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		defaultEffectType = EffectType.GoCrazy;
		title = "";
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_idle2_1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_idle2_2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel035", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel040", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_neckcut"));
		playing.Add(new Playing(SoundType.SE_zubasi, isloop: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel041", _lang)));
	}

	[AsyncStateMachine(typeof(_003CStartScenario_003Ed__1))]
	public override UniTask StartScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartScenario_003Ed__1 _003CStartScenario_003Ed__2 = default(_003CStartScenario_003Ed__1);
		_003CStartScenario_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartScenario_003Ed__2._003C_003E4__this = this;
		_003CStartScenario_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__2._003C_003Et__builder)).Start<_003CStartScenario_003Ed__1>(ref _003CStartScenario_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__2._003C_003Et__builder)).Task;
	}
}
