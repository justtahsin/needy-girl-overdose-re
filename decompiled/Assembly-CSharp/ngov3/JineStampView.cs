using System;
using System.Collections.Generic;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineStampView : MonoBehaviour
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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	private void OnLanguageUpdated()
	{
		SetSprite();
	}

	private void SetSprite()
	{
		if (((Component)this).gameObject.transform.childCount > 0)
		{
			_selectableObjects.Clear();
			for (int num = ((Component)this).gameObject.transform.childCount - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)((Component)((Component)this).transform.GetChild(num)).gameObject);
			}
		}
		foreach (StampType type in userStamplist)
		{
			if (type != StampType.None)
			{
				GameObject val = Object.Instantiate<GameObject>(stampBase, ((Component)this).transform);
				val.GetComponent<Image>().sprite = LoadStampData.ReadStampContent(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(val.GetComponent<Button>()), (Action<Unit>)delegate
				{
					sendStamp(type);
				}), val);
				_selectableObjects.Add(val);
			}
		}
	}

	private void sendStamp(StampType s)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Stamp, s, string.Empty));
	}
}
