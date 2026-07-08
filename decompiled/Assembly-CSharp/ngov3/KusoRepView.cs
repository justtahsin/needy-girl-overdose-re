using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepView : MonoBehaviour, ILayoutElement2D
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public ResourceLocal resource;

		internal void _003CSetUserImage_003Eb__1(Unit _)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			ImageViewerHelper.OpenImageViewer(resource.FileName);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetUserImage_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public KusoRepView _003C_003E4__this;

		private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepView CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_0101;
				}
				if (CS_0024_003C_003E8__locals8.nakami.ImageId != "N/A")
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass23_0();
					_003C_003E8__1.resource = CS_0024_003C_003E8__locals8._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == CS_0024_003C_003E8__locals8.nakami.ImageId);
					if (_003C_003E8__1.resource != null)
					{
						SingletonMonoBehaviour<Settings>.Instance.addImage(CS_0024_003C_003E8__locals8.nakami.ImageId);
						_003C_003E7__wrap1 = CS_0024_003C_003E8__locals8._userImage;
						val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetUserImage_003Ed__23>(ref val, ref this);
							return;
						}
						goto IL_0101;
					}
					result = false;
				}
				else
				{
					result = false;
				}
				goto end_IL_000e;
				IL_0101:
				Sprite result2 = val.GetResult();
				_003C_003E7__wrap1.sprite = result2;
				_003C_003E7__wrap1 = null;
				((Component)CS_0024_003C_003E8__locals8._userImage).gameObject.SetActive(true);
				Button component = ((Component)CS_0024_003C_003E8__locals8._userImage).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				result = (Object)(object)CS_0024_003C_003E8__locals8._userImage.sprite != (Object)null;
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
	private struct _003CShow_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public KusoRepView _003C_003E4__this;

		private float _003Cfade_003E5__2;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepView kusoRepView = _003C_003E4__this;
			try
			{
				float num2 = default(float);
				if ((uint)num > 1u)
				{
					((Component)kusoRepView).transform.SetAsFirstSibling();
					num2 = 0.6f;
					_003Cfade_003E5__2 = 0.3f;
					AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_kusorep);
				}
				try
				{
					TweenAwaiter val;
					if (num != 0)
					{
						if (num == 1)
						{
							val = _003C_003Eu__1;
							_003C_003Eu__1 = default(TweenAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0121;
						}
						val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScaleY((Transform)(object)kusoRepView.Rect, 1f, num2)));
						if (!((TweenAwaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__19>(ref val, ref this);
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
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(kusoRepView.canvas, 1f, _003Cfade_003E5__2)));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__19>(ref val, ref this);
						return;
					}
					goto IL_0121;
					IL_0121:
					((TweenAwaiter)(ref val)).GetResult();
				}
				catch (OperationCanceledException)
				{
					((Transform)kusoRepView.Rect).localScale = new Vector3(1f, 1f, 1f);
					kusoRepView.canvas.alpha = 1f;
				}
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
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected Image _userIcon;

	[SerializeField]
	protected Image _userImage;

	[SerializeField]
	protected Text _userName;

	[SerializeField]
	protected Text _bodyText;

	private CanvasGroup canvas;

	private RectTransform Rect;

	private KusoRepDrawable nakami;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	[SerializeField]
	private RectTransform hightSyncObject;

	[SerializeField]
	private float minHight = 40f;

	public LayoutElement2DType LayoutElement2DType => LayoutElement2DType.OBJECT;

	public RectTransform RectTransform => Rect;

	public IObservable<Unit> OnDestroyObservable => (IObservable<Unit>)onDestroySubject;

	public void Awake()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => hightSyncObject.sizeDelta.y))), (Action<float>)delegate(float targetHight)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			targetHight = ((minHight > targetHight) ? minHight : targetHight);
			Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, targetHight);
		}), ((Component)this).gameObject);
		canvas = ((Component)this).GetComponent<CanvasGroup>();
		canvas.alpha = 0f;
		Rect = ((Component)this).GetComponent<RectTransform>();
		((Transform)Rect).localScale = new Vector3(1f, 0f, 1f);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType t)
		{
			OnLanguageUpdated(t);
		}), ((Component)this).gameObject);
	}

	public bool SetData(KusoRepDrawable content)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		nakami = content;
		SetUserName();
		SetUserImage();
		SetBody(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetUserIcon();
		return true;
	}

	[AsyncStateMachine(typeof(_003CShow_003Ed__19))]
	public UniTask Show()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShow_003Ed__19 _003CShow_003Ed__20 = default(_003CShow_003Ed__19);
		_003CShow_003Ed__20._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShow_003Ed__20._003C_003E4__this = this;
		_003CShow_003Ed__20._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__20._003C_003Et__builder)).Start<_003CShow_003Ed__19>(ref _003CShow_003Ed__20);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__20._003C_003Et__builder)).Task;
	}

	public void ShowPosted()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.SetAsFirstSibling();
		((Transform)Rect).localScale = new Vector3(1f, 1f, 1f);
		canvas.alpha = 1f;
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A" && nakami.UserId != "")
		{
			_userName.text = "from " + nakami.UserId;
		}
		else
		{
			((Component)_userName).gameObject.SetActive(false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody(LanguageType lang)
	{
		switch (lang)
		{
		case LanguageType.JP:
			_bodyText.text = nakami.BodyJp;
			break;
		case LanguageType.CN:
			_bodyText.text = nakami.BodyCn;
			break;
		case LanguageType.KO:
			_bodyText.text = nakami.BodyKo;
			break;
		case LanguageType.TW:
			_bodyText.text = nakami.BodyTw;
			break;
		case LanguageType.VN:
			_bodyText.text = nakami.BodyVn;
			break;
		case LanguageType.FR:
			_bodyText.text = nakami.BodyFr;
			break;
		case LanguageType.IT:
			_bodyText.text = nakami.BodyIt;
			break;
		case LanguageType.GE:
			_bodyText.text = nakami.BodyGe;
			break;
		case LanguageType.SP:
			_bodyText.text = nakami.BodySp;
			break;
		case LanguageType.RU:
			_bodyText.text = nakami.BodyRu;
			break;
		default:
			_bodyText.text = nakami.BodyEn;
			break;
		}
		if (nakami.BodyJp == "N/A")
		{
			((Component)_bodyText).gameObject.SetActive(false);
		}
		return _bodyText.text != string.Empty;
	}

	[AsyncStateMachine(typeof(_003CSetUserImage_003Ed__23))]
	protected virtual UniTask<bool> SetUserImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSetUserImage_003Ed__23 _003CSetUserImage_003Ed__24 = default(_003CSetUserImage_003Ed__23);
		_003CSetUserImage_003Ed__24._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CSetUserImage_003Ed__24._003C_003E4__this = this;
		_003CSetUserImage_003Ed__24._003C_003E1__state = -1;
		_003CSetUserImage_003Ed__24._003C_003Et__builder.Start<_003CSetUserImage_003Ed__23>(ref _003CSetUserImage_003Ed__24);
		return _003CSetUserImage_003Ed__24._003C_003Et__builder.Task;
	}

	private void OnDestroy()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
	}

	protected virtual bool SetUserIcon()
	{
		if (nakami.UserIconId.IsNotEmpty())
		{
			_userIcon.sprite = Resources.Load<Sprite>("icons/" + nakami.UserIconId);
			return (Object)(object)_userIcon.sprite != (Object)null;
		}
		return false;
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody(type);
	}
}
