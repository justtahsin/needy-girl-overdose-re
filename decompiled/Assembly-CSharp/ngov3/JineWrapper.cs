using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineWrapper : MonoBehaviour
{
	[SerializeField]
	private TMP_Text content;

	[SerializeField]
	private LayoutElement layout;

	public void Wrap()
	{
		string text = content.text;
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
		{
			if (text.Length < 29)
			{
				layout.preferredWidth = -1f;
			}
		}
		else
		{
			layout.preferredWidth = -1f;
		}
	}
}
