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
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepView2D : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
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
	private struct _003CSetData_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public KusoRepView2D _003C_003E4__this;

		public KusoRepDrawable content;

		private Awaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepView2D kusoRepView2D = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<bool> val;
				if (num != 0)
				{
					kusoRepView2D.nakami = content;
					kusoRepView2D.SetUserName();
					val = kusoRepView2D.SetUserImage().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<bool>, _003CSetData_003Ed__24>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				val.GetResult();
				kusoRepView2D.SetBody(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				kusoRepView2D.SetUserIcon();
				kusoRepView2D.SetLayout(kusoRepView2D._userNameExist, kusoRepView2D._bodyTextExist, kusoRepView2D._userImageExist);
				result = true;
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
	private struct _003CSetUserImage_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public KusoRepView2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass29_0 _003C_003E8__1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepView2D CS_0024_003C_003E8__locals21 = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_00f5;
				}
				if (CS_0024_003C_003E8__locals21.nakami.ImageId != "N/A")
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass29_0();
					_003C_003E8__1.resource = CS_0024_003C_003E8__locals21._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == CS_0024_003C_003E8__locals21.nakami.ImageId);
					if (_003C_003E8__1.resource != null)
					{
						SingletonMonoBehaviour<Settings>.Instance.addImage(CS_0024_003C_003E8__locals21.nakami.ImageId);
						val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetUserImage_003Ed__29>(ref val, ref this);
							return;
						}
						goto IL_00f5;
					}
					result = false;
				}
				else
				{
					result = false;
				}
				goto end_IL_000e;
				IL_00f5:
				Sprite result2 = val.GetResult();
				CS_0024_003C_003E8__locals21._userImage.sprite = result2;
				CS_0024_003C_003E8__locals21._imageFileName = _003C_003E8__1.resource.FileName;
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector((float)((Texture)result2.texture).width, (float)((Texture)result2.texture).height);
				Vector2 val3 = val2;
				if (val2.x >= val2.y)
				{
					val3.x = CS_0024_003C_003E8__locals21.IMAGE_SIZE.x;
					val3.y = val2.y * (CS_0024_003C_003E8__locals21.IMAGE_SIZE.x / val2.x);
				}
				else
				{
					val3.y = CS_0024_003C_003E8__locals21.IMAGE_SIZE.y;
					val3.x = val2.x * (CS_0024_003C_003E8__locals21.IMAGE_SIZE.y / val2.y);
				}
				CS_0024_003C_003E8__locals21._userImage.size = val3;
				CS_0024_003C_003E8__locals21._userImageElement.minWidth = val3.x;
				CS_0024_003C_003E8__locals21._userImageElement.minHeight = val3.y;
				((Component)CS_0024_003C_003E8__locals21._userImage).GetComponent<BoxCollider2D>().size = val3;
				((Component)CS_0024_003C_003E8__locals21._userImage).gameObject.SetActive(true);
				CS_0024_003C_003E8__locals21._userImageExist = true;
				Button component = ((Component)CS_0024_003C_003E8__locals21._userImage).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				if ((Object)(object)CS_0024_003C_003E8__locals21.imageOverHungObject != (Object)null)
				{
					CS_0024_003C_003E8__locals21.imageOverHungObject.SetParentRect(((Component)((Component)CS_0024_003C_003E8__locals21).transform.parent.parent.parent.parent).GetComponent<RectTransform>());
				}
				result = (Object)(object)CS_0024_003C_003E8__locals21._userImage.sprite != (Object)null;
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
	private struct _003CShow_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public KusoRepView2D _003C_003E4__this;

		private float _003Cfade_003E5__2;

		private TweenAwaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepView2D CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			try
			{
				float num2 = default(float);
				if ((uint)num > 1u)
				{
					((Component)CS_0024_003C_003E8__locals8).transform.SetAsFirstSibling();
					num2 = 0.6f;
					_003Cfade_003E5__2 = 0.3f;
					AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_kusorep);
				}
				try
				{
					Awaiter val;
					TweenAwaiter val2;
					if (num != 0)
					{
						if (num == 1)
						{
							val = _003C_003Eu__2;
							_003C_003Eu__2 = default(Awaiter);
							num = (_003C_003E1__state = -1);
							goto IL_013d;
						}
						val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => CS_0024_003C_003E8__locals8._kusorepElement.minHeight), (DOSetter<float>)delegate(float x)
						{
							CS_0024_003C_003E8__locals8._kusorepElement.minHeight = x;
						}, CS_0024_003C_003E8__locals8._kusorepHeight, num2)));
						if (!((TweenAwaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__25>(ref val2, ref this);
							return;
						}
					}
					else
					{
						val2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TweenAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TweenAwaiter)(ref val2)).GetResult();
					UniTask val3 = CS_0024_003C_003E8__locals8._fader.DOFade(_003Cfade_003E5__2, 1f);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShow_003Ed__25>(ref val, ref this);
						return;
					}
					goto IL_013d;
					IL_013d:
					((Awaiter)(ref val)).GetResult();
				}
				catch (OperationCanceledException)
				{
					CS_0024_003C_003E8__locals8._kusorepElement.minHeight = CS_0024_003C_003E8__locals8._kusorepHeight;
					CS_0024_003C_003E8__locals8._fader.SetAlpha(1f);
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
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected SpriteRenderer _userImage;

	[SerializeField]
	protected TMP_Text _userName;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected Fader2D _fader;

	private string _imageFileName = "N/A";

	[Header("Layout Components")]
	[SerializeField]
	protected LayoutElement _kusorepElement;

	[SerializeField]
	private RectTransform Rect;

	[SerializeField]
	protected LayoutElement _bodyElement;

	[SerializeField]
	protected VerticalLayoutGroup _bodyLayoutGroup;

	[SerializeField]
	protected RectTransform _bodyRectTr;

	[SerializeField]
	protected LayoutElement _userNameElement;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected LayoutElement _userImageElement;

	[SerializeField]
	protected LayoutElement _dateElement;

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	private bool _userNameExist;

	private bool _bodyTextExist;

	private bool _userImageExist;

	private float _kusorepHeight = 104f;

	private KusoRepDrawable nakami;

	private readonly Vector2 IMAGE_SIZE = new Vector2(550f, 550f);

	public void Awake()
	{
		_fader.SetAlpha(0f);
		_kusorepElement.minHeight = 0f;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType t)
		{
			OnLanguageUpdated(t);
		}), ((Component)this).gameObject);
	}

	[AsyncStateMachine(typeof(_003CSetData_003Ed__24))]
	public UniTask<bool> SetData(KusoRepDrawable content)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetData_003Ed__24 _003CSetData_003Ed__25 = default(_003CSetData_003Ed__24);
		_003CSetData_003Ed__25._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CSetData_003Ed__25._003C_003E4__this = this;
		_003CSetData_003Ed__25.content = content;
		_003CSetData_003Ed__25._003C_003E1__state = -1;
		_003CSetData_003Ed__25._003C_003Et__builder.Start<_003CSetData_003Ed__24>(ref _003CSetData_003Ed__25);
		return _003CSetData_003Ed__25._003C_003Et__builder.Task;
	}

	[AsyncStateMachine(typeof(_003CShow_003Ed__25))]
	public UniTask Show()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShow_003Ed__25 _003CShow_003Ed__26 = default(_003CShow_003Ed__25);
		_003CShow_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShow_003Ed__26._003C_003E4__this = this;
		_003CShow_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__26._003C_003Et__builder)).Start<_003CShow_003Ed__25>(ref _003CShow_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__26._003C_003Et__builder)).Task;
	}

	public void ShowPosted()
	{
		((Component)this).transform.SetAsFirstSibling();
		_kusorepElement.minHeight = _kusorepHeight;
		_fader.SetAlpha(1f);
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A" && nakami.UserId != "" && nakami.UserId != null)
		{
			_userName.text = NgoEx.SystemTextFromType(SystemTextType.From, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + nakami.UserId;
			_userNameExist = true;
			((Component)_userName).gameObject.SetActive(true);
		}
		else
		{
			((Component)_userName).gameObject.SetActive(false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody(LanguageType lang)
	{
		(string, bool) kusoRepBody = NgoEx_Temp.GetKusoRepBody(nakami);
		_bodyText.text = kusoRepBody.Item1;
		if (nakami.BodyJp == "N/A")
		{
			((Component)_bodyText).gameObject.SetActive(false);
		}
		else
		{
			_bodyTextExist = true;
		}
		return kusoRepBody.Item2;
	}

	[AsyncStateMachine(typeof(_003CSetUserImage_003Ed__29))]
	protected virtual UniTask<bool> SetUserImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSetUserImage_003Ed__29 _003CSetUserImage_003Ed__30 = default(_003CSetUserImage_003Ed__29);
		_003CSetUserImage_003Ed__30._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CSetUserImage_003Ed__30._003C_003E4__this = this;
		_003CSetUserImage_003Ed__30._003C_003E1__state = -1;
		_003CSetUserImage_003Ed__30._003C_003Et__builder.Start<_003CSetUserImage_003Ed__29>(ref _003CSetUserImage_003Ed__30);
		return _003CSetUserImage_003Ed__30._003C_003Et__builder.Task;
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

	protected virtual void SetLayout(bool userNameExist, bool bodyTextExist, bool userImageExist)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		_userImageElement.minHeight = _userImage.size.y;
		_bodyTextElement.minHeight = 0f;
		float num = 0f;
		float num2 = 6f;
		if (userNameExist)
		{
			num += _userNameElement.minHeight + num2;
		}
		if (bodyTextExist)
		{
			num += _bodyTextElement.minHeight + num2;
		}
		if (userImageExist)
		{
			num += _userImageElement.minHeight + num2;
		}
		num = Mathf.Max(num, _userIcon.size.y);
		_bodyElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, _bodyElement.minHeight);
		_kusorepHeight = num;
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetUserName();
		SetBody(type);
		SetLayout(_userNameExist, _bodyTextExist, _userImageExist);
	}
}
