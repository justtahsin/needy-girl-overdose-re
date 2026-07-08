using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepViewStatic2D : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
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

		public KusoRepViewStatic2D _003C_003E4__this;

		public KusoRepDrawable content;

		private Awaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepViewStatic2D kusoRepViewStatic2D = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<bool> val;
				if (num != 0)
				{
					kusoRepViewStatic2D.nakami = content;
					kusoRepViewStatic2D.SetUserName();
					val = kusoRepViewStatic2D.SetUserImage().GetAwaiter();
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
				kusoRepViewStatic2D.SetBody();
				kusoRepViewStatic2D.SetUserIcon();
				kusoRepViewStatic2D.SetLayout(kusoRepViewStatic2D._userNameExist, kusoRepViewStatic2D._bodyTextExist, kusoRepViewStatic2D._userImageExist);
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
	private struct _003CSetUserImage_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public KusoRepViewStatic2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass27_0 _003C_003E8__1;

		private SpriteRenderer _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KusoRepViewStatic2D CS_0024_003C_003E8__locals7 = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_00eb;
				}
				if (CS_0024_003C_003E8__locals7.nakami.ImageId != "N/A")
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass27_0();
					_003C_003E8__1.resource = CS_0024_003C_003E8__locals7._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == CS_0024_003C_003E8__locals7.nakami.ImageId);
					if (_003C_003E8__1.resource != null)
					{
						_003C_003E7__wrap1 = CS_0024_003C_003E8__locals7._userImage;
						val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetUserImage_003Ed__27>(ref val, ref this);
							return;
						}
						goto IL_00eb;
					}
					result = false;
				}
				else
				{
					result = false;
				}
				goto end_IL_000e;
				IL_00eb:
				Sprite result2 = val.GetResult();
				_003C_003E7__wrap1.sprite = result2;
				_003C_003E7__wrap1 = null;
				CS_0024_003C_003E8__locals7._userImageExist = true;
				Button component = ((Component)CS_0024_003C_003E8__locals7._userImage).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				result = (Object)(object)CS_0024_003C_003E8__locals7._userImage.sprite != (Object)null;
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

	[SerializeField]
	private KusoRepType kRepType;

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

	private KusoRepDrawable nakami;

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

	private bool _userNameExist;

	private bool _bodyTextExist;

	private bool _userImageExist;

	private float _kusorepHeight = 104f;

	private readonly Vector2 IMAGE_SIZE = new Vector2(550f, 550f);

	public void Awake()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SetData(new KusoRepDrawable(kRepType));
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

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A")
		{
			_userName.text = "from " + nakami.UserId;
			_userNameExist = true;
		}
		else
		{
			((Component)_userName).gameObject.SetActive(false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody()
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

	[AsyncStateMachine(typeof(_003CSetUserImage_003Ed__27))]
	protected virtual UniTask<bool> SetUserImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSetUserImage_003Ed__27 _003CSetUserImage_003Ed__28 = default(_003CSetUserImage_003Ed__27);
		_003CSetUserImage_003Ed__28._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CSetUserImage_003Ed__28._003C_003E4__this = this;
		_003CSetUserImage_003Ed__28._003C_003E1__state = -1;
		_003CSetUserImage_003Ed__28._003C_003Et__builder.Start<_003CSetUserImage_003Ed__27>(ref _003CSetUserImage_003Ed__28);
		return _003CSetUserImage_003Ed__28._003C_003Et__builder.Task;
	}

	protected virtual bool SetUserIcon()
	{
		if (nakami.UserIconId != "N/A")
		{
			_userIcon.sprite = Resources.Load<Sprite>("icons/" + nakami.UserIconId);
			return (Object)(object)_userIcon.sprite != (Object)null;
		}
		return false;
	}

	protected virtual void SetLayout(bool userNameExist, bool bodyTextExist, bool userImageExist)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		_userImageElement.minHeight = _userImage.size.y;
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
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
		_kusorepElement.minHeight = num;
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody();
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}
}
