using System;
using System.Diagnostics;
using System.Globalization;
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
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterCellStatic2D : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public string imageId;

		public ResourceLocal resource;

		internal bool _003CFetchTweetImage_003Eb__0(ResourceLocal r)
		{
			return r.FileName == imageId;
		}

		internal void _003CFetchTweetImage_003Eb__1(Unit _)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			ImageViewerHelper.OpenImageViewer(resource.FileName);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CFetchTweetImage_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public PoketterCellStatic2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass37_0 _003C_003E8__1;

		private bool _003ChasImage_003E5__2;

		private SpriteRenderer _003C_003E7__wrap2;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCellStatic2D poketterCellStatic2D = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_0163;
				}
				_003ChasImage_003E5__2 = poketterCellStatic2D.tweetDrawable.ImageId.IsNotEmpty();
				((Component)poketterCellStatic2D._image).gameObject.SetActive(_003ChasImage_003E5__2);
				if (!_003ChasImage_003E5__2)
				{
					goto IL_01c0;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass37_0();
				_003C_003E8__1.imageId = poketterCellStatic2D.tweetDrawable.ImageId;
				_003C_003E8__1.resource = poketterCellStatic2D._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__1.imageId);
				SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__1.imageId);
				if (_003C_003E8__1.resource != null)
				{
					_003C_003E7__wrap2 = poketterCellStatic2D._image;
					val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CFetchTweetImage_003Ed__37>(ref val, ref this);
						return;
					}
					goto IL_0163;
				}
				Debug.LogError((object)("TWEET MASTER: " + _003C_003E8__1.imageId + " の 画像Id がなかったよ " + _003C_003E8__1.imageId));
				result = false;
				goto end_IL_000e;
				IL_01c0:
				result = _003ChasImage_003E5__2;
				goto end_IL_000e;
				IL_0163:
				Sprite result2 = val.GetResult();
				_003C_003E7__wrap2.sprite = result2;
				_003C_003E7__wrap2 = null;
				Button component = ((Component)poketterCellStatic2D._image).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				_003C_003E8__1 = null;
				goto IL_01c0;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetData_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCellStatic2D _003C_003E4__this;

		public TweetDrawable nakami;

		private Awaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCellStatic2D poketterCellStatic2D = _003C_003E4__this;
			try
			{
				Awaiter<bool> val;
				if (num != 0)
				{
					poketterCellStatic2D.tweetDrawable = nakami;
					poketterCellStatic2D.SetUserIcon();
					poketterCellStatic2D.SetUserName();
					poketterCellStatic2D.FetchBody();
					val = poketterCellStatic2D.FetchTweetImage().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<bool>, _003CSetData_003Ed__31>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				bool result = val.GetResult();
				poketterCellStatic2D._imageExist = result;
				poketterCellStatic2D.SetLayout(poketterCellStatic2D._imageExist);
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
	private struct _003CShow_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCellStatic2D _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCellStatic2D poketterCellStatic2D = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					poketterCellStatic2D.fader.SetAlpha(0f);
					float duration = (float)poketterCellStatic2D._fadeMillisecond / 1000f;
					UniTask val = poketterCellStatic2D.fader.DOFade(duration, 1f);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShow_003Ed__38>(ref val2, ref this);
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
	private TweetType tweetType = TweetType.None;

	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected SpriteRenderer _image;

	[SerializeField]
	protected Sprite _omoteIcon;

	[SerializeField]
	protected Sprite _uraIcon;

	[SerializeField]
	protected TMP_Text _rtText;

	[SerializeField]
	protected TMP_Text _favText;

	[SerializeField]
	private RectTransform _kusoRepRoot;

	[SerializeField]
	private KusoRepView _kusoRepPrefab;

	[Header("ツイートが出現するときにスクロールする時間")]
	[SerializeField]
	private int _scrollMillisecond = 1000;

	[Header("ツイートがフェードインする時間")]
	[SerializeField]
	private int _fadeMillisecond = 300;

	[SerializeField]
	[Header("バズりパワーがテロテロする時間")]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	[SerializeField]
	private Fader2D fader;

	[Header("Layout Components")]
	[SerializeField]
	protected LayoutElement _postElement;

	[SerializeField]
	protected RectTransform _postRectTr;

	[SerializeField]
	protected LayoutElement _bodyElement;

	[SerializeField]
	protected RectTransform _bodyRectTr;

	[SerializeField]
	protected LayoutElement _userTextElement;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected RectTransform _bodyTextRectTr;

	[SerializeField]
	protected LayoutElement _imageElement;

	[SerializeField]
	protected LayoutElement _buzzElement;

	[SerializeField]
	protected LayoutElement _datetElement;

	private bool _imageExist;

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	public void Awake()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		imageOverHungObject.SetParentRect(((Component)((Component)this).transform.parent.parent).GetComponent<RectTransform>());
		SetData(new TweetDrawable(new TweetData(tweetType, isOmote: true)));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	[AsyncStateMachine(typeof(_003CSetData_003Ed__31))]
	public UniTask SetData(TweetDrawable nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetData_003Ed__31 _003CSetData_003Ed__32 = default(_003CSetData_003Ed__31);
		_003CSetData_003Ed__32._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSetData_003Ed__32._003C_003E4__this = this;
		_003CSetData_003Ed__32.nakami = nakami;
		_003CSetData_003Ed__32._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSetData_003Ed__32._003C_003Et__builder)).Start<_003CSetData_003Ed__31>(ref _003CSetData_003Ed__32);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSetData_003Ed__32._003C_003Et__builder)).Task;
	}

	public void SetDataStatic(TweetDrawable nakami)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(nakami.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		FetchTweetImage();
		_rtText.text = ConvertGigaNumber(nakami.RtNumber);
		_favText.text = ConvertGigaNumber(nakami.FavNumber);
	}

	public void Animate()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Show();
		FavRtMove();
		ShowKusoReps();
	}

	protected virtual bool SetUserIcon()
	{
		_userIcon.sprite = (tweetDrawable.IsOmote ? _omoteIcon : _uraIcon);
		return (Object)(object)_userIcon.sprite != (Object)null;
	}

	protected virtual bool SetUserName()
	{
		_userText.text = (tweetDrawable.IsOmote ? NgoEx.SystemTextFromType(SystemTextType.Account_Omote, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.Account_Ura_Name, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		return !string.IsNullOrEmpty(_userText.text);
	}

	private void FetchBody()
	{
		_bodyText.text = NgoEx_Temp.FetchTweetBody(tweetDrawable);
	}

	[AsyncStateMachine(typeof(_003CFetchTweetImage_003Ed__37))]
	private UniTask<bool> FetchTweetImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CFetchTweetImage_003Ed__37 _003CFetchTweetImage_003Ed__38 = default(_003CFetchTweetImage_003Ed__37);
		_003CFetchTweetImage_003Ed__38._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CFetchTweetImage_003Ed__38._003C_003E4__this = this;
		_003CFetchTweetImage_003Ed__38._003C_003E1__state = -1;
		_003CFetchTweetImage_003Ed__38._003C_003Et__builder.Start<_003CFetchTweetImage_003Ed__37>(ref _003CFetchTweetImage_003Ed__38);
		return _003CFetchTweetImage_003Ed__38._003C_003Et__builder.Task;
	}

	[AsyncStateMachine(typeof(_003CShow_003Ed__38))]
	private UniTask Show()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShow_003Ed__38 _003CShow_003Ed__39 = default(_003CShow_003Ed__38);
		_003CShow_003Ed__39._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShow_003Ed__39._003C_003E4__this = this;
		_003CShow_003Ed__39._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__39._003C_003Et__builder)).Start<_003CShow_003Ed__38>(ref _003CShow_003Ed__39);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__39._003C_003Et__builder)).Task;
	}

	private string ConvertGigaNumber(int number)
	{
		if (number > 1000000000)
		{
			return $"{number / 100000000}G";
		}
		if (number > 1000000)
		{
			return $"{number / 100000}M";
		}
		if (number > 10000)
		{
			return $"{number / 1000}K";
		}
		return number.ToString();
	}

	private void FavRtMove()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		if (!tweetDrawable.IsOmote)
		{
			return;
		}
		float num = (float)_buzzMillisecond / 1000f;
		if (tweetDrawable.RtNumber > 0)
		{
			TweenExtensions.Play<TweenerCore<int, int, NoOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<int, int, NoOptions>>(ShortcutExtensionsTMPText.DOCounter(_rtText, 0, tweetDrawable.RtNumber, num, true, (CultureInfo)null), (TweenCallback)delegate
			{
				_rtText.text = ConvertGigaNumber(tweetDrawable.RtNumber);
			}));
		}
		if (tweetDrawable.FavNumber > 0)
		{
			TweenExtensions.Play<TweenerCore<int, int, NoOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<int, int, NoOptions>>(ShortcutExtensionsTMPText.DOCounter(_favText, 0, tweetDrawable.FavNumber, num, true, (CultureInfo)null), (TweenCallback)delegate
			{
				_favText.text = ConvertGigaNumber(tweetDrawable.FavNumber);
			}));
		}
	}

	private async void ShowKusoReps()
	{
		for (int i = 0; i < ((Transform)_kusoRepRoot).childCount; i++)
		{
			await ((Component)((Transform)_kusoRepRoot).GetChild(i)).GetComponent<KusoRepView>().Show();
		}
	}

	private async void SetLayout(bool imageExist)
	{
		await UniTask.DelayFrame(2, (PlayerLoopTiming)8, default(CancellationToken), false);
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
		float num = 0f;
		float num2 = 6f;
		num += _userTextElement.minHeight + num2;
		num += _bodyTextElement.minHeight + num2;
		if (imageExist)
		{
			num += _imageElement.minHeight + num2;
		}
		num += _buzzElement.minHeight + num2;
		num += _datetElement.minHeight;
		_bodyElement.minHeight = num;
		_postElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, num);
		_postRectTr.sizeDelta = new Vector2(_postRectTr.sizeDelta.x, num);
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
	}
}
