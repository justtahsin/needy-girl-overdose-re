using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineStampView2D : MonoBehaviour
{
	[SerializeField]
	private GameObject stampBase;

	private List<StampType> userStamplist = new List<StampType>
	{
		StampType.OK,
		StampType.Saikouka,
		StampType.Pien,
		StampType.Waritodoudemoii,
		StampType.Gomen,
		StampType.Bujisibou,
		StampType.Love,
		StampType.Sorena
	};

	private List<GameObject> _selectableObjects = new List<GameObject>();

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	public void Awake()
	{
		SetSprite();
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	private void OnLanguageUpdated()
	{
		SetSprite();
	}

	private void SetSprite()
	{
		if (base.gameObject.transform.childCount > 0)
		{
			_selectableObjects.Clear();
			for (int num = base.gameObject.transform.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(base.transform.GetChild(num).gameObject);
			}
		}
		foreach (StampType type in userStamplist)
		{
			if (type == StampType.None)
			{
				continue;
			}
			GameObject gameObject = Object.Instantiate(stampBase, base.transform);
			Button component = gameObject.GetComponent<Button>();
			BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
			gameObject.GetComponent<SpriteRenderer>().sprite = LoadStampData.ReadStampContent(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			component.onClick.AddListener(async delegate
			{
				if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.EndingDialog))
				{
					col.enabled = false;
					sendStamp(type);
					await UniTask.Delay(500);
					col.enabled = true;
				}
			});
			_selectableObjects.Add(gameObject);
		}
	}

	private void sendStamp(StampType s)
	{
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Stamp, s, string.Empty));
	}
}
