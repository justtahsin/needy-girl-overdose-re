using System;
using System.Collections.Generic;
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

public class MyPictureController_Sprit : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartOpen_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public MyPictureController_Sprit _003C_003E4__this;

		public PictureFolder folder;

		private void MoveNext()
		{
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			MyPictureController_Sprit myPictureController_Sprit = _003C_003E4__this;
			try
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
				myPictureController_Sprit.chooseFolder.SetActive(false);
				myPictureController_Sprit.pictureView.SetActive(true);
				myPictureController_Sprit.openFolderText.text = folder.labelStr.ToString();
				UniTaskVoid val;
				if (folder.ScenarioFolderNum > 0)
				{
					for (int i = (folder.ScenarioFolderNum - 1) * myPictureController_Sprit.scenarioPicturesPerFolder; i < folder.ScenarioFolderNum * myPictureController_Sprit.scenarioPicturesPerFolder && i < myPictureController_Sprit.scenarioPicList.Count; i++)
					{
						MyPictureContentView myPictureContentView = Object.Instantiate<MyPictureContentView>(myPictureController_Sprit.picturePrefab, myPictureController_Sprit.pictureParent);
						myPictureController_Sprit.pictureInstances.Add(((Component)myPictureContentView).gameObject);
						ResourceLocal resourceLocal = myPictureController_Sprit.scenarioPicList[i];
						MyPictureContent content = new MyPictureContent
						{
							Id = resourceLocal.Id,
							Title = resourceLocal.Id,
							FileName = (myPictureController_Sprit._gotImagePaths.Contains(resourceLocal.FileName) ? resourceLocal.FileName : "NoImagePicture")
						};
						val = myPictureContentView.SetContent(content);
						((UniTaskVoid)(ref val)).Forget();
					}
				}
				else if (folder.ZipNum > 0)
				{
					for (int j = folder.ZipNum - 1; j < myPictureController_Sprit.fanartList.Count; j += myPictureController_Sprit.ZIPCOUNT)
					{
						MyPictureContentView myPictureContentView2 = Object.Instantiate<MyPictureContentView>(myPictureController_Sprit.picturePrefab, myPictureController_Sprit.pictureParent);
						myPictureController_Sprit.pictureInstances.Add(((Component)myPictureContentView2).gameObject);
						ResourceLocal resourceLocal2 = myPictureController_Sprit.fanartList[j];
						MyPictureContent content2 = new MyPictureContent
						{
							Id = resourceLocal2.Id,
							Title = resourceLocal2.Id,
							FileName = resourceLocal2.FileName
						};
						val = myPictureContentView2.SetContent(content2);
						((UniTaskVoid)(ref val)).Forget();
					}
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
	private int ZIPCOUNT = 30;

	[SerializeField]
	private GameObject chooseFolder;

	[SerializeField]
	private Transform folderParent;

	[SerializeField]
	private PictureFolder folderPrefab;

	[SerializeField]
	private GameObject pictureView;

	[SerializeField]
	private Transform pictureParent;

	[SerializeField]
	private MyPictureContentView picturePrefab;

	[SerializeField]
	private Button returnButton;

	[SerializeField]
	private TMP_Text openFolderText;

	private List<ResourceLocal> scenarioPicList;

	private List<ResourceLocal> fanartList;

	private List<string> _gotImagePaths = new List<string>();

	private List<GameObject> pictureInstances = new List<GameObject>();

	private int scenarioPicturesPerFolder = 11;

	private int zipPicturesPerFolder;

	private void Start()
	{
		List<ResourceLocal> source = ImageViewerHelper.LoadResourcesList();
		fanartList = source.Where((ResourceLocal r) => r.Id.StartsWith("@")).ToList();
		scenarioPicList = source.Where((ResourceLocal r) => !r.Id.StartsWith("@")).ToList();
		zipPicturesPerFolder = Mathf.CeilToInt((float)fanartList.Count / (float)ZIPCOUNT);
		_gotImagePaths = GotImagePaths();
		ShowChooseFolder();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(returnButton), (Action<Unit>)delegate
		{
			ReturnToChooseFile();
		}), (Component)(object)returnButton);
	}

	private void ShowChooseFolder()
	{
		chooseFolder.SetActive(true);
		pictureView.SetActive(false);
		int num = Mathf.CeilToInt((float)scenarioPicList.Count / (float)scenarioPicturesPerFolder);
		for (int i = 1; i <= num; i++)
		{
			PictureFolder folder = Object.Instantiate<PictureFolder>(folderPrefab, folderParent);
			folder.SetScenarioFolderData(i);
			if (!folder.IsLocked)
			{
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(folder.FolderButton), (Action<Unit>)async delegate
				{
					await StartOpen(folder);
				}), (Component)(object)folder);
			}
		}
		for (int num2 = 1; num2 <= ZIPCOUNT; num2++)
		{
			PictureFolder folder2 = Object.Instantiate<PictureFolder>(folderPrefab, folderParent);
			folder2.SetZipData(num2, !SingletonMonoBehaviour<Settings>.Instance.unLockedZip.Contains(num2));
			if (!folder2.IsLocked)
			{
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(folder2.FolderButton), (Action<Unit>)async delegate
				{
					await StartOpen(folder2);
				}), (Component)(object)folder2);
			}
		}
	}

	[AsyncStateMachine(typeof(_003CStartOpen_003Ed__17))]
	private UniTask StartOpen(PictureFolder folder)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CStartOpen_003Ed__17 _003CStartOpen_003Ed__18 = default(_003CStartOpen_003Ed__17);
		_003CStartOpen_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartOpen_003Ed__18._003C_003E4__this = this;
		_003CStartOpen_003Ed__18.folder = folder;
		_003CStartOpen_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartOpen_003Ed__18._003C_003Et__builder)).Start<_003CStartOpen_003Ed__17>(ref _003CStartOpen_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartOpen_003Ed__18._003C_003Et__builder)).Task;
	}

	private void ReturnToChooseFile()
	{
		chooseFolder.SetActive(true);
		pictureView.SetActive(false);
		foreach (GameObject pictureInstance in pictureInstances)
		{
			Object.Destroy((Object)(object)pictureInstance);
		}
		pictureInstances.Clear();
		LoadPictures.DeleteCache(LoadPictures.PictureType.MyPicture);
	}

	private List<string> GotImagePaths()
	{
		return SingletonMonoBehaviour<Settings>.Instance.imageHistory;
	}
}
