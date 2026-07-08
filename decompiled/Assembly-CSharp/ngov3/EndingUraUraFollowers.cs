using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class EndingUraUraFollowers : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _followButtonLabel;

	[SerializeField]
	private TMP_Text _ameUser;

	[SerializeField]
	private TMP_Text _followerLabel;

	[SerializeField]
	private TMP_Text _follower1;

	[SerializeField]
	private TMP_Text _follower2;

	[SerializeField]
	private TMP_Text _follower3;

	private LanguageType lang;

	private void Awake()
	{
		lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		OnLanguageUpdated();
	}

	public void OnLanguageUpdated()
	{
		_followButtonLabel.text = NgoEx.EndingTextFromType(EndingTextType.ZZZ_Ending_Happy_Follow, lang);
		_ameUser.text = NgoEx.SystemTextFromType(SystemTextType.Account_Ura_Name, lang);
		_followerLabel.text = ((lang.ToString() == "JP") ? "フォロワー" : NgoEx.StatusTextFromType(StatusTextType.Status_Follower, lang));
		_follower1.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_Follower3, lang);
		_follower2.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_Follower2, lang);
		_follower3.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_Follower1, lang);
	}
}
