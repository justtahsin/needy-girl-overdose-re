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
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Live_gen_old : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAwake_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen_old _003C_003E4__this;

		private void MoveNext()
		{
			Live_gen_old CS_0024_003C_003E8__locals20 = _003C_003E4__this;
			try
			{
				CS_0024_003C_003E8__locals20._lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
				CS_0024_003C_003E8__locals20.Speed = SingletonMonoBehaviour<Settings>.Instance.haishinSpeed;
				CS_0024_003C_003E8__locals20.chotenView(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.beta);
				CS_0024_003C_003E8__locals20.bgView();
				CS_0024_003C_003E8__locals20.setSpeed();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals20._HaisinSpeed), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals20.ToggleSpeed();
				}), ((Component)CS_0024_003C_003E8__locals20).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals20._next), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals20.readline();
				}), ((Component)CS_0024_003C_003E8__locals20).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals20._replay), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals20.rewind();
				}), ((Component)CS_0024_003C_003E8__locals20).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals20._reset), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals20.clear();
				}), ((Component)CS_0024_003C_003E8__locals20).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals20._gb), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals20.toggleGB();
				}), ((Component)CS_0024_003C_003E8__locals20).gameObject);
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
	private struct _003CSpeak_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen_old _003C_003E4__this;

		public string nakami;

		public float speed;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Live_gen_old live_gen_old = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num != 0)
				{
					Live_gen_old live_gen_old2 = _003C_003E4__this;
					string beforeText = live_gen_old.jimakuShowing.text;
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						live_gen_old2.jimakuShowing.text = "";
					}), (Tween)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<string, string, StringOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(live_gen_old.jimakuShowing, nakami, (float)nakami.Length * speed, true, (ScrambleMode)0, (string)null), (Ease)1), (TweenCallback)delegate
					{
						string text = live_gen_old2.jimakuShowing.text;
						if (!(beforeText == text))
						{
							string text2 = text[text.Length - 1].ToString();
							if (text2 != "\n" && text2 != "\u3000" && text2 != " ")
							{
								AudioManager.Instance.PlaySeByType(SoundType.SE_per);
							}
							beforeText = text;
						}
					}))));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CSpeak_003Ed__35>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TweenAwaiter)(ref val)).GetResult();
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
	private struct _003CshowJimaku_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen_old _003C_003E4__this;

		public string nakami;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Live_gen_old live_gen_old = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
				{
					float num2 = (live_gen_old.isHayakuti ? 0.02f : 0.05f);
					if (live_gen_old.Speed == 2)
					{
						live_gen_old.jimakuShowing.text = nakami;
						Canvas.ForceUpdateCanvases();
						live_gen_old.isSpeaking = true;
						val2 = UniTask.Delay((int)MathF.Ceiling((float)nakami.Length * num2 * 1000f), false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__34>(ref val, ref this);
							return;
						}
						goto IL_00dc;
					}
					live_gen_old.jimakuShowing.text = "";
					live_gen_old.isSpeaking = true;
					val2 = live_gen_old.Speak(nakami, num2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__34>(ref val, ref this);
						return;
					}
					goto IL_0165;
				}
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00dc;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0165;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00dc:
					((Awaiter)(ref val)).GetResult();
					live_gen_old.isSpeaking = false;
					goto end_IL_000e;
					IL_0165:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.FAST / 8, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__34>(ref val, ref this);
						return;
					}
					break;
				}
				((Awaiter)(ref val)).GetResult();
				live_gen_old.isSpeaking = false;
				end_IL_000e:;
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
	private struct _003Cspeak_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public string anim;

		public Live_gen_old _003C_003E4__this;

		public string nakami;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Live_gen_old live_gen_old = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					if (anim != "")
					{
						live_gen_old.ChotenAnimation(anim, isloop: false);
					}
					UniTask val = live_gen_old.showJimaku(nakami);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cspeak_003Ed__26>(ref val2, ref this);
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
	public Button _HaisinSpeed;

	[SerializeField]
	public TMP_Text _Speedlabel;

	public int Speed;

	private string nowSpeedLabel = "はいしんスピード\u3000ふつう";

	[SerializeField]
	private TMP_Text jimakuShowing;

	[SerializeField]
	private GameObject greenback;

	[SerializeField]
	public TenchanView Tenchan;

	private string todaysTenchan = "stream_cho_akaruku";

	public bool isHayakuti;

	private LanguageType _lang;

	private bool isSpeaking;

	private Tweener Jimaku;

	private int nowLine = -1;

	private string nowSerihu = "";

	private string nowAnim = "";

	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	private Button _next;

	[SerializeField]
	private Button _replay;

	[SerializeField]
	private Button _reset;

	[SerializeField]
	private Button _gb;

	private bool isGBActive;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	[AsyncStateMachine(typeof(_003CAwake_003Ed__22))]
	public UniTask Awake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAwake_003Ed__22 _003CAwake_003Ed__23 = default(_003CAwake_003Ed__22);
		_003CAwake_003Ed__23._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAwake_003Ed__23._003C_003E4__this = this;
		_003CAwake_003Ed__23._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__23._003C_003Et__builder)).Start<_003CAwake_003Ed__22>(ref _003CAwake_003Ed__23);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__23._003C_003Et__builder)).Task;
	}

	private void readline()
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		nowLine++;
		try
		{
			string[] array = _input.text.Replace("\r\n", "\n").Split(new char[2] { '\n', '\r' });
			if (array.Length <= nowLine)
			{
				Tenchan.OnEndStream();
				return;
			}
			string[] array2 = array[nowLine].Split(',');
			if (array2.Length == 1)
			{
				speak(array2[0].Replace("_", "\n"));
			}
			else
			{
				speak(array2[0].Replace("_", "\n"), array2[1]);
			}
		}
		catch
		{
			speak("えーとえーと", "stream_cho_eeto");
		}
	}

	private void rewind()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		nowLine = -1;
		jimakuShowing.text = "";
		Tenchan.PlayAnim("stream_cho_akaruku");
	}

	private void clear()
	{
		rewind();
		_input.text = "";
	}

	[AsyncStateMachine(typeof(_003Cspeak_003Ed__26))]
	public UniTask speak(string nakami, string anim = "")
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003Cspeak_003Ed__26 _003Cspeak_003Ed__27 = default(_003Cspeak_003Ed__26);
		_003Cspeak_003Ed__27._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003Cspeak_003Ed__27._003C_003E4__this = this;
		_003Cspeak_003Ed__27.nakami = nakami;
		_003Cspeak_003Ed__27.anim = anim;
		_003Cspeak_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003Cspeak_003Ed__27._003C_003Et__builder)).Start<_003Cspeak_003Ed__26>(ref _003Cspeak_003Ed__27);
		return ((AsyncUniTaskMethodBuilder)(ref _003Cspeak_003Ed__27._003C_003Et__builder)).Task;
	}

	private void ToggleSpeed()
	{
		Speed++;
		Speed %= 3;
		setSpeed();
	}

	private void toggleGB()
	{
		isGBActive = !isGBActive;
		greenback.SetActive(isGBActive);
	}

	public void setSpeed(int speed)
	{
		Speed = speed;
		setSpeed();
	}

	private void setSpeed()
	{
		switch (Speed)
		{
		case 0:
			nowSpeedLabel = "ふつう";
			isHayakuti = false;
			break;
		case 1:
			nowSpeedLabel = "はやくち";
			isHayakuti = true;
			break;
		default:
			nowSpeedLabel = "一瞬";
			isHayakuti = true;
			break;
		}
		_Speedlabel.text = nowSpeedLabel;
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = Speed;
	}

	private void bgView()
	{
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (status > 100000 && status2 > 14)
		{
			Tenchan._backGround.sprite = Tenchan.background_silver_shield;
		}
		if (status > 1000000 && status2 > 27)
		{
			Tenchan._backGround.sprite = Tenchan.background_gold_shield;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel)
		{
			switch (SingletonMonoBehaviour<EventManager>.Instance.alphaLevel)
			{
			case 1:
				Tenchan._backGround.sprite = Tenchan.background_kinen1;
				break;
			case 2:
				Tenchan._backGround.sprite = Tenchan.background_kinen2;
				break;
			case 3:
				Tenchan._backGround.sprite = Tenchan.background_kinen3;
				break;
			case 4:
				Tenchan._backGround.sprite = Tenchan.background_kinen4;
				break;
			default:
				Tenchan._backGround.sprite = Tenchan.background_kinen5;
				break;
			}
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Kyouso)
		{
			Tenchan._backGround.sprite = Tenchan._background_kyouso;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 28)
		{
			Tenchan._backGround.sprite = Tenchan._background_horror;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			Tenchan._backGround.sprite = Tenchan._background_happy;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ntr)
		{
			Tenchan._backGround.sprite = Tenchan._background_ntr;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
		{
			Tenchan._backGround.sprite = Tenchan._background_sayonara1;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Grand)
		{
			((Graphic)Tenchan._backGround).color = new Color(0f, 0f, 0f, 0f);
		}
	}

	public void chotenView(AlphaType alpha, BetaType beta = BetaType.akaruku, int alphaLevel = 1)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		todaysTenchan = "stream_cho_akaruku";
		Tenchan.PlayAnim(todaysTenchan);
	}

	public void ChotenAnimation(string animationName, bool isloop)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Tenchan.PlayAnim(animationName);
	}

	[AsyncStateMachine(typeof(_003CshowJimaku_003Ed__34))]
	public UniTask showJimaku(string nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshowJimaku_003Ed__34 _003CshowJimaku_003Ed__35 = default(_003CshowJimaku_003Ed__34);
		_003CshowJimaku_003Ed__35._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshowJimaku_003Ed__35._003C_003E4__this = this;
		_003CshowJimaku_003Ed__35.nakami = nakami;
		_003CshowJimaku_003Ed__35._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__35._003C_003Et__builder)).Start<_003CshowJimaku_003Ed__34>(ref _003CshowJimaku_003Ed__35);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__35._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSpeak_003Ed__35))]
	public UniTask Speak(string nakami, float speed)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CSpeak_003Ed__35 _003CSpeak_003Ed__36 = default(_003CSpeak_003Ed__35);
		_003CSpeak_003Ed__36._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSpeak_003Ed__36._003C_003E4__this = this;
		_003CSpeak_003Ed__36.nakami = nakami;
		_003CSpeak_003Ed__36.speed = speed;
		_003CSpeak_003Ed__36._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__36._003C_003Et__builder)).Start<_003CSpeak_003Ed__35>(ref _003CSpeak_003Ed__36);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__36._003C_003Et__builder)).Task;
	}
}
