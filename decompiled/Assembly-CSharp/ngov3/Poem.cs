using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3;

public class Poem : SingletonMonoBehaviour<Poem>
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartPoem_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Poem _003C_003E4__this;

		public string poem;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Poem poem = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016d;
				}
				Poem poem2 = _003C_003E4__this;
				string beforeText = poem.PoemText.text;
				if (!poem.playingAnimation)
				{
					poem.playingAnimation = true;
					poem.sequence = TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						poem2.PoemCanvas.alpha = 0f;
						poem2.PoemCanvas.interactable = true;
						poem2.PoemCanvas.blocksRaycasts = true;
						poem2.PoemText.text = "";
						poem2.YamiNoise.weight = 0.2f;
					}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(poem.PoemCanvas, 1f, 0.4f), (Ease)2)), (Tween)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<string, string, StringOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(poem.PoemText, this.poem, (float)this.poem.Length * 0.12f, true, (ScrambleMode)0, (string)null), (Ease)1), (TweenCallback)delegate
					{
						string text = poem2.PoemText.text;
						if (!(beforeText == text))
						{
							string text2 = text[text.Length - 1].ToString();
							if (text2 != "\n" && text2 != "\u3000" && text2 != " ")
							{
								AudioManager.Instance.PlaySeByType(SoundType.SE_per);
							}
							beforeText = text;
						}
					})), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => poem2.YamiNoise.weight), (DOSetter<float>)delegate(float x)
					{
						poem2.YamiNoise.weight = x;
					}, 1f, 0.2f), (Ease)17)), 1.8f), (TweenCallback)delegate
					{
						poem2.endAnimation();
					});
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(poem.sequence));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CStartPoem_003Ed__13>(ref val, ref this);
						return;
					}
					goto IL_016d;
				}
				goto end_IL_000e;
				IL_016d:
				((TweenAwaiter)(ref val)).GetResult();
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

	[SerializeField]
	protected CanvasGroup PoemCanvas;

	[SerializeField]
	protected Button ClickToSkip;

	protected string poemHonbun;

	[SerializeField]
	protected TMP_Text PoemText;

	[SerializeField]
	protected Volume YamiNoise;

	protected Settings _setting;

	protected Sequence sequence;

	protected bool playingAnimation;

	[SerializeField]
	protected Button StartPoemButton;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	protected override void Awake()
	{
		base.Awake();
		if ((Object)(object)StartPoemButton != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(StartPoemButton), (Action<Unit>)delegate
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				StartPoem("インターネットって、汚水が流れるどぶみたいなきったない匂いがする。\n\nこの世で最も汚れた空間だと思う。");
			}), (Component)(object)StartPoemButton);
		}
	}

	public virtual void Start()
	{
		PoemCanvas.alpha = 0f;
		PoemCanvas.interactable = false;
		PoemCanvas.blocksRaycasts = false;
		YamiNoise.weight = 0f;
		PoemText.text = "";
	}

	public void SkipPoem()
	{
		if (playingAnimation)
		{
			TweenExtensions.Kill((Tween)(object)sequence, true);
			endAnimation();
		}
	}

	[AsyncStateMachine(typeof(_003CStartPoem_003Ed__13))]
	public UniTask StartPoem(string poem, bool isDaypassing = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CStartPoem_003Ed__13 _003CStartPoem_003Ed__14 = default(_003CStartPoem_003Ed__13);
		_003CStartPoem_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartPoem_003Ed__14._003C_003E4__this = this;
		_003CStartPoem_003Ed__14.poem = poem;
		_003CStartPoem_003Ed__14._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartPoem_003Ed__14._003C_003Et__builder)).Start<_003CStartPoem_003Ed__13>(ref _003CStartPoem_003Ed__14);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartPoem_003Ed__14._003C_003Et__builder)).Task;
	}

	public virtual void endAnimation()
	{
		playingAnimation = false;
		PoemCanvas.interactable = false;
		PoemCanvas.blocksRaycasts = false;
	}

	public void CleanPoem()
	{
		TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => YamiNoise.weight), (DOSetter<float>)delegate(float x)
		{
			YamiNoise.weight = x;
		}, 0f, 0.2f), (Ease)18)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(PoemCanvas, 0f, 1.4f), (Ease)2)));
	}
}
