using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ngov3;

public class EventChooser : MonoBehaviour
{
	private List<string> events = new List<string>
	{
		"-----------------", "Event_ImageTest", "----tests----------------", "----各配信ネタをLevelごとに全て取得----------------", "Test_GetLevel1Neta", "Test_GetLevel2Neta", "Test_GetLevel3Neta", "Test_GetLevel4Neta", "Test_GetLevel5Neta", "----Jineを全て取得----------------",
		"Test_ShowAllJine", "----Poketterを全て取得----------------", "Test_ShowAllPoketter", "----Kusorepを全て取得----------------", "Test_ShowAllKusorep", "----IDを入力して確認------", "入力IDのPoketter表示", "入力IDのJine表示", "---------追加特殊デバッグ------", "UtopianParodyのDay15長文Jine既読フラグ3番目入れる",
		"マイピクチャを全部解放", "トロフィーテストシーンへ遷移", "実績を獲得「Ending_Jisatuhoujo」", "ゲームスピードを1/2に", "ゲームスピードを2倍速に", "ゲームスピードを3倍速に", "ゲームスピードを20倍速に", "---------ステータス調整------", "あめちゃんのストレスを１０増やす", "あめちゃんのストレスを１０減らす",
		"フォロワーを１００００増やす", "----endings--------------", "Action_OdekakeGinga", "Ending_Ideon", "Ending_Completed", "Ending_Grand", "Ending_Happy", "Ending_Meta", "Ending_Normal", "Ending_Bad",
		"Ending_Work", "Ending_Needy", "Ending_Yami", "Ending_Av", "Ending_Healthy", "Ending_Lust", "Ending_Ntr", "Ending_Sukisuki", "Ending_Stressful", "Ending_Sucide",
		"Ending_Yarisute", "Ending_Kyouso", "Ending_NetShut", "Event_Jisatumisui", "Ura_internatAngel", "Ending_DarkAngel", "Ending_Jikka", "---------Ending_Jine(ignore jine 5times)", "---------Ending_KowaiInternet------", "Scenario_horror_day1_day",
		"Scenario_horror_day2_day", "Scenario_horror_day3_day", "Scenario_horror_day4_day", "Scenario_horror_day5_day", "----noon-events-----------", "------------------nichijou", "Event_AmePiercerd", "Event_Fetish", "Event_Haikuwoyome", "Event_Hairstyle",
		"Event_Instead", "Event_Kurorekishi", "Event_Money", "Event_MuchaGag", "Event_NextDate", "Event_Pudding", "Event_Sea", "Event_Seikei", "Event_Suki10", "Event_Test",
		"Event_UberEats", "Event_Yutabon", "Event_AmeFuture", "Event_Charahen", "Event_Sumabura", "Event_Yandeiru", "Event_AyasiiSystem_GotMail", "------------------YamiLow", "Kenjo_4", "Kenjo_3",
		"Kenjo_2", "Kenjo_1", "------------------SFHigh", "StressHi_FollowHi_1", "StressHi_FollowHi_2", "StressHi_FollowHi_3", "StressHi_FollowHi_4", "------------------YFHigh", "YamiHi_FollowHi_3", "YamiHi_FollowHi_4",
		"YamiHi_FollowHi_5", "------------------YLHigh", "YamiHi_SukiHi_1", "YamiHi_SukiHi_2", "YamiHi_SukiHi_3", "YamiHi_SukiHi_4", "------------------FHigh", "Event_Copyceleb", "Event_Dox", "Event_MailInterview",
		"Event_MenheraFriend", "------------------FollowerLow", "Event_Anxiety", "Event_Approval", "Event_Choudare", "Event_Kasoworry", "Event_Urge", "----JINEの入力欄イベントの確認--------------", "Event_Pinojien", "------------------StressHigh",
		"Event_Damon", "Event_HelpJINE", "Event_Limit", "Event_Okiru_Afternoon", "Event_Okiru_Night", "Event_Egosastop", "Status_Stress1_Day", "Status_Stress1_Night", "Status_Stress2_Day", "Status_Stress2_Night",
		"------------------haishinsitenai", "Event_HaishinSiyou", "------------------StressLow", "Event_Newthings", "Event_Nickname", "Event_Watchword", "------------------LoveHigh", "Event_Antherline", "Event_Gameholic", "Event_Hemp",
		"Event_LoveJINE", "Event_Manicure", "Event_MentalCare", "Event_Sokubaku", "Event_Chyoroin", "Event_DateHolic", "Event_Okusan", "------------------LoveLow", "Event_Doubt", "Event_Singlebed",
		"Event_Suggest", "------------------YamiHigh", "Ending_Megaten", "Event_4timesJINE", "Event_Amecalling_Kowai", "Event_Brokenphone", "Event_Negativ", "Event_DrugHolic", "------------------YamiLow", "Event_Advice",
		"Event_Amecalling_Kawaii", "Event_Cheerup", "Event_Flower", "----scenario-day------", "Scenario_loop1_day0_night", "Scenario_loop1_day1_day", "Scenario_Yachin", "Event_Wishlist_day1", "Event_Wishlist_day2_1", "Event_Wishlist_day2_2",
		"Event_Wishlist_day2_3", "Event_Wishlist_day2_4", "Event_Day20", "Event_MV_shuroku", "Event_MV_koukai", "----Scenario-midnight----------------", "Scenario_Yachin_Aseri", "Scenario_Achieved_Aim", "Scenario_start_follower_high", "Scenario_start_follower_low",
		"Event_LongLine", "Scenario_trauma_bimyou", "Scenario_trauma_saiaku", "Scenario_trauma_pigaiya", "Scenario_happa_yamitoraikeike", "Scenario_happa_yamihateikeike", "Scenario_happa_yamitora", "Scenario_happa_yamihate", "Scenario_happa_kentoraikeike", "Scenario_happa_kenhateikeike",
		"Scenario_happa_kentora", "Scenario_happa_kenhate", "Scenario_topstreamer_yadakenjoikeike", "Scenario_topstreamer_trahappa", "Scenario_topstreamer_trakenjo", "Scenario_jikka", "Scenario_topstreamer_trahappaikeike", "Scenario_topstreamer_trahappaikeikeatonobi", "Scenario_topstreamer_trakenjoikeike", "Scenario_topstreamer_trakenjoikeikeatonobi",
		"Scenario_topstreamer_yadahappakeike", "Scenario_topstreamer_yadahappakeikeatonobi", "Scenario_topstreamer_yadahappa", "Scenario_topstreamer_yadakenjo", "Event_jinsei0", "Event_jinsei1", "Event_jinsei2", "Event_jinsei3", "Event_jinsei4", "Event_Nerarenai_Night",
		"----idea-get----------------------", "Scenario_Angel1", "Scenario_Angel2", "Scenario_Angel3", "Scenario_Angel4", "Scenario_Angel5", "Scenario_Angel6", "ChipGet_ASMR_1", "ChipGet_ASMR_2", "ChipGet_ASMR_3",
		"ChipGet_ASMR_4", "ChipGet_ASMR_5", "ChipGet_Darkness_1", "ChipGet_Darkness_2", "ChipGet_Gamejikkyou_1", "ChipGet_Gamejikkyou_2", "ChipGet_Gamejikkyou_3", "ChipGet_Gamejikkyou_4", "ChipGet_Gamejikkyou_5", "ChipGet_Hnahaisin_1",
		"ChipGet_Hnahaisin_2", "ChipGet_Hnahaisin_3", "ChipGet_Hnahaisin_4", "ChipGet_Hnahaisin_5", "ChipGet_Imbouron_1", "ChipGet_Imbouron_2", "ChipGet_Imbouron_3", "ChipGet_Imbouron_4", "ChipGet_Imbouron_5", "ChipGet_Kaidan_1",
		"ChipGet_Kaidan_2", "ChipGet_Kaidan_3", "ChipGet_Kaidan_4", "ChipGet_Kaidan_5", "ChipGet_Kaisetu_1", "ChipGet_Kaisetu_2", "ChipGet_Kaisetu_3", "ChipGet_Kaisetu_4", "ChipGet_Kaisetu_5", "ChipGet_Otakutalk_1",
		"ChipGet_Otakutalk_2", "ChipGet_Otakutalk_3", "ChipGet_Otakutalk_4", "ChipGet_Otakutalk_5", "ChipGet_PR_1", "ChipGet_PR_2", "ChipGet_PR_3", "ChipGet_PR_4", "ChipGet_PR_5", "ChipGet_Taiken_1",
		"ChipGet_Taiken_2", "ChipGet_Taiken_3", "ChipGet_Taiken_4", "ChipGet_Taiken_5", "ChipGet_Yamihaishin_1", "ChipGet_Yamihaishin_2", "ChipGet_Yamihaishin_3", "ChipGet_Yamihaishin_4", "ChipGet_Yamihaishin_5", "ChipGet_Zatudan_1",
		"ChipGet_Zatudan_2", "ChipGet_Zatudan_3", "ChipGet_Zatudan_4", "ChipGet_Zatudan_5", "--------------", "Action_OkusuriPsyche"
	};

