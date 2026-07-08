using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class EndingOmake : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartOpen_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EndingOmake _003C_003E4__this;

		public int zipnumber;

		private List<ResourceLocal> _003Cresources_003E5__2;

		private List<string> _003CimageIdList_003E5__3;

		private int _003Ci_003E5__4;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EndingOmake endingOmake = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
					endingOmake.chooseZip.SetActive(false);
					endingOmake._open.SetActive(true);
					endingOmake._openNum.text = zipnumber.ToString();
					_003Cresources_003E5__2 = ImageViewerHelper.LoadFanArtList();
					_003CimageIdList_003E5__3 = new List<string>();
					_003Ci_003E5__4 = zipnumber - 1;
					goto IL_0179;
				}
				Awaiter val = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter);
				num = (_003C_003E1__state = -1);
				goto IL_015f;
				IL_015f:
				((Awaiter)(ref val)).GetResult();
				_003Ci_003E5__4 += endingOmake.ZIPCOUNT;
				goto IL_0179;
				IL_0179:
				if (_003Ci_003E5__4 < _003Cresources_003E5__2.Count)
				{
					MyPictureContentView component = Object.Instantiate<GameObject>(endingOmake._picture, endingOmake._open.transform).GetComponent<MyPictureContentView>();
					ResourceLocal resourceLocal = _003Cresources_003E5__2[_003Ci_003E5__4];
					MyPictureContent contentStatic = new MyPictureContent
					{
						Id = resourceLocal.Id,
						Title = resourceLocal.Id,
						FileName = resourceLocal.FileName
					};
					component.SetContentStatic(contentStatic);
					_003CimageIdList_003E5__3.Add(resourceLocal.FileName);
					AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
					UniTask val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartOpen_003Ed__16>(ref val, ref this);
						return;
					}
					goto IL_015f;
				}
				SingletonMonoBehaviour<Settings>.Instance.OpenZip(zipnumber, _003CimageIdList_003E5__3);
				((Component)endingOmake._continue).gameObject.SetActive(true);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(endingOmake._continue), (Action<Unit>)delegate
				{
					SceneManager.LoadScene("BiosToLoad");
				}), (Component)(object)endingOmake._continue);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresources_003E5__2 = null;
				_003CimageIdList_003E5__3 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresources_003E5__2 = null;
			_003CimageIdList_003E5__3 = null;
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
	private int ZIPCOUNT = 30;

	[SerializeField]
	private GameObject chooseZip;

	[SerializeField]
	private GameObject _open;

	[SerializeField]
	private Button _continue;

	[SerializeField]
	private GameObject _zip;

	[SerializeField]
	private GameObject _picture;

	[SerializeField]
	private TMP_Text _openNum;

	private List<GameObject> _zipObjs = new List<GameObject>();

	public bool ChoosingZip => chooseZip.activeInHierarchy;

	public List<GameObject> SelectableObjects => _zipObjs;

	public GameObject ContinueObj => ((Component)_continue).gameObject;

	protected void Start()
	{
		startChooseZip();
	}

	private void startChooseZip()
	{
		chooseZip.SetActive(true);
		bool active = true;
		for (int i = 1; i <= ZIPCOUNT; i++)
		{
			EndingZip z = Object.Instantiate<GameObject>(_zip, chooseZip.transform).GetComponent<EndingZip>();
			bool flag = SingletonMonoBehaviour<Settings>.Instance.unLockedZip.Contains(i);
			z.setData(i, flag);
			if (!flag)
			{
				active = false;
			}
			if (!z.isEmpty)
			{
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(z.button), (Action<Unit>)async delegate
				{
					await startOpen(z.zipNumber);
				}), (Component)(object)z);
			}
			_zipObjs.Add(((Component)z).gameObject);
		}
		((Component)_continue).gameObject.SetActive(active);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_continue), (Action<Unit>)delegate
		{
			SceneManager.LoadScene("BiosToLoad");
		}), (Component)(object)_continue);
	}

	[AsyncStateMachine(typeof(_003CstartOpen_003Ed__16))]
	private UniTask startOpen(int zipnumber)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartOpen_003Ed__16 _003CstartOpen_003Ed__17 = default(_003CstartOpen_003Ed__16);
		_003CstartOpen_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartOpen_003Ed__17._003C_003E4__this = this;
		_003CstartOpen_003Ed__17.zipnumber = zipnumber;
		_003CstartOpen_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartOpen_003Ed__17._003C_003Et__builder)).Start<_003CstartOpen_003Ed__16>(ref _003CstartOpen_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartOpen_003Ed__17._003C_003Et__builder)).Task;
	}
}
