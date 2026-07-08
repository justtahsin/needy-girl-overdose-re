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
		GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Action_Inran>();
		}).AddTo(base.gameObject);
	}

	private void SetLabel()
	{
		label.text = CommandHelper.GetCommandTitle(ActionType.PlayMakeLove, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
