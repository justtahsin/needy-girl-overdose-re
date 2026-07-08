using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public static class HaishinFirstAnimation
{
	private static CancellationTokenSource cts;

	public static async UniTask LoadHaishinFirstAnimation()
	{
		EventManager instance = SingletonMonoBehaviour<EventManager>.Instance;
		StatusManager instance2 = SingletonMonoBehaviour<StatusManager>.Instance;
		if (!(instance == null) && !(instance2 == null))
		{
			string text = ((instance.nowEnding != EndingType.Ending_None) ? GetEndingHaishinFirstAnimationKey(instance.nowEnding) : ((instance2.GetStatus(StatusType.DayIndex) == 1) ? "stream_cho_kashikoma" : ((!instance.isHorror) ? GetNormalHaishinFirstAnimationKey(instance.alpha, instance.alphaLevel) : GetHorrorHaishinFirstAnimationKey(instance2.GetStatus(StatusType.DayIndex)))));
			if (!string.IsNullOrEmpty(text))
			{
				cts = new CancellationTokenSource();
				await LoadLiveViewData.LoadAnimation(text + ".anim", cts.Token);
				cts.Dispose();
				cts = null;
			}
		}
	}

	public static void CancelLoading()
	{
		if (cts != null)
		{
			cts.Cancel();
			cts.Dispose();
			cts = null;
		}
	}

	private static string GetEndingHaishinFirstAnimationKey(EndingType type)
	{
		switch (type)
		{
		case EndingType.Ending_Grand:
			return "stream_cho_grandend1";
		case EndingType.Ending_Kyouso:
			return "stream_cho_kyouso1";
		case EndingType.Ending_Ntr:
			return "stream_cho_ntr1";
		case EndingType.Ending_Sucide:
			return "stream_cho_sayonara1";
		case EndingType.Ending_Happy:
			return "stream_cho_kashikoma";
		case EndingType.Ending_KowaiInternet:
			return "stream_cho_horror_iei";
		case EndingType.Ending_Ideon:
			return "stream_cho_kashikoma";
		case EndingType.Ending_Ginga:
			return "stream_cho_g_express1";
		case EndingType.Ending_DarkAngel:
			return "stream_cho_b_idle2_1";
		case EndingType.Ending_Completed:
		{
			EventManager instance = SingletonMonoBehaviour<EventManager>.Instance;
			StatusManager instance2 = SingletonMonoBehaviour<StatusManager>.Instance;
			if (!(instance == null) && !(instance2 == null))
			{
				return GetNormalHaishinFirstAnimationKey(instance.alpha, instance.alphaLevel);
			}
			break;
		}
		}
		return "";
	}

	private static string GetHorrorHaishinFirstAnimationKey(int day)
	{
		return day switch
		{
			25 => "stream_cho_kashikoma", 
			26 => "stream_cho_kashikoma", 
			27 => "stream_cho_bad", 
			28 => "stream_cho_horror_kashikoma", 
			29 => "stream_cho_horror_iei", 
			_ => "", 
		};
	}

	private static string GetNormalHaishinFirstAnimationKey(AlphaType type, int level)
	{
		switch (type)
		{
		case AlphaType.Zatudan:
			switch (level)
			{
			case 1:
				return "stream_cho_akaruku";
			case 2:
				return "stream_cho_akaruku";
			case 3:
				return "stream_cho_eeto";
			case 4:
				return "stream_cho_akaruku";
			case 5:
				return "stream_cho_teach";
			}
			break;
		case AlphaType.Gamejikkyou:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma";
			case 2:
				return "stream_cho_su_superchat";
			case 3:
				return "stream_cho_game_ape1";
			case 4:
				return "stream_cho_game_twilight1";
			case 5:
				return "stream_cho_game_sayo1";
			}
			break;
		case AlphaType.Otakutalk:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma_otaku";
			case 2:
				return "stream_cho_gaoo";
			case 3:
				return "stream_cho_teach";
			case 4:
				return "stream_cho_kobiru_superchat";
			case 5:
				return "stream_cho_eeto";
			}
			break;
		case AlphaType.Imbouron:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma";
			case 2:
				return "stream_cho_kashikoma";
			case 3:
				return "stream_cho_eeto";
			case 4:
				return "stream_cho_grgr3";
			case 5:
				return "stream_cho_akaruku_superchat";
			}
			break;
		case AlphaType.Kaidan:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma";
			case 2:
				return "stream_cho_dokuzetsu_superchat";
			case 3:
				return "stream_cho_pout";
			case 4:
				return "stream_cho_eeto";
			case 5:
				return "stream_cho_eeto";
			}
			break;
		case AlphaType.ASMR:
			switch (level)
			{
			case 1:
				return "stream_cho_asmr1";
			case 2:
				return "stream_cho_asmr2";
			case 3:
				return "stream_cho_asmr1";
			case 4:
				return "stream_cho_asmr4";
			case 5:
				return "stream_cho_balanceball_asmr";
			}
			break;
		case AlphaType.Hnahaisin:
			switch (level)
			{
			case 1:
				return "stream_cho_akaruku_superchat";
			case 2:
				return "stream_cho_kashikoma";
			case 3:
				return "stream_cho_ice1";
			case 4:
				return "stream_cho_kashikoma";
			}
			break;
		case AlphaType.Kaisetu:
			switch (level)
			{
			case 1:
				return "stream_cho_yukkuri_idle";
			case 2:
				return "stream_cho_yukkuri_smile";
			case 3:
				return "stream_cho_yukkuri_idle";
			case 4:
				return "stream_cho_yukkuri_cry";
			case 5:
				return "stream_cho_yukkuri_teach";
			}
			break;
		case AlphaType.Taiken:
			switch (level)
			{
			case 1:
				return "stream_cho_kakkoyoku_superchat";
			case 2:
				return "stream_cho_dokuzetsu_fever";
			case 3:
				return "stream_cho_pointing_microphone";
			case 4:
				return "stream_cho_kobiru_superchat";
			case 5:
				return "stream_cho_kashikoma";
			}
			break;
		case AlphaType.Yamihaishin:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma";
			case 2:
				return "stream_cho_pout";
			case 3:
				return "stream_cho_pout";
			case 4:
				return "stream_cho_kashikoma";
			case 5:
				return "stream_ame_yanda_carisma";
			}
			break;
		case AlphaType.PR:
			switch (level)
			{
			case 1:
				return "stream_cho_akaruku_superchat";
			case 2:
				return "stream_cho_anken_make1";
			case 3:
				return "stream_cho_anken_game1";
			case 4:
				return "stream_cho_anken_figure1";
			case 5:
				return "stream_cho_anken_business1";
			}
			break;
		case AlphaType.Angel:
			switch (level)
			{
			case 1:
				return "stream_cho_kashikoma";
			case 2:
				return "stream_cho_kashikoma";
			case 3:
				return "stream_cho_kobiru_fever";
			case 4:
				return "stream_cho_peace";
			case 5:
				return "stream_cho_angel";
			case 6:
				return "stream_cho_b_angle";
			}
			break;
		case AlphaType.Darkness:
			switch (level)
			{
			case 1:
				return "stream_cho_pout";
			case 2:
				return "stream_cho_craziness1";
			}
			break;
		}
		return null;
	}
}
