using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class EndingZip : MonoBehaviour
{
	[SerializeField]
	public int zipNumber;

	[SerializeField]
	public TMP_Text label;

	[SerializeField]
	public bool isEmpty;

	[SerializeField]
	public Button button;

	public void setData(int num, bool isEmpty)
	{
		zipNumber = num;
		label.text = num.ToString();
		this.isEmpty = isEmpty;
		button.interactable = !isEmpty;
	}
}
