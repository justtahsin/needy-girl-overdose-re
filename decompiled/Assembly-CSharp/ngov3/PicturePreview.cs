using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class PicturePreview : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetContent_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public PicturePreview _003C_003E4__this;

		public MyPictureContent content;

		private AspectRatioFitter _003Cfitter_003E5__2;

		private Image _003C_003E7__wrap2;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PicturePreview picturePreview = _003C_003E4__this;
			try
			{
				Awaiter<Sprite> val;
				if (num != 0)
				{
					_003Cfitter_003E5__2 = ((Component)picturePreview._Image).GetComponent<AspectRatioFitter>();
					picturePreview._content = content;
					_003C_003E7__wrap2 = picturePreview._Image;
					val = LoadPictures.LoadPictureAsync(content.FileName, LoadPictures.PictureType.MyPicture).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetContent_003Ed__3>(ref val, ref this);
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
				_003C_003E7__wrap2.sprite = result;
				_003C_003E7__wrap2 = null;
				float num2 = ((Texture)picturePreview._Image.sprite.texture).width;
				float num3 = ((Texture)picturePreview._Image.sprite.texture).height;
				bool flag = num2 > num3;
				_003Cfitter_003E5__2.aspectMode = (AspectMode)(flag ? 1 : 2);
				_003Cfitter_003E5__2.aspectRatio = (flag ? (num2 / num3) : (num3 / num2));
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cfitter_003E5__2 = null;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cfitter_003E5__2 = null;
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

	private MyPictureContent _content;

	[SerializeField]
	private Image _Image;

	private void Close()
	{
		_content = null;
		_Image.sprite = null;
	}

	[AsyncStateMachine(typeof(_003CSetContent_003Ed__3))]
	public UniTaskVoid SetContent(MyPictureContent content)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetContent_003Ed__3 _003CSetContent_003Ed__4 = default(_003CSetContent_003Ed__3);
		_003CSetContent_003Ed__4._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CSetContent_003Ed__4._003C_003E4__this = this;
		_003CSetContent_003Ed__4.content = content;
		_003CSetContent_003Ed__4._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CSetContent_003Ed__4._003C_003Et__builder)).Start<_003CSetContent_003Ed__3>(ref _003CSetContent_003Ed__4);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CSetContent_003Ed__4._003C_003Et__builder)).Task;
	}
}
