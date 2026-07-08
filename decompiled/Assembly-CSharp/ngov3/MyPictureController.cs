using System.Collections.Generic;
using System.Linq;
using NGO;
using UnityEngine;

namespace ngov3;

public class MyPictureController : MonoBehaviour
{
	[SerializeField]
	private Transform _root;

	[SerializeField]
	private GameObject _prefab;

	private List<string> _gotImagePaths = new List<string>();

	[SerializeField]
	private Sprite defaultSprite;

	private List<MyPictureContentView> _cells = new List<MyPictureContentView>();

	public IReadOnlyList<GameObject> SelectableObjects => _cells.Select((MyPictureContentView cell) => cell.gameObject).ToList();

	protected void Start()
	{
		List<ResourceLocal> list = ImageViewerHelper.LoadResourcesList();
		_gotImagePaths = GotImagePaths();
		for (int i = 0; i < list.Count; i++)
		{
			MyPictureContentView component = Object.Instantiate(_prefab, _root).GetComponent<MyPictureContentView>();
			_cells.Add(component);
		}
		UpdateContents();
	}

	private void UpdateContents()
	{
		List<ResourceLocal> list = ImageViewerHelper.LoadResourcesList();
		for (int i = 0; i < list.Count; i++)
		{
			ResourceLocal resourceLocal = list[i];
			MyPictureContent content = new MyPictureContent
			{
				Id = resourceLocal.Id,
				Title = resourceLocal.Id,
				FileName = (_gotImagePaths.Contains(resourceLocal.FileName) ? resourceLocal.FileName : "NoImagePicture")
			};
			_cells[i].SetContent(content);
		}
	}

	private List<string> GotImagePaths()
	{
		return SingletonMonoBehaviour<Settings>.Instance.imageHistory;
	}

	private void OnDestroy()
	{
		LoadPictures.DeleteCache(LoadPictures.PictureType.MyPicture);
	}
}
