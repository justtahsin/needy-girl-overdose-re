using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ActionButtonInran : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label;

	public void Awake()
	{
		SetLabel();
	}

	public void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).GetComponent<Button>()), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Action_Inran>();
		}), ((Component)this).gameObject);
	}

	private void SetLabel()
	{
		label.text = CommandHelper.GetCommandTitle(ActionType.PlayMakeLove, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
