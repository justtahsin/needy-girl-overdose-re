using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MyPictureContentView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetContent_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public MyPictureContentView _003C_003E4__this;

		public MyPictureContent content;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MyPictureContentView CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			try
			{
				Awaiter<Sprite> val;
				if (num != 0)
				{
					CS_0024_003C_003E8__locals8._content = content;
					CS_0024_003C_003E8__locals8._title.text = CS_0024_003C_003E8__locals8._content.Title;
					_003C_003E7__wrap1 = ((Selectable)CS_0024_003C_003E8__locals8._picture).image;
					val = LoadPictures.LoadPictureAsync(CS_0024_003C_003E8__locals8._content?.FileName, LoadPictures.PictureType.MyPicture).GetAwaiter();
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
				_003C_003E7__wrap1.sprite = result;
				_003C_003E7__wrap1 = null;
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals8._picture), (Action<Unit>)delegate
				{
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ImageViewer).nakamiApp.GetComponent<ImageViewer>().SetData(CS_0024_003C_003E8__locals8._content.FileName);
				}), ((Component)CS_0024_003C_003E8__locals8).gameObject);
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSetContentStatic_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public MyPictureContentView _003C_003E4__this;

		public MyPictureContent content;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MyPictureContentView myPictureContentView = _003C_003E4__this;
			try
			{
				Awaiter<Sprite> val;
				if (num != 0)
				{
					myPictureContentView._content = content;
					myPictureContentView._title.text = myPictureContentView._content.Title;
					_003C_003E7__wrap1 = ((Selectable)myPictureContentView._picture).image;
					val = LoadPictures.LoadPictureAsync(myPictureContentView._content?.FileName, LoadPictures.PictureType.MyPicture).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CSetContentStatic_003Ed__4>(ref val, ref this);
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
	private MyPictureContent _content;

	[SerializeField]
	private Button _picture;

	[SerializeField]
	private TMP_Text _title;

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

	[AsyncStateMachine(typeof(_003CSetContentStatic_003Ed__4))]
	public UniTask SetContentStatic(MyPictureContent content)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetContentStatic_003Ed__4 _003CSetContentStatic_003Ed__5 = default(_003CSetContentStatic_003Ed__4);
		_003CSetContentStatic_003Ed__5._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSetContentStatic_003Ed__5._003C_003E4__this = this;
		_003CSetContentStatic_003Ed__5.content = content;
		_003CSetContentStatic_003Ed__5._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSetContentStatic_003Ed__5._003C_003Et__builder)).Start<_003CSetContentStatic_003Ed__4>(ref _003CSetContentStatic_003Ed__5);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSetContentStatic_003Ed__5._003C_003Et__builder)).Task;
	}
}
