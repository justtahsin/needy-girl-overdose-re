using TMPro;
using UnityEngine;

namespace ngov3;

public class YakujoUnit : MonoBehaviour
{
	[SerializeField]
	private KusuriType type;

	[SerializeField]
	private TMP_Text _namae;

	[SerializeField]
	private TMP_Text _tekiryo;

	[SerializeField]
	private TMP_Text _kounou;

	[SerializeField]
	private TMP_Text _hukusayou;

	[SerializeField]
	private TMP_Text _memo;

	private void Awake()
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		if ((Object)(object)_namae != (Object)null)
		{
			_namae.text = NgoEx.yakujo(type.ToString(), "namae", value);
		}
		if ((Object)(object)_tekiryo != (Object)null)
		{
			_tekiryo.text = NgoEx.yakujo(type.ToString(), "tekiryo", value);
		}
		if ((Object)(object)_kounou != (Object)null)
		{
			_kounou.text = NgoEx.yakujo(type.ToString(), "kounou", value);
		}
		if ((Object)(object)_hukusayou != (Object)null)
		{
			_hukusayou.text = NgoEx.yakujo(type.ToString(), "hukusayou", value);
		}
		if ((Object)(object)_memo != (Object)null)
		{
			_memo.text = NgoEx.yakujo(type.ToString(), "memo", value);
		}
	}
}
