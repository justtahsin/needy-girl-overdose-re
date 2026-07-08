using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class DieMovable : MonoBehaviour
{
	[SerializeField]
	private TMP_Text die;

	public void Awake()
	{
		die.text = NgoEx.SystemTextFromType(SystemTextType.Die, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	public void setRandomPosition()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)this).gameObject.transform;
		RectTransform val = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		Transform transform2 = ((Component)((Transform)val).parent).transform;
		RectTransform val2 = (RectTransform)(object)((transform2 is RectTransform) ? transform2 : null);
		Rect rect = val2.rect;
		float num = Random.Range(0f, ((Rect)(ref rect)).width - val.sizeDelta.x);
		float num2 = 0f + val.sizeDelta.y;
		rect = val2.rect;
		float num3 = Random.Range(num2, ((Rect)(ref rect)).height);
		((Transform)val).localPosition = Vector2.op_Implicit(new Vector2(num, num3));
	}
}
