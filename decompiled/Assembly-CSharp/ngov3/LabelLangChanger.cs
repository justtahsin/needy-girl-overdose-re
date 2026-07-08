using NGO;
using TMPro;
using UniRx;
using UnityEngine;

namespace ngov3;

public class LabelLangChanger : MonoBehaviour
{
	public SystemTextType type;

	[SerializeField]
	private TMP_Text label;

	public void Start()
	{
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			AddLabel();
		}).AddTo(base.gameObject);
		AddLabel();
	}

	private void AddLabel()
	{
		if (!(label == null))
		{
			label.text = NgoEx.SystemTextFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}
}
