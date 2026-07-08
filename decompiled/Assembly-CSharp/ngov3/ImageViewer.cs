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
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ImageViewer : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetData_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public ImageViewer _003C_003E4__this;

		public string address;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ImageViewer imageViewer = _003C_003E4__this;
			try
			{
				Awaiter<Sprite> val;
				if (num != 0)
				{
					_003C_003E7__wrap1 = imageViewer._image;
					val = LoadPictures.LoadPictureAsync(address, LoadPictures.PictureType.ImageViewer).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetData_003Ed__12>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
				}
				Sprite result = val.GetResult();
				_003C_003E7__wrap1.sprite = result;
				_003C_003E7__wrap1 = null;
				imageViewer._imageAddress = address;
				imageViewer.Show();
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
	private Image _image;

	[SerializeField]
	private RectMask2D _mask;

	[SerializeField]
	private Sprite medama;

	[SerializeField]
	private Sprite medama2;

	[SerializeField]
	private Sprite medama3;

	[SerializeField]
	private Sprite medama4;

	[SerializeField]
	private Text kowai;

	[SerializeField]
	private Image bg;

	private string _imageAddress = "N/A";

	public string ImageAddress => _imageAddress;

	public void Awake()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Rect rect = ((Component)((Component)_mask).transform.parent).GetComponent<RectTransform>().rect;
		float height = ((Rect)(ref rect)).height;
		_mask.padding = new Vector4(0f, height, 0f, 0f);
	}

	[AsyncStateMachine(typeof(_003CSetData_003Ed__12))]
	public UniTaskVoid SetData(string address)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetData_003Ed__12 _003CSetData_003Ed__13 = default(_003CSetData_003Ed__12);
		_003CSetData_003Ed__13._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CSetData_003Ed__13._003C_003E4__this = this;
		_003CSetData_003Ed__13.address = address;
		_003CSetData_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CSetData_003Ed__13._003C_003Et__builder)).Start<_003CSetData_003Ed__12>(ref _003CSetData_003Ed__13);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CSetData_003Ed__13._003C_003Et__builder)).Task;
	}

	public void setMedama(int number)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		((Graphic)bg).color = new Color(0f, 0f, 0f);
		_image.sprite = medama;
		Blink(NgoEx.SystemTextFromTypeString("KowaiInternet" + number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
	}

	private void Blink(string nakami)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetEase<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)DOTween.To((DOGetter<Vector4>)(() => _mask.padding), (DOSetter<Vector4>)delegate(Vector4 x)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			_mask.padding = x;
		}, new Vector4(0f, 0f, 0f, 0f), 1.2f)), 0.15f), (TweenCallback)delegate
		{
			_image.sprite = medama2;
		}), 0.15f), (TweenCallback)delegate
		{
			_image.sprite = medama3;
		}), 0.15f), (TweenCallback)delegate
		{
			_image.sprite = medama4;
		}), 0.5f), (TweenCallback)delegate
		{
			_image.sprite = medama3;
		}), 0.15f), (TweenCallback)delegate
		{
			_image.sprite = medama;
		}), 0.1f), (TweenCallback)delegate
		{
			((Component)_image).gameObject.SetActive(false);
		}), (TweenCallback)delegate
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			kowai.text = nakami;
			if (nakami.Length > 30)
			{
				RectTransform rectTransform = ((Graphic)kowai).rectTransform;
				Vector2 val = default(Vector2);
				((Vector2)(ref val))._002Ector(0f, 0f);
				rectTransform.offsetMin = val;
				rectTransform.offsetMax = val;
			}
			else
			{
				RectTransform rectTransform2 = ((Graphic)kowai).rectTransform;
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector(20f, 20f);
				rectTransform2.offsetMin = val2;
				rectTransform2.offsetMax = val2 * -1f;
			}
		}), (TweenCallback)delegate
		{
			TweenExtensions.Play<Tweener>(TweenSettingsExtensions.SetRelative<Tweener>(TweenSettingsExtensions.SetLoops<Tweener>(ShortcutExtensions.DOShakePosition(((Component)kowai).gameObject.transform, 1f, 1f, 10, 30f, true, false), -1, (LoopType)1), true));
		}), (Ease)9));
	}

	private void Show()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		TweenExtensions.Play<TweenerCore<Vector4, Vector4, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector4, Vector4, VectorOptions>>(DOTween.To((DOGetter<Vector4>)(() => _mask.padding), (DOSetter<Vector4>)delegate(Vector4 x)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_mask.padding = x;
		}, new Vector4(0f, 0f, 0f, 0f), 1f), (Ease)8));
	}

	private void OnDestroy()
	{
		if (_imageAddress != "N/A")
		{
			LoadPictures.DeleteCache(_imageAddress, LoadPictures.PictureType.ImageViewer);
		}
	}

	public async void CashedSetUp(int number)
	{
		Rect rect = ((Component)((Component)_mask).transform.parent).GetComponent<RectTransform>().rect;
		float height = ((Rect)(ref rect)).height;
		_mask.padding = new Vector4(0f, height, 0f, 0f);
		((Graphic)bg).color = new Color(0f, 0f, 0f);
		_image.sprite = medama;
		Blink(NgoEx.SystemTextFromTypeString("KowaiInternet" + number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		kowai.text = "";
		await UniTask.Delay(1100, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		Show();
	}
}
