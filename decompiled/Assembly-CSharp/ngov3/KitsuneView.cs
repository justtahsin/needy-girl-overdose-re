using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KitsuneView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAutoScroll_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public KitsuneView _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KitsuneView CS_0024_003C_003E8__locals6 = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num != 0)
				{
					CS_0024_003C_003E8__locals6.UpdateContents();
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						CS_0024_003C_003E8__locals6._scrollRect.verticalNormalizedPosition = 1f;
						CS_0024_003C_003E8__locals6.jienResAlpha.alpha = 0f;
					}), 1f), (Tween)(object)TweenSettingsExtensions.SetEase<Tweener>(DOTweenModuleUI.DOVerticalNormalizedPos(CS_0024_003C_003E8__locals6._scrollRect, 0f, 4f, false), (Ease)5)), (Tween)(object)DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals6.jienResAlpha, 1f, 2f)), 1f), (TweenCallback)delegate
					{
						CS_0024_003C_003E8__locals6.CleanThread();
					})));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CAutoScroll_003Ed__19>(ref val, ref this);
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

	[SerializeField]
	private GameObject _buttonRoot;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private KitsuneResView _kituneResPrefabView;

	[SerializeField]
	private KitsuneResView _AAResPrefabView;

	[SerializeField]
	private Text _suretai;

	[SerializeField]
	private RectTransform _content;

	[SerializeField]
	public bool IsEnding;

	[SerializeField]
	public Text input;

	[SerializeField]
	public Button button;

	[SerializeField]
	private List<KitsuneResView> _resStocks = new List<KitsuneResView>();

	private int stockIndex;

	private CanvasGroup jienResAlpha;

	private const string AA = "\r\n                    ／\uffe3 ＼,, へ\u3000\u3000\u3000    、 χ rヽ / ﾍ   ﾍ\r\n\u3000\u3000\u3000\u3000\u3000 , -- 、 //⌒.  ｋ\u3000\u3000\u3000\u3000\u3000\u3000\u3000<\uffe3 -つ 乂\u3000 ヽ Ｉ\r\n        \u3000/   へ ＼!   l   l\u3000\u3000\u3000\u3000\u3000\u3000\u3000 ＼  ハ-- ＼\uff3fﾊ  l\r\n\u3000\u3000\u3000 \u3000/\u3000/    ＼＼ ヽl\u3000Ｉ\u3000\u3000 /\u3000\u3000\u3000\u3000 ﾍヽ --、_/ │ﾊ │\r\n\u3000\u3000\u3000\u3000/\u3000/\u3000\u3000\u3000ヽヽ/ ﾍ  │\u3000\u3000│\u3000\u3000\u3000\u3000  ﾍ 弋\u3000へ) く\u3000/\r\n       ｜ /        ﾍ  ﾍ l  │\u3000\u3000│   \u3000\u3000\u3000\u3000ﾍ  弋ノ へ∧/\u3000\u3000\u3000\u3000\u3000\u3000\u3000\r\n\u3000\u3000\u3000 ｜｜\u3000\u3000\u3000   ﾍ j ﾏ\u3000ﾉ i\u3000 │ﾍ\u3000\u3000\u3000\u3000   ＼ ﾉ ヽJヽ /\r\n\u3000\u3000\u3000 ｜｜\u3000\u3000\u3000\u3000\u3000│ ﾉ / │\u3000 │ ﾍ\u3000\u3000  \u3000  ﾏ ＼代 ＼／ l\r\n\u3000\u3000\u3000 │｜\u3000\u3000\u3000\u3000\u3000ﾊ ハ/││\u3000 │_.-\u3000\u3000\u3000\u3000├_⊆ヽ つ- /\r\n\u3000\u3000\u3000 弋 ヽ \u3000\u3000\u3000\u3000メχ\u3000l\u3000ﾊ  √  弋 ﾍ---ν〆\u3000l ﾐ.丿ｊ人\r\n\u3000\u3000\u3000\u3000 ヽヽ\u3000 \u3000\u3000／∧\u3000∨ ﾍ\u3000 ﾉ\u3000\u3000 \u00a8       lJ ﾉ ﾊ  │V\u3000 ＼      ☆-・\r\n\u3000\u3000\u3000\u3000\u3000 ＼＼\u3000 ／／\u3000> ┤   ﾚ \u3000   -\u3000\u3000\u3000   ソ,,ﾘ  │\u3000＼  ＼,\r\n\u3000\u3000☆-・ \u3000 ＼ ν／\u3000  (⌒ゝ  、χ≠”\u00a8\u3000\u3000\u3000\u3000 \u3000人  │\u3000\u3000へ   ＼\u3000\u3000\r\n\u3000\u3000\u3000\u3000\u3000\u3000\u3000／へ＼\u3000\u3000乂、l\u3000 ﾍ、\u3000     \u3000\u3000_  ィlｌ │\u3000  \u3000‘へ、＼\r\n\u3000\u3000\u3000\u3000\u3000  ／／ ヽヽ\u3000\u3000\u3000-Y\u3000  弋、     \u3000「 k” lｌ ﾉ\u3000\u3000\u3000\u3000\u3000\u3000 ＼＼\r\n\u3000 \u3000\u3000\u3000／ ／\u3000\u3000 ヽ＼\u3000\u3000 │   代iフγ＼┬││l’ﾉノ入\u3000\u3000\u3000\u3000\u3000\u3000   ﾍ l\r\n\u3000\u3000\u3000 ／ ／\u3000\u3000    ﾍ  ﾍ\u3000\u3000 弋、  ＼  ＼ ＼││  │ l ヾ┐   \u3000\u3000\u3000\u3000  ﾍ│\r\n\u3000\u3000\u3000/\u3000/\u3000\u3000\u3000\u3000 \u3000ﾍ ハ\u3000\u3000 〉＼   ＼\uff3f＼ ＼代\uff3f/ ソヽ\u3000＼\u3000      \u3000\u3000/│\r\n\u3000 \u3000/\u3000/\u3000\u3000\u3000\u3000 \u3000 │ ハ\u3000 /\u3000--へ.\uff3f\uff3f,⊃    ＼ﾍ 人ゞ＼  ＼  \u3000\u3000\u3000  ﾉ/\r\n\u3000\u3000/\u3000/\u3000\u3000   \u3000  \u3000 ﾉ\u3000ﾉ\u3000/ , ── __、＞\u00b4\u3000\u3000 ﾉハ_\u3000ﾍ\u3000へ、＼       ﾉ,\r\n\u3000 ハ ハ\u3000\u3000☆-・\u3000\u3000/  /\u3000/／. ------ .?＼Ｙ ,／\u3000/ヽ＼_\u3000\u3000 ＼＼   ／,\r\n\u3000│ │\u3000\u3000\u3000\u3000 \u3000 ／ ／  ハ／---\u3000／\uffe3\uffe3^Y＼／\u3000／/ ﾉ   l\u3000\u3000\u3000＼χ ／\r\n\u3000│ │\u3000\u3000 \u3000   ／ ／\u3000\u3000│\u3000\u3000\u3000＼\u3000\u3000 へ＼--  ／/ /   │\u3000\u3000 ／\u3000<\r\n  ｌ │\u3000\u3000\u3000\u3000／／     \u3000 ﾉ\u3000\u3000     ﾍ      │ニニ/ / \u3000 │   ／\u3000χﾍ\r\n  ｌ\u3000ﾍ\u3000\u3000\u3000／, \u3000  \u3000\u3000 /\u3000\u3000\u3000\u3000\u3000 ＼\u3000  人 ＼  /      ﾍ  /    / ﾍﾍ\r\n  人 \u3000ﾍ   ／,\u3000 \u3000\u3000\u3000\u3000ハ\u3000\u3000\u3000\u3000\u3000\u3000 ＼／ ＼\u3000\u3000\u3000\u3000\u3000 / /\u3000\u3000/  l l";

	protected void Awake()
	{
		UpdateContents();
		InitializeInput();
	}

	public void InitializeInput()
	{
		input.text = NgoEx.KituneFromType("Kitune_Ending_Charisma_12", SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + "\r\n                    ／\uffe3 ＼,, へ\u3000\u3000\u3000    、 χ rヽ / ﾍ   ﾍ\r\n\u3000\u3000\u3000\u3000\u3000 , -- 、 //⌒.  ｋ\u3000\u3000\u3000\u3000\u3000\u3000\u3000<\uffe3 -つ 乂\u3000 ヽ Ｉ\r\n        \u3000/   へ ＼!   l   l\u3000\u3000\u3000\u3000\u3000\u3000\u3000 ＼  ハ-- ＼\uff3fﾊ  l\r\n\u3000\u3000\u3000 \u3000/\u3000/    ＼＼ ヽl\u3000Ｉ\u3000\u3000 /\u3000\u3000\u3000\u3000 ﾍヽ --、_/ │ﾊ │\r\n\u3000\u3000\u3000\u3000/\u3000/\u3000\u3000\u3000ヽヽ/ ﾍ  │\u3000\u3000│\u3000\u3000\u3000\u3000  ﾍ 弋\u3000へ) く\u3000/\r\n       ｜ /        ﾍ  ﾍ l  │\u3000\u3000│   \u3000\u3000\u3000\u3000ﾍ  弋ノ へ∧/\u3000\u3000\u3000\u3000\u3000\u3000\u3000\r\n\u3000\u3000\u3000 ｜｜\u3000\u3000\u3000   ﾍ j ﾏ\u3000ﾉ i\u3000 │ﾍ\u3000\u3000\u3000\u3000   ＼ ﾉ ヽJヽ /\r\n\u3000\u3000\u3000 ｜｜\u3000\u3000\u3000\u3000\u3000│ ﾉ / │\u3000 │ ﾍ\u3000\u3000  \u3000  ﾏ ＼代 ＼／ l\r\n\u3000\u3000\u3000 │｜\u3000\u3000\u3000\u3000\u3000ﾊ ハ/││\u3000 │_.-\u3000\u3000\u3000\u3000├_⊆ヽ つ- /\r\n\u3000\u3000\u3000 弋 ヽ \u3000\u3000\u3000\u3000メχ\u3000l\u3000ﾊ  √  弋 ﾍ---ν〆\u3000l ﾐ.丿ｊ人\r\n\u3000\u3000\u3000\u3000 ヽヽ\u3000 \u3000\u3000／∧\u3000∨ ﾍ\u3000 ﾉ\u3000\u3000 \u00a8       lJ ﾉ ﾊ  │V\u3000 ＼      ☆-・\r\n\u3000\u3000\u3000\u3000\u3000 ＼＼\u3000 ／／\u3000> ┤   ﾚ \u3000   -\u3000\u3000\u3000   ソ,,ﾘ  │\u3000＼  ＼,\r\n\u3000\u3000☆-・ \u3000 ＼ ν／\u3000  (⌒ゝ  、χ≠”\u00a8\u3000\u3000\u3000\u3000 \u3000人  │\u3000\u3000へ   ＼\u3000\u3000\r\n\u3000\u3000\u3000\u3000\u3000\u3000\u3000／へ＼\u3000\u3000乂、l\u3000 ﾍ、\u3000     \u3000\u3000_  ィlｌ │\u3000  \u3000‘へ、＼\r\n\u3000\u3000\u3000\u3000\u3000  ／／ ヽヽ\u3000\u3000\u3000-Y\u3000  弋、     \u3000「 k” lｌ ﾉ\u3000\u3000\u3000\u3000\u3000\u3000 ＼＼\r\n\u3000 \u3000\u3000\u3000／ ／\u3000\u3000 ヽ＼\u3000\u3000 │   代iフγ＼┬││l’ﾉノ入\u3000\u3000\u3000\u3000\u3000\u3000   ﾍ l\r\n\u3000\u3000\u3000 ／ ／\u3000\u3000    ﾍ  ﾍ\u3000\u3000 弋、  ＼  ＼ ＼││  │ l ヾ┐   \u3000\u3000\u3000\u3000  ﾍ│\r\n\u3000\u3000\u3000/\u3000/\u3000\u3000\u3000\u3000 \u3000ﾍ ハ\u3000\u3000 〉＼   ＼\uff3f＼ ＼代\uff3f/ ソヽ\u3000＼\u3000      \u3000\u3000/│\r\n\u3000 \u3000/\u3000/\u3000\u3000\u3000\u3000 \u3000 │ ハ\u3000 /\u3000--へ.\uff3f\uff3f,⊃    ＼ﾍ 人ゞ＼  ＼  \u3000\u3000\u3000  ﾉ/\r\n\u3000\u3000/\u3000/\u3000\u3000   \u3000  \u3000 ﾉ\u3000ﾉ\u3000/ , ── __、＞\u00b4\u3000\u3000 ﾉハ_\u3000ﾍ\u3000へ、＼       ﾉ,\r\n\u3000 ハ ハ\u3000\u3000☆-・\u3000\u3000/  /\u3000/／. ------ .?＼Ｙ ,／\u3000/ヽ＼_\u3000\u3000 ＼＼   ／,\r\n\u3000│ │\u3000\u3000\u3000\u3000 \u3000 ／ ／  ハ／---\u3000／\uffe3\uffe3^Y＼／\u3000／/ ﾉ   l\u3000\u3000\u3000＼χ ／\r\n\u3000│ │\u3000\u3000 \u3000   ／ ／\u3000\u3000│\u3000\u3000\u3000＼\u3000\u3000 へ＼--  ／/ /   │\u3000\u3000 ／\u3000<\r\n  ｌ │\u3000\u3000\u3000\u3000／／     \u3000 ﾉ\u3000\u3000     ﾍ      │ニニ/ / \u3000 │   ／\u3000χﾍ\r\n  ｌ\u3000ﾍ\u3000\u3000\u3000／, \u3000  \u3000\u3000 /\u3000\u3000\u3000\u3000\u3000 ＼\u3000  人 ＼  /      ﾍ  /    / ﾍﾍ\r\n  人 \u3000ﾍ   ／,\u3000 \u3000\u3000\u3000\u3000ハ\u3000\u3000\u3000\u3000\u3000\u3000 ＼／ ＼\u3000\u3000\u3000\u3000\u3000 / /\u3000\u3000/  l l";
	}

	public void UpdateContents(int num = -1)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		string text = string.Empty;
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Yami)
		{
			text = "Charisma";
			((Component)_scrollRect).gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
			_buttonRoot.SetActive(false);
		}
		else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
		{
			text = "Ideon";
			((Component)_scrollRect).gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
			_buttonRoot.SetActive(false);
		}
		else if (SingletonMonoBehaviour<EventManager>.Instance.isHorror)
		{
			int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
			int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart);
			if (status == 26)
			{
				text = ((status2 != 0) ? "Horror_Day2_AfterHaishin" : "Horror_Day2_BeforeHaishin");
			}
			if (status == 27)
			{
				switch (num)
				{
				case -1:
					return;
				case 0:
					text = "Horror_Day3_first";
					break;
				case 1:
					text = "Horror_Day3_second";
					break;
				default:
					text = "Horror_Day3_third";
					break;
				}
			}
			((Component)_scrollRect).gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
			_buttonRoot.SetActive(false);
		}
		else
		{
			text = ThreadRank(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower));
		}
		string text2 = NgoEx.SuretaiFromType("Suretai_" + text.TrimEnd(new char[3] { '1', '2', '3' }), SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_suretai.text = text2;
		foreach (KituneMaster.Param item in NgoEx.KituneFromRank(text))
		{
			GetResInstance().SetData(NgoEx.SystemTextFromType(SystemTextType.Kitsune_Handle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), item.ResNumber, NgoEx.KituneFromType(item.Id, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.KituneJien != "")
		{
			GetResInstance().SetData(NgoEx.SystemTextFromType(SystemTextType.Kitsune_Handle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 11, SingletonMonoBehaviour<EventManager>.Instance.KituneJien);
		}
	}

	public void Jien()
	{
		KitsuneResView resInstance = GetResInstance(isJien: true);
		resInstance.SetData(NgoEx.SystemTextFromType(SystemTextType.Kitsune_Handle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), Random.Range(0, 900) + 11, NgoEx.KituneFromType("Kitune_Ending_Charisma_12", SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		input.text = "";
		((Component)resInstance).transform.SetAsLastSibling();
		AudioManager.Instance?.PlaySeByType(SoundType.SE_status_up);
		TweenExtensions.Play<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(DOTweenModuleUI.DOVerticalNormalizedPos(_scrollRect, 0f, 4f, false), (Ease)5));
	}

	public void CleanThread()
	{
		for (int num = ((Transform)_content).childCount - 1; num > 1; num--)
		{
			Object.Destroy((Object)(object)((Component)((Transform)_content).GetChild(num)).gameObject);
		}
	}

	private string ThreadRank(int follower)
	{
		if (follower > 500000)
		{
			if (follower > 1000000)
			{
				return "Legend3";
			}
			if (follower > 750000)
			{
				return "Legend2";
			}
			return "Legend1";
		}
		if (follower > 100000)
		{
			if (follower > 400000)
			{
				return "Angel3";
			}
			if (follower > 200000)
			{
				return "Angel2";
			}
			return "Angel1";
		}
		if (follower > 10000)
		{
			if (follower > 80000)
			{
				return "Shuueki3";
			}
			if (follower > 40000)
			{
				return "Shuueki2";
			}
			return "Shuueki1";
		}
		if (follower > 5000)
		{
			return "Normal3";
		}
		if (follower > 2000)
		{
			return "Normal2";
		}
		return "Normal1";
	}

	[AsyncStateMachine(typeof(_003CAutoScroll_003Ed__19))]
	public UniTask AutoScroll()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAutoScroll_003Ed__19 _003CAutoScroll_003Ed__20 = default(_003CAutoScroll_003Ed__19);
		_003CAutoScroll_003Ed__20._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAutoScroll_003Ed__20._003C_003E4__this = this;
		_003CAutoScroll_003Ed__20._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAutoScroll_003Ed__20._003C_003Et__builder)).Start<_003CAutoScroll_003Ed__19>(ref _003CAutoScroll_003Ed__20);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAutoScroll_003Ed__20._003C_003Et__builder)).Task;
	}

	private KitsuneResView GetResInstance(bool isJien = false)
	{
		if (isJien)
		{
			return Object.Instantiate<KitsuneResView>(_AAResPrefabView, (Transform)(object)_content);
		}
		if (stockIndex < _resStocks.Count)
		{
			KitsuneResView kitsuneResView = _resStocks[stockIndex];
			((Component)kitsuneResView).gameObject.SetActive(true);
			stockIndex++;
			return kitsuneResView;
		}
		return Object.Instantiate<KitsuneResView>(_kituneResPrefabView, (Transform)(object)_content);
	}
}
