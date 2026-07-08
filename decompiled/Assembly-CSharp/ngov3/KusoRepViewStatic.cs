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

public class KusoRepViewStatic : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
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
	private struct _003CSetUserImage_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public KusoRepViewStatic _003C_003E4__this;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

		private Image _003C_003E7__wrap1;

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
			KusoRepViewStatic CS_0024_003C_003E8__locals6 = _003C_003E4__this;
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
				if (CS_0024_003C_003E8__locals6.nakami.ImageId != "N/A")
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass13_0();
					_003C_003E8__1.resource = CS_0024_003C_003E8__locals6._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == CS_0024_003C_003E8__locals6.nakami.ImageId);
					if (_003C_003E8__1.resource != null)
					{
						_003C_003E7__wrap1 = CS_0024_003C_003E8__locals6._userImage;
						val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetUserImage_003Ed__13>(ref val, ref this);
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
				Button component = ((Component)CS_0024_003C_003E8__locals6._userImage).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				result = (Object)(object)CS_0024_003C_003E8__locals6._userImage.sprite != (Object)null;
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
	protected Image _userIcon;

	[SerializeField]
	protected Image _userImage;

	[SerializeField]
	protected TMP_Text _userName;

	[SerializeField]
	protected TMP_Text _bodyText;

	private CanvasGroup canvas;

	private RectTransform Rect;

	private KusoRepDrawable nakami;

	public void Awake()
	{
		SetData(new KusoRepDrawable(kRepType));
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
		SetBody();
		SetUserIcon();
		return true;
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A")
		{
			_userName.text = "from " + nakami.UserId;
		}
		else
		{
			((Component)_userName).gameObject.SetActive(false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody()
	{
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
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

	[AsyncStateMachine(typeof(_003CSetUserImage_003Ed__13))]
	protected virtual UniTask<bool> SetUserImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSetUserImage_003Ed__13 _003CSetUserImage_003Ed__14 = default(_003CSetUserImage_003Ed__13);
		_003CSetUserImage_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CSetUserImage_003Ed__14._003C_003E4__this = this;
		_003CSetUserImage_003Ed__14._003C_003E1__state = -1;
		_003CSetUserImage_003Ed__14._003C_003Et__builder.Start<_003CSetUserImage_003Ed__13>(ref _003CSetUserImage_003Ed__14);
		return _003CSetUserImage_003Ed__14._003C_003Et__builder.Task;
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

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody();
	}
}
