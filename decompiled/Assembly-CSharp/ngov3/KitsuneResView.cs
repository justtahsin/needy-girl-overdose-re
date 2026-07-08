using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KitsuneResView : MonoBehaviour
{
	[SerializeField]
	private RectTransform _rectTr;

	[SerializeField]
	private TMP_Text _resNumber;

	[SerializeField]
	private TMP_Text _handleName;

	[SerializeField]
	private TMP_Text _honbun;

	[SerializeField]
	private Text _AA;

	public void SetData(string handleName, int resNumber, string honbun)
	{
		_handleName.text = handleName;
		_resNumber.text = $"{resNumber}：";
		_honbun.text = honbun;
		SetHeight();
	}

	public void SetHonbun(string honbun)
	{
		_honbun.text = honbun;
		SetHeight();
	}

	public void SetResNumber(int resNumber)
	{
		_resNumber.text = $"{resNumber}：";
	}

	private void SetHeight()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		Vector2 sizeDelta = _rectTr.sizeDelta;
		float num = 34f;
		sizeDelta.y = _honbun.preferredHeight + num;
		if ((Object)(object)_AA != (Object)null)
		{
			sizeDelta.y += _AA.preferredHeight;
		}
		_rectTr.sizeDelta = sizeDelta;
	}
}
