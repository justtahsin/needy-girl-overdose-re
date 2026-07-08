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

public class PoketterCellStatic : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
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
	private struct _003CFetchTweetImage_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public PoketterCellStatic _003C_003E4__this;

		private _003C_003Ec__DisplayClass25_0 _003C_003E8__1;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCellStatic poketterCellStatic = _003C_003E4__this;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_014d;
				}
				bool flag = poketterCellStatic.tweetDrawable.ImageId.IsNotEmpty();
				((Component)poketterCellStatic._image).gameObject.SetActive(flag);
				if (flag)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass25_0();
					_003C_003E8__1.imageId = poketterCellStatic.tweetDrawable.ImageId;
					_003C_003E8__1.resource = poketterCellStatic._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__1.imageId);
					SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__1.imageId);
					if (_003C_003E8__1.resource == null)
					{
						Debug.LogError((object)("TWEET MASTER: " + _003C_003E8__1.imageId + " の 画像Id がなかったよ " + _003C_003E8__1.imageId));
					}
					_003C_003E7__wrap1 = poketterCellStatic._image;
					val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CFetchTweetImage_003Ed__25>(ref val, ref this);
						return;
					}
					goto IL_014d;
				}
				goto end_IL_000e;
				IL_014d:
				Sprite result = val.GetResult();
				_003C_003E7__wrap1.sprite = result;
				_003C_003E7__wrap1 = null;
				Button component = ((Component)poketterCellStatic._image).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				_003C_003E8__1 = null;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
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
	protected Image _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected Image _image;

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

	[Header("バズりパワーがテロテロする時間")]
	[SerializeField]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	private CanvasGroup _baseCanvasGroup;

	public void Awake()
	{
		SetData(new TweetDrawable(new TweetData(tweetType, isOmote: true)));
		_baseCanvasGroup = ((Component)this).GetComponent<CanvasGroup>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	public void SetData(TweetDrawable nakami)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		FetchTweetImage();
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
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		{
		case LanguageType.JP:
			_bodyText.text = tweetDrawable.BodyJp;
			break;
		case LanguageType.CN:
			_bodyText.text = tweetDrawable.BodyCn;
			break;
		case LanguageType.KO:
			_bodyText.text = tweetDrawable.BodyKo;
			break;
		case LanguageType.TW:
			_bodyText.text = tweetDrawable.BodyTw;
			break;
		case LanguageType.VN:
			_bodyText.text = tweetDrawable.BodyVn;
			break;
		case LanguageType.FR:
			_bodyText.text = tweetDrawable.BodyFr;
			break;
		case LanguageType.IT:
			_bodyText.text = tweetDrawable.BodyIt;
			break;
		case LanguageType.GE:
			_bodyText.text = tweetDrawable.BodyGe;
			break;
		case LanguageType.SP:
			_bodyText.text = tweetDrawable.BodySp;
			break;
		case LanguageType.RU:
			_bodyText.text = tweetDrawable.BodyRu;
			break;
		default:
			_bodyText.text = tweetDrawable.BodyEn;
			break;
		}
	}

	[AsyncStateMachine(typeof(_003CFetchTweetImage_003Ed__25))]
	private UniTaskVoid FetchTweetImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CFetchTweetImage_003Ed__25 _003CFetchTweetImage_003Ed__26 = default(_003CFetchTweetImage_003Ed__25);
		_003CFetchTweetImage_003Ed__26._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CFetchTweetImage_003Ed__26._003C_003E4__this = this;
		_003CFetchTweetImage_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CFetchTweetImage_003Ed__26._003C_003Et__builder)).Start<_003CFetchTweetImage_003Ed__25>(ref _003CFetchTweetImage_003Ed__26);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CFetchTweetImage_003Ed__26._003C_003Et__builder)).Task;
	}

	private void Show()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		_baseCanvasGroup.alpha = 0f;
		_ = (float)_scrollMillisecond / 1000f;
		float num = (float)_fadeMillisecond / 1000f;
		CancellationToken cancellationTokenOnDestroy = UniTaskCancellationExtensions.GetCancellationTokenOnDestroy(((Component)this).gameObject);
		DOTweenAsyncExtensions.WithCancellation((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(_baseCanvasGroup, 1f, num)), cancellationTokenOnDestroy);
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

	private void SetKusoRep()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			Object.Instantiate<KusoRepView>(_kusoRepPrefab, ((Component)_kusoRepRoot).transform).SetData(kusoRep);
		}
	}

	private void SetKusoRepStatic()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			KusoRepView kusoRepView = Object.Instantiate<KusoRepView>(_kusoRepPrefab, ((Component)_kusoRepRoot).transform);
			kusoRepView.SetData(kusoRep);
			kusoRepView.ShowPosted();
		}
	}

	private async void ShowKusoReps()
	{
		for (int i = 0; i < ((Transform)_kusoRepRoot).childCount; i++)
		{
			await ((Component)((Transform)_kusoRepRoot).GetChild(i)).GetComponent<KusoRepView>().Show();
		}
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
	}
}
