using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Live_gen : MonoBehaviour
{
	private enum LiveGenStatus
	{
		NONE,
		CHOTEN_VIEW,
		CATEGORY_SELECT,
		ANIMATION_KEY_SELECT
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAwake_003Ed__59 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen _003C_003E4__this;

		private void MoveNext()
		{
			Live_gen CS_0024_003C_003E8__locals37 = _003C_003E4__this;
			try
			{
				CS_0024_003C_003E8__locals37._titleEditLabel.text = NgoEx.SystemTextFromType(SystemTextType.TitleEdit, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				CS_0024_003C_003E8__locals37._liveTitleLabel.text = NgoEx.SystemTextFromType(SystemTextType.LiveTitle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				CS_0024_003C_003E8__locals37._visitorsLabel.text = "N " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				CS_0024_003C_003E8__locals37.InitializeLiveInput();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._closeAnimationKeyParent), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.closeAnimationKeyView();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
				CS_0024_003C_003E8__locals37._lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
				CS_0024_003C_003E8__locals37.Speed = SingletonMonoBehaviour<Settings>.Instance.haishinSpeed;
				CS_0024_003C_003E8__locals37.chotenView();
				CS_0024_003C_003E8__locals37.bgView();
				CS_0024_003C_003E8__locals37.setSpeed();
				CS_0024_003C_003E8__locals37.nowNextLabel = "▶\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Next, CS_0024_003C_003E8__locals37._lang);
				CS_0024_003C_003E8__locals37._nextLabel.text = CS_0024_003C_003E8__locals37.nowNextLabel;
				CS_0024_003C_003E8__locals37._replayLabel.text = "◀◀\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Replay, CS_0024_003C_003E8__locals37._lang);
				CS_0024_003C_003E8__locals37._resetLabel.text = "■\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Reset, CS_0024_003C_003E8__locals37._lang);
				CS_0024_003C_003E8__locals37._gbLabel.text = "GB " + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_GB, CS_0024_003C_003E8__locals37._lang);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._HaisinSpeed), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.ToggleSpeed();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._next), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.readline();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._replay), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.rewind();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._reset), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.clear();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals37._gb), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals37.toggleGB();
				}), ((Component)CS_0024_003C_003E8__locals37).gameObject);
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
	private struct _003CSpeak_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen _003C_003E4__this;

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
			Live_gen live_gen = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num != 0)
				{
					Live_gen live_gen2 = _003C_003E4__this;
					string beforeText = live_gen.jimakuShowing.text;
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						live_gen2.jimakuShowing.text = "";
					}), (Tween)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<string, string, StringOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(live_gen.jimakuShowing, nakami, (float)nakami.Length * speed, true, (ScrambleMode)0, (string)null), (Ease)1), (TweenCallback)delegate
					{
						string text = live_gen2.jimakuShowing.text;
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
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CSpeak_003Ed__78>(ref val, ref this);
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
	private struct _003CshowJimaku_003Ed__77 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Live_gen _003C_003E4__this;

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
			Live_gen live_gen = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
				{
					float num2 = (live_gen.isHayakuti ? 0.02f : 0.05f);
					if (live_gen.Speed == 2)
					{
						live_gen.jimakuShowing.text = nakami;
						Canvas.ForceUpdateCanvases();
						live_gen.isSpeaking = true;
						val2 = UniTask.Delay((int)MathF.Ceiling((float)nakami.Length * num2 * 1000f), false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__77>(ref val, ref this);
							return;
						}
						goto IL_00dc;
					}
					live_gen.jimakuShowing.text = "";
					live_gen.isSpeaking = true;
					val2 = live_gen.Speak(nakami, num2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__77>(ref val, ref this);
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
					live_gen.isSpeaking = false;
					goto end_IL_000e;
					IL_0165:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.FAST / 8, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__77>(ref val, ref this);
						return;
					}
					break;
				}
				((Awaiter)(ref val)).GetResult();
				live_gen.isSpeaking = false;
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
	private struct _003Cspeak_003Ed__69 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public string anim;

		public Live_gen _003C_003E4__this;

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
			Live_gen live_gen = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					if (anim != "")
					{
						live_gen.ChotenAnimation(anim, isloop: false);
					}
					UniTask val = live_gen.showJimaku(nakami);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cspeak_003Ed__69>(ref val2, ref this);
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

	private string nowNextLabel = "▶\n\nすすむ";

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
	public TMP_Text _nextLabel;

	[SerializeField]
	private Button _next;

	[SerializeField]
	public TMP_Text _replayLabel;

	[SerializeField]
	private Button _replay;

	[SerializeField]
	public TMP_Text _resetLabel;

	[SerializeField]
	private Button _reset;

	[SerializeField]
	public TMP_Text _gbLabel;

	[SerializeField]
	private Button _gb;

	private bool isGBActive;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	[SerializeField]
	private Transform inputFieldParent;

	[SerializeField]
	private TextInputItem textInputItemPrefab;

	[SerializeField]
	private int initializeInputFieldCount = 1;

	private List<TextInputItem> textInputs = new List<TextInputItem>();

	[Header("AnimationKeyMaster")]
	[SerializeField]
	private Transform categoryParent;

	[SerializeField]
	private GameObject categoryView;

	[SerializeField]
	private Transform animationKeyParent;

	[SerializeField]
	private GameObject animationKeyView;

	[SerializeField]
	private AnimationCategoryVODataStore animationCategoryVODataStore;

	[SerializeField]
	private AnimationKeyVODataStore animationKeyVODataStore;

	[SerializeField]
	private AnimationCategoryItem categoryItemPrefab;

	[SerializeField]
	private AnimationItem animationHistoryItemPrefab;

	[SerializeField]
	private AnimationItem animationReturnItemPrefab;

	[SerializeField]
	private AnimationKeyItem animationKeyItemPrefab;

	[SerializeField]
	private Button _closeAnimationKeyParent;

	private TextInputItem selectedTextInput;

	[SerializeField]
	private VerticalLayoutGroup textGrid;

	[SerializeField]
	private List<Button> liveGenButtons;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private TMP_Text _titleEditLabel;

	[SerializeField]
	private TMP_InputField _liveTitleLabel;

	[SerializeField]
	private TMP_Text _visitorsLabel;

	[SerializeField]
	private List<AnimationKeyItem> animationKeyItems = new List<AnimationKeyItem>();

	private IEnumerable<TextInputItem> ReadableTexts => textInputs.Where((TextInputItem t) => !string.IsNullOrEmpty(t.Input.text) || !string.IsNullOrEmpty(t.AnimationKey.Value));

	private void SetAppButtonsIntalactable(bool interactable)
	{
		foreach (Button liveGenButton in liveGenButtons)
		{
			((Selectable)liveGenButton).interactable = interactable;
		}
	}

	[ContextMenu("FixLayout")]
	public async void FixTextGridLayout()
	{
		float verticalNormalizedPosition = scrollRect.verticalNormalizedPosition;
		if ((int)((LayoutGroup)textGrid).childAlignment == 0)
		{
			((LayoutGroup)textGrid).childAlignment = (TextAnchor)1;
		}
		else
		{
			((LayoutGroup)textGrid).childAlignment = (TextAnchor)0;
		}
		scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
	}

	public void SetSelectedTextInput(TextInputItem selectedTextInput)
	{
		this.selectedTextInput = selectedTextInput;
		foreach (TextInputItem textInput in textInputs)
		{
			textInput.SetSelected(isSelected: false);
		}
		this.selectedTextInput.SetSelected(isSelected: true);
	}

	private void SetLiveGenView(LiveGenStatus liveGenStatus)
	{
		if (liveGenStatus == LiveGenStatus.CHOTEN_VIEW)
		{
			foreach (TextInputItem textInput in textInputs)
			{
				textInput.SetSelected(isSelected: false);
			}
			animationKeyView.SetActive(false);
			categoryView.gameObject.SetActive(false);
			SetAppButtonsIntalactable(interactable: true);
			ClearAnimationKeys();
		}
		if (liveGenStatus == LiveGenStatus.CATEGORY_SELECT)
		{
			animationKeyView.SetActive(false);
			categoryView.gameObject.SetActive(true);
			SetAppButtonsIntalactable(interactable: false);
			ClearAnimationKeys();
		}
		if (liveGenStatus == LiveGenStatus.ANIMATION_KEY_SELECT)
		{
			animationKeyView.SetActive(true);
			categoryView.gameObject.SetActive(false);
			SetAppButtonsIntalactable(interactable: false);
		}
	}

	public async void AddTextInput(TextInputItem textInputItem)
	{
		textInputs.Insert(textInputItem.Index, textInputItem);
		if (textInputs.Select((TextInputItem ti) => ti.Index).Max() == textInputItem.Index)
		{
			await UniTask.Delay(10, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			Debug.Log((object)"最後尾なので下部にスクロール");
			scrollRect.verticalNormalizedPosition = 0f;
		}
	}

	public void RemoveTextInput(TextInputItem textInputItem)
	{
		textInputs = textInputs.Where((TextInputItem t) => t.Index != textInputItem.Index).ToList();
	}

	private async void InitializeLiveInput()
	{
		textInputs.ForEach(delegate(TextInputItem ti)
		{
			Object.Destroy((Object)(object)((Component)ti).gameObject);
		});
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		textInputs = new List<TextInputItem>();
		selectedTextInput = null;
		for (int num = 0; num < initializeInputFieldCount; num++)
		{
			TextInputItem textInputItem = PrefabFolder.InstantiateTo<TextInputItem>((MonoBehaviour)(object)textInputItemPrefab, inputFieldParent);
			textInputItem.Initialize(this);
			textInputs.Add(textInputItem);
		}
	}

	[AsyncStateMachine(typeof(_003CAwake_003Ed__59))]
	public UniTask Awake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAwake_003Ed__59 _003CAwake_003Ed__60 = default(_003CAwake_003Ed__59);
		_003CAwake_003Ed__60._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAwake_003Ed__60._003C_003E4__this = this;
		_003CAwake_003Ed__60._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__60._003C_003Et__builder)).Start<_003CAwake_003Ed__59>(ref _003CAwake_003Ed__60);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__60._003C_003Et__builder)).Task;
	}

	private void Start()
	{
		AudioManager.Instance?.StopBgm();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(Observable.DistinctUntilChanged<bool>(Observable.Select<Unit, bool>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => Input.GetKey((KeyCode)273)))), (Func<bool, bool>)((bool onKey) => onKey)), (Action<bool>)delegate
		{
			TextInputItem selectedItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!((Object)(object)selectedItem == (Object)null) && selectedItem.Index != 0)
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				((Selectable)textInputs.FirstOrDefault((TextInputItem it) => it.Index == selectedItem.Index - 1).Input).Select();
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(Observable.DistinctUntilChanged<bool>(Observable.Select<Unit, bool>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => Input.GetKey((KeyCode)274)))), (Func<bool, bool>)((bool onKey) => onKey)), (Action<bool>)delegate
		{
			TextInputItem selectedItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!((Object)(object)selectedItem == (Object)null) && selectedItem.Index != textInputs.Select((TextInputItem it) => it.Index).Max())
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				((Selectable)textInputs.FirstOrDefault((TextInputItem it) => it.Index == selectedItem.Index + 1).Input).Select();
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(Observable.DistinctUntilChanged<bool>(Observable.Select<Unit, bool>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => Input.GetKey((KeyCode)13)))), (Func<bool, bool>)((bool onKey) => onKey)), (Action<bool>)delegate
		{
			TextInputItem textInputItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!((Object)(object)textInputItem == (Object)null) && (!(textInputItem.Input.text == "") || !(textInputItem.AnimationKey.Value == "")))
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				textInputItem.CreateChildItem();
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(Observable.Select<Unit, bool>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => Input.GetKey((KeyCode)127) || Input.GetKey((KeyCode)8))), (Func<bool, bool>)((bool onKey) => onKey)), (Action<bool>)delegate
		{
			TextInputItem textInputItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!((Object)(object)textInputItem == (Object)null) && textInputItem.Input.text == "")
			{
				textInputItem.DeleatItem();
			}
		}), ((Component)this).gameObject);
		SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		foreach (AnimationCategoryVO item in animationCategoryVODataStore.Items.Where((AnimationCategoryVO cv) => cv.AnimationCategory != AnimationCategoryEnum.none))
		{
			PrefabFolder.InstantiateTo<AnimationCategoryItem>((MonoBehaviour)(object)categoryItemPrefab, categoryParent).Initialize(item, delegate(AnimationCategoryVO vo)
			{
				SetLiveGenView(LiveGenStatus.ANIMATION_KEY_SELECT);
				IEnumerable<AnimationKeyVO> enumerable = animationKeyVODataStore.Items.Where((AnimationKeyVO akv) => akv.AnimationCategory == vo.AnimationCategory);
				SetAnimationKeyView(enumerable);
			});
		}
		PrefabFolder.InstantiateTo<AnimationItem>((MonoBehaviour)(object)animationHistoryItemPrefab, categoryParent).Initialize(delegate
		{
			SetLiveGenView(LiveGenStatus.ANIMATION_KEY_SELECT);
			List<string> list = new List<string>(SingletonMonoBehaviour<Settings>.Instance.animationKeyHistory);
			list.Reverse();
			IEnumerable<AnimationKeyVO> enumerable = from aniKey in list
				select animationKeyVODataStore.Items.FirstOrDefault((AnimationKeyVO akv) => akv.Id == aniKey) into akv
				where akv != null
				select akv;
			SetAnimationKeyView(enumerable);
		}, NgoEx.SystemTextFromType(SystemTextType.live_gen_history, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		PrefabFolder.InstantiateTo<AnimationItem>((MonoBehaviour)(object)animationReturnItemPrefab, categoryParent).Initialize(delegate
		{
			selectedTextInput.AnimationKey.Value = "";
			SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		}, NgoEx.SystemTextFromType(SystemTextType.live_gen_unlock, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
	}

	private void ClearAnimationKeys()
	{
		animationKeyItems.ForEach(delegate(AnimationKeyItem ak)
		{
			Object.DestroyImmediate((Object)(object)((Component)ak).gameObject);
		});
		animationKeyItems = new List<AnimationKeyItem>();
	}

	private void SetAnimationKeyView(IEnumerable<AnimationKeyVO> targetCategoryAnimatoonKeys)
	{
		foreach (AnimationKeyVO targetCategoryAnimatoonKey in targetCategoryAnimatoonKeys)
		{
			AnimationKeyItem animationKeyItem = PrefabFolder.InstantiateTo<AnimationKeyItem>((MonoBehaviour)(object)animationKeyItemPrefab, animationKeyParent);
			animationKeyItems.Add(animationKeyItem);
			animationKeyItem.Initialize(targetCategoryAnimatoonKey, delegate(AnimationKeyVO vo)
			{
				SingletonMonoBehaviour<Settings>.Instance.AddAnimationKeyHistory(vo.Id);
				selectedTextInput.AnimationKey.Value = vo.Id;
				((Selectable)selectedTextInput.Input).Select();
				closeAnimationKeyView();
			});
		}
	}

	public void ShowCategoryParent()
	{
		SetLiveGenView(LiveGenStatus.CATEGORY_SELECT);
	}

	private void closeAnimationKeyView()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		foreach (Transform item in animationKeyParent)
		{
			Object.Destroy((Object)(object)((Component)item).gameObject);
		}
	}

	private void readline()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		nowLine++;
		try
		{
			TextInputItem[] array = ReadableTexts.ToArray();
			if (array.Length <= nowLine)
			{
				Tenchan.ShowEndView();
				return;
			}
			string text = array[nowLine].Input.text;
			string value = array[nowLine].AnimationKey.Value;
			speak(text.Replace("_", "\n").Replace("<br>", "\n"), value);
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
			speak(NgoEx.SystemTextFromType(SystemTextType.Agreement, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), "stream_cho_eeto");
		}
	}

	private void rewind()
	{
		nowLine = -1;
		jimakuShowing.text = "";
		ChotenAnimation("stream_cho_akaruku", isloop: false);
		if (Tenchan.LiveEnd)
		{
			Tenchan.ReWindEndView();
		}
	}

	private async void clear()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.ManualHaishin);
		((Component)this).gameObject.SetActive(false);
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ManualHaishin);
	}

	[AsyncStateMachine(typeof(_003Cspeak_003Ed__69))]
	public UniTask speak(string nakami, string anim = "")
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003Cspeak_003Ed__69 _003Cspeak_003Ed__70 = default(_003Cspeak_003Ed__69);
		_003Cspeak_003Ed__70._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003Cspeak_003Ed__70._003C_003E4__this = this;
		_003Cspeak_003Ed__70.nakami = nakami;
		_003Cspeak_003Ed__70.anim = anim;
		_003Cspeak_003Ed__70._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003Cspeak_003Ed__70._003C_003Et__builder)).Start<_003Cspeak_003Ed__69>(ref _003Cspeak_003Ed__70);
		return ((AsyncUniTaskMethodBuilder)(ref _003Cspeak_003Ed__70._003C_003Et__builder)).Task;
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
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpNormal, _lang);
			isHayakuti = false;
			break;
		case 1:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpFaster, _lang);
			isHayakuti = true;
			break;
		default:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpMoment, _lang);
			isHayakuti = true;
			break;
		}
		_Speedlabel.text = nowSpeedLabel;
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = Speed;
	}

	private void bgView()
	{
	}

	public void chotenView(AlphaType alpha = AlphaType.none, BetaType beta = BetaType.akaruku, int alphaLevel = 1)
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

	[AsyncStateMachine(typeof(_003CshowJimaku_003Ed__77))]
	public UniTask showJimaku(string nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshowJimaku_003Ed__77 _003CshowJimaku_003Ed__78 = default(_003CshowJimaku_003Ed__77);
		_003CshowJimaku_003Ed__78._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshowJimaku_003Ed__78._003C_003E4__this = this;
		_003CshowJimaku_003Ed__78.nakami = nakami;
		_003CshowJimaku_003Ed__78._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__78._003C_003Et__builder)).Start<_003CshowJimaku_003Ed__77>(ref _003CshowJimaku_003Ed__78);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__78._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSpeak_003Ed__78))]
	public UniTask Speak(string nakami, float speed)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CSpeak_003Ed__78 _003CSpeak_003Ed__79 = default(_003CSpeak_003Ed__78);
		_003CSpeak_003Ed__79._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSpeak_003Ed__79._003C_003E4__this = this;
		_003CSpeak_003Ed__79.nakami = nakami;
		_003CSpeak_003Ed__79.speed = speed;
		_003CSpeak_003Ed__79._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__79._003C_003Et__builder)).Start<_003CSpeak_003Ed__78>(ref _003CSpeak_003Ed__79);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__79._003C_003Et__builder)).Task;
	}
}
