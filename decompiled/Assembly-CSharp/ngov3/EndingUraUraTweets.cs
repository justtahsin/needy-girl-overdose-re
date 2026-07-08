using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class EndingUraUraTweets : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _followButtonLabel;

	[SerializeField]
	private TMP_Text _ameUser;

	[SerializeField]
	private TMP_Text _urauraUser1;

	[SerializeField]
	private TMP_Text _urauraUser2;

	[SerializeField]
	private TMP_Text _urauraUser3;

	[SerializeField]
	private TMP_Text _urauraUser4;

	[SerializeField]
	private TMP_Text _urauraUser5;

	[SerializeField]
	private TMP_Text _urauraTweet1;

	[SerializeField]
	private TMP_Text _urauraTweet2;

	[SerializeField]
	private TMP_Text _urauraTweet3;

	[SerializeField]
	private TMP_Text _urauraTweet4;

	[SerializeField]
	private TMP_Text _urauraTweet5;

	private LanguageType lang;

	private void Awake()
	{
		lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		OnLanguageUpdated();
	}

	public void OnLanguageUpdated()
	{
		string text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_Follower1, lang);
		_followButtonLabel.text = NgoEx.EndingTextFromType(EndingTextType.ZZZ_Ending_Happy_FollowRequest, lang);
		_ameUser.text = text;
		_urauraUser1.text = text;
		_urauraUser2.text = text;
		_urauraUser3.text = text;
		_urauraUser4.text = text;
		_urauraUser5.text = text;
		_urauraTweet1.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_UrauraTweet001, lang);
		_urauraTweet2.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_UrauraTweet002, lang);
		_urauraTweet3.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_UrauraTweet003, lang);
		_urauraTweet4.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_UrauraTweet004, lang);
		_urauraTweet5.text = NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_UrauraTweet005, lang);
	}
}
