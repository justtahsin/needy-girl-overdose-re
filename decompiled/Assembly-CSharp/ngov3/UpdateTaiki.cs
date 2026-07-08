using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class UpdateTaiki : MonoBehaviour
{
	[SerializeField]
	private TMP_Text haisinDetail;

	private int watcher = 110000334;

	private LanguageType _lang;

	private void Awake()
	{
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		UpdateDetail();
	}

	private void UpdateDetail()
	{
		watcher += Random.Range(-1, 2);
		haisinDetail.text = string.Format("{0} {1} ・ {2} {3}", new object[4]
		{
			watcher,
			NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, _lang),
			NgoEx.SystemTextFromType(SystemTextType.Haisin_Started_Day, _lang),
			NgoEx.DayText(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), _lang)
		});
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Meta)
		{
			haisinDetail.text = "0 " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, _lang) + " ・ " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Started_Day, _lang) + " " + NgoEx.DayText(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), _lang);
		}
	}
}