	[SerializeField]
	private Text selectedEvent;

	[SerializeField]
	private InputField inputValue;

	private Dropdown ddtmp;

	private void Start()
	{
		ddtmp = ((Component)this).GetComponent<Dropdown>();
		ddtmp.AddOptions(events);
	}

	private void Update()
	{
	}

	public async void OnSelected()
	{
		Dropdown component = ((Component)this).GetComponent<Dropdown>();
		string text = component.options[component.value].text;
		if (text == "入力IDのPoketter表示")
		{
			Enum.TryParse<TweetType>(inputValue.text, out var result);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(result);
		}
		if (text == "実績を獲得「Ending_Jisatuhoujo」")
		{
			AchievementStatsUpdater.UpdateStats("Ending_Jisatuhoujo");
		}
		if (text == "トロフィーテストシーンへ遷移")
		{
			SceneManager.LoadScene("TrophySampleScene");
		}
		if (text == "入力IDのJine表示")
		{
			Enum.TryParse<JineType>(inputValue.text, out var result2);
			UniTaskExtensions.Forget(SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(result2));
		}
		switch (text)
		{
		case "UtopianParodyのDay15長文Jine既読フラグ3番目入れる":
			SingletonMonoBehaviour<EventManager>.Instance.Trauma = JineType.Event_LongLINE003;
			return;
		case "マイピクチャを全部解放":
			ReleaseAllMyPict();
			return;
		case "ゲームスピードを1/2に":
			Time.timeScale = 0.5f;
			break;
		}
		if (text == "ゲームスピードを2倍速に")
		{
			Time.timeScale = 2f;
		}
		if (text == "ゲームスピードを3倍速に")
		{
			Time.timeScale = 3f;
		}
		if (text == "ゲームスピードを20倍速に")
		{
			Time.timeScale = 20f;
		}
		if (text == "あめちゃんのストレスを１０増やす")
		{
			UniTaskExtensions.Forget(SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 10));
			ResetSelect();
		}
		if (text == "あめちゃんのストレスを１０減らす")
		{
			UniTaskExtensions.Forget(SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -10));
			ResetSelect();
		}
		if (text == "フォロワーを１００００増やす")
		{
			UniTaskExtensions.Forget(SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Follower, 10000));
			ResetSelect();
		}
		if (text == "Scenario_horror_day1_day")
		{
			SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
			List<Status> newStatus = GetNewStatus(25);
			SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(newStatus);
		}
		if (text == "Scenario_horror_day2_day")
		{
			SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
			List<Status> newStatus2 = GetNewStatus(26);
			SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(newStatus2);
		}
		if (text == "Scenario_horror_day3_day")
		{
			SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
			List<Status> newStatus3 = GetNewStatus(27);
			SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(newStatus3);
		}
		if (text == "Scenario_horror_day4_day")
		{
			SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
			List<Status> newStatus4 = GetNewStatus(28);
			SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(newStatus4);
		}
		if (text == "Scenario_horror_day5_day")
		{
			SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
			List<Status> newStatus5 = GetNewStatus(29);
			SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(newStatus5);
		}
		Debug.Log((object)("デバッグEventが選択された：" + text));
		SingletonMonoBehaviour<EventManager>.Instance.ForceEventFlagOff();
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent(text);
		selectedEvent.text = text;
	}

	private async void ResetSelect()
	{
		((Selectable)ddtmp).Select();
		ddtmp.value = 0;
		((Component)ddtmp).gameObject.SetActive(false);
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		((Component)ddtmp).gameObject.SetActive(true);
	}

	private List<Status> GetNewStatus(int dayIndex)
	{
		return new List<Status>
		{
			new Status(StatusType.Tension, 50, 100),
			new Status(StatusType.Follower, 1, 9999999),
			new Status(StatusType.Wadaisei, 100, 500, 100, dispAsPercent: true),
			new Status(StatusType.Stress, 5, 100),
			new Status(StatusType.Love, 40, 100),
			new Status(StatusType.Yami, 15, 100),
			new Status(StatusType.OkusuriedCounter, 0, 60),
			new Status(StatusType.OirokeCounter, 0, 60),
			new Status(StatusType.RenzokuHaishinCount, 0, 30),
			new Status(StatusType.SNSzizenKokutiBonus, 0, 2),
			new Status(StatusType.GameCountBonus, 0, 60),
			new Status(StatusType.CinePhillCountBonus, 0, 60),
			new Status(StatusType.DougaTVShabekuriCountBonus, 0, 90),
			new Status(StatusType.MadeLoveCounter, 0, 30),
			new Status(StatusType.Harumagedo, 0, 100),
			new Status(StatusType.DayIndex, dayIndex, 30),
			new Status(StatusType.DayPart, 2, 3),
			new Status(StatusType.testAlphaLevel, 1, 5)
		};
	}

	private void ReleaseAllMyPict()
	{
		int num = 100;
		for (int i = 0; i < num; i++)
		{
			SingletonMonoBehaviour<Settings>.Instance.unLockedZip.Add(i);
		}
	}
}
