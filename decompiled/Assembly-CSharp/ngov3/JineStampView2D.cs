using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
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
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
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
			if (type == StampType.None)
			{
				continue;
			}
			GameObject val = Object.Instantiate<GameObject>(stampBase, ((Component)this).transform);
			Button component = val.GetComponent<Button>();
			BoxCollider2D col = val.GetComponent<BoxCollider2D>();
			val.GetComponent<SpriteRenderer>().sprite = LoadStampData.ReadStampContent(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			((UnityEvent)component.onClick).AddListener((UnityAction)async delegate
			{
				if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.EndingDialog))
				{
					((Behaviour)col).enabled = false;
					sendStamp(type);
					await UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					((Behaviour)col).enabled = true;
				}
			});
			_selectableObjects.Add(val);
		}
	}

	private void sendStamp(StampType s)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Stamp, s, string.Empty));
	}
}
