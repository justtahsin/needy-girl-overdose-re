using NGO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PictureFolder : MonoBehaviour
{
	[SerializeField]
	private int scenarioFolderNumber = -1;

	[SerializeField]
	private int zipNumber = -1;

	[SerializeField]
	private bool isLocked;

	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Sprite lockedSprite;

	[SerializeField]
	private Sprite unlockedSprite;

	public int ScenarioFolderNum => scenarioFolderNumber;

	public int ZipNum => zipNumber;

	public bool IsLocked => isLocked;

	public string labelStr => label.text;

	public Button FolderButton => button;

	public void SetScenarioFolderData(int scenarioFolderNumber)
	{
		this.scenarioFolderNumber = scenarioFolderNumber;
		if (scenarioFolderNumber == 1)
		{
			label.text = NgoEx.SystemTextFromType(SystemTextType.PictureFolder, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			label.text = $"{NgoEx.SystemTextFromType(SystemTextType.PictureFolder, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)} {scenarioFolderNumber - 1}";
		}
		isLocked = false;
		((Selectable)button).interactable = true;
		icon.sprite = unlockedSprite;
	}

	public void SetZipData(int zipNumber, bool isLocked)
	{
		this.zipNumber = zipNumber;
		label.text = zipNumber.ToString();
		this.isLocked = isLocked;
		((Selectable)button).interactable = !isLocked;
		icon.sprite = (isLocked ? lockedSprite : unlockedSprite);
	}
}
