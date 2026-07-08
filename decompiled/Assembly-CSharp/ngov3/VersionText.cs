using TMPro;
using UnityEngine;

namespace ngov3;

public class VersionText : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label;

	private void Start()
	{
		label.text = "v" + Application.version;
	}
}
