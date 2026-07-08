using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class App_BankView : MonoBehaviour
{
	[SerializeField]
	private Button cover;

	[SerializeField]
	private Animator _anim;

	private const string _animJp = "BankAnimation";

	private const string _animEn = "BankAnimation_Eng";

	private const string _animCn = "BankAnimation_Chn";

	private const string _animKo = "BankAnimation_Kor";

	private const string _black = "_B";

	public async UniTask Awake()
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		string text = "BankAnimation";
		if (value == LanguageType.CN || value == LanguageType.TW)
		{
			text = "BankAnimation_Chn";
		}
		switch (value)
		{
		case LanguageType.KO:
			text = "BankAnimation_Kor";
			break;
		case LanguageType.EN:
		case LanguageType.VN:
		case LanguageType.FR:
		case LanguageType.IT:
		case LanguageType.GE:
		case LanguageType.SP:
		case LanguageType.RU:
			text = "BankAnimation_Eng";
			break;
		}
		if ((SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 6) || SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
		{
			text += "_B";
		}
		_anim.Play(text);
		await UniTask.Yield();
	}
}
