using NGO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class App_TextEditor : MonoBehaviour
{
	[SerializeField]
	private TextType nakami;

	[SerializeField]
	private TMP_Text text;

	[SerializeField]
	private Image picture;

	public void Awake()
	{
		if (nakami == TextType.Himitunokoto)
		{
			text.text = NgoEx.SystemTextFromType(SystemTextType.System_secret_Contents, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			SingletonMonoBehaviour<Settings>.Instance.addImage("auto_ending");
		}
		else if (nakami == TextType.NetShutHint)
		{
			text.text = NgoEx.SystemTextFromType(SystemTextType.NetShutHint, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			text.text = NgoEx.TextTypeToText(nakami, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}
}
