using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MyPictureController_Sprit : MonoBehaviour
{
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
		returnButton.OnClickAsObservable().Subscribe(delegate
		{
			ReturnToChooseFile();
		}).AddTo(returnButton);
	}

	private void ShowChooseFolder()
	{
		chooseFolder.SetActive(value: true);
		pictureView.SetActive(value: false);
		int num = Mathf.CeilToInt((float)scenarioPicList.Count / (float)scenarioPicturesPerFolder);
		for (int i = 1; i <= num; i++)
		{
			PictureFolder folder = Object.Instantiate(folderPrefab, folderParent);
			folder.SetScenarioFolderData(i);
			if (!folder.IsLocked)
			{
				folder.FolderButton.OnClickAsObservable().Subscribe(async delegate
				{
					await StartOpen(folder);
				}).AddTo(folder);
			}
		}
		for (int num2 = 1; num2 <= ZIPCOUNT; num2++)
		{
			PictureFolder folder2 = Object.Instantiate(folderPrefab, folderParent);
			folder2.SetZipData(num2, !SingletonMonoBehaviour<Settings>.Instance.unLockedZip.Contains(num2));
			if (!folder2.IsLocked)
			{
				folder2.FolderButton.OnClickAsObservable().Subscribe(async delegate
				{
					await StartOpen(folder2);
				}).AddTo(folder2);
			}
		}
	}

	private async UniTask StartOpen(PictureFolder folder)
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		chooseFolder.SetActive(value: false);
		pictureView.SetActive(value: true);
		openFolderText.text = folder.labelStr.ToString();
		if (folder.ScenarioFolderNum > 0)
		{
			for (int i = (folder.ScenarioFolderNum - 1) * scenarioPicturesPerFolder; i < folder.ScenarioFolderNum * scenarioPicturesPerFolder && i < scenarioPicList.Count; i++)
			{
				MyPictureContentView myPictureContentView = Object.Instantiate(picturePrefab, pictureParent);
				pictureInstances.Add(myPictureContentView.gameObject);
				ResourceLocal resourceLocal = scenarioPicList[i];
				MyPictureContent content = new MyPictureContent
				{
					Id = resourceLocal.Id,
					Title = resourceLocal.Id,
					FileName = (_gotImagePaths.Contains(resourceLocal.FileName) ? resourceLocal.FileName : "NoImagePicture")
				};
				myPictureContentView.SetContent(content).Forget();
			}
		}
		else if (folder.ZipNum > 0)
		{
			for (int j = folder.ZipNum - 1; j < fanartList.Count; j += ZIPCOUNT)
			{
				MyPictureContentView myPictureContentView2 = Object.Instantiate(picturePrefab, pictureParent);
				pictureInstances.Add(myPictureContentView2.gameObject);
				ResourceLocal resourceLocal2 = fanartList[j];
				MyPictureContent content2 = new MyPictureContent
				{
					Id = resourceLocal2.Id,
					Title = resourceLocal2.Id,
					FileName = resourceLocal2.FileName
				};
				myPictureContentView2.SetContent(content2).Forget();
			}
		}
	}

	private void ReturnToChooseFile()
	{
		chooseFolder.SetActive(value: true);
		pictureView.SetActive(value: false);
		foreach (GameObject pictureInstance in pictureInstances)
		{
			Object.Destroy(pictureInstance);
		}
		pictureInstances.Clear();
		LoadPictures.DeleteCache(LoadPictures.PictureType.MyPicture);
	}

	private List<string> GotImagePaths()
	{
		return SingletonMonoBehaviour<Settings>.Instance.imageHistory;
	}
}
