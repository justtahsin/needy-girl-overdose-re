using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class EndingOmake : MonoBehaviour
{
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

	public GameObject ContinueObj => _continue.gameObject;

	protected void Start()
	{
		startChooseZip();
	}

	private void startChooseZip()
	{
		chooseZip.SetActive(value: true);
		bool active = true;
		for (int i = 1; i <= ZIPCOUNT; i++)
		{
			EndingZip z = Object.Instantiate(_zip, chooseZip.transform).GetComponent<EndingZip>();
			bool flag = SingletonMonoBehaviour<Settings>.Instance.unLockedZip.Contains(i);
			z.setData(i, flag);
			if (!flag)
			{
				active = false;
			}
			if (!z.isEmpty)
			{
				z.button.OnClickAsObservable().Subscribe(async delegate
				{
					await startOpen(z.zipNumber);
				}).AddTo(z);
			}
			_zipObjs.Add(z.gameObject);
		}
		_continue.gameObject.SetActive(active);
		_continue.OnClickAsObservable().Subscribe(delegate
		{
			SceneManager.LoadScene("BiosToLoad");
		}).AddTo(_continue);
	}

	private async UniTask startOpen(int zipnumber)
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		chooseZip.SetActive(value: false);
		_open.SetActive(value: true);
		_openNum.text = zipnumber.ToString();
		List<ResourceLocal> resources = ImageViewerHelper.LoadFanArtList();
		List<string> imageIdList = new List<string>();
		for (int i = zipnumber - 1; i < resources.Count; i += ZIPCOUNT)
		{
			MyPictureContentView component = Object.Instantiate(_picture, _open.transform).GetComponent<MyPictureContentView>();
			ResourceLocal resourceLocal = resources[i];
			MyPictureContent contentStatic = new MyPictureContent
			{
				Id = resourceLocal.Id,
				Title = resourceLocal.Id,
				FileName = resourceLocal.FileName
			};
			component.SetContentStatic(contentStatic);
			imageIdList.Add(resourceLocal.FileName);
			AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
			await UniTask.Delay(120);
		}
		SingletonMonoBehaviour<Settings>.Instance.OpenZip(zipnumber, imageIdList);
		_continue.gameObject.SetActive(value: true);
		_continue.OnClickAsObservable().Subscribe(delegate
		{
			SceneManager.LoadScene("BiosToLoad");
		}).AddTo(_continue);
	}
}
