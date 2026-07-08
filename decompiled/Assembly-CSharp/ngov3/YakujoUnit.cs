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
		if (_namae != null)
		{
			_namae.text = NgoEx.yakujo(type.ToString(), "namae", value);
		}
		if (_tekiryo != null)
		{
			_tekiryo.text = NgoEx.yakujo(type.ToString(), "tekiryo", value);
		}
		if (_kounou != null)
		{
			_kounou.text = NgoEx.yakujo(type.ToString(), "kounou", value);
		}
		if (_hukusayou != null)
		{
			_hukusayou.text = NgoEx.yakujo(type.ToString(), "hukusayou", value);
		}
		if (_memo != null)
		{
			_memo.text = NgoEx.yakujo(type.ToString(), "memo", value);
		}
	}
}
