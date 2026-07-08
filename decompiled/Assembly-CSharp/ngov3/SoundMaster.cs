using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

public class SoundMaster : ScriptableObject
{
	private const string _BANK_PATH = "Assets/_NGO/Sounds/BANK";

	private const string _BGM_LOUD_PATH = "Assets/_NGO/Sounds/BGM_LOUD";

	private const string _BGM_REGULAR_PATH = "Assets/_NGO/Sounds/BGM_REGULAR";

	private const string _BGM_SMALL_PATH = "Assets/_NGO/Sounds/BGM_SMALL";

	private const string _SE_CLICK_PATH = "Assets/_NGO/Sounds/SE_CLICK";

	private const string _SE_LOUD_PATH = "Assets/_NGO/Sounds/SE_LOUD";

	private const string _SE_REGULAR_PATH = "Assets/_NGO/Sounds/SE_REGULAR";

	private const string _BGM_LOUD_NAME = "BGM_LOUD";

	private const string _BGM_REGULAR_NAME = "BGM_REGULAR";

	private const string _BGM_SMALL_NAME = "BGM_SMALL";

	private const string _BANK_NAME = "BANK";

	private const string _SE_CLICK_NAME = "CLICK";

	private const string _SE_LOUD_NAME = "SE_LOUD";

	private const string _SE_REGULAR_NAME = "SE_REGULAR";

	private const string _SE = "SE_";

	public readonly string SE = "SE_";

	private const string _BGM = "BGM_";

	private const string _CLICK = "CLICK_";

	private const string _BANK = "BANK_";

	public List<Sound> SoundList;

	public List<MusicTitle> MusicTitleList;

	public void UpdateMaster()
	{
	}
}
