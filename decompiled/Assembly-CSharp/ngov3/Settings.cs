using System;
using System.Collections.Generic;
using System.Linq;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Settings : SingletonMonoBehaviour<Settings>
{
	public ReactiveProperty<ResolutionType> Resolution = new ReactiveProperty<ResolutionType>(ResolutionType.Toubai);

	public ReactiveProperty<LanguageType> CurrentLanguage = new ReactiveProperty<LanguageType>();

	public ReactiveProperty<VibrationType> VibrationType = new ReactiveProperty<VibrationType>(ngov3.VibrationType.On);

	public float BgmVolume = 0.6f;

	public float SeVolume = 0.8f;

	public bool isChipBGM = true;

	public int haishinSpeed;

	public int saveNumber;

	public string nowSaveFile = "";

	public bool isBackToLoad;

	public List<EndingType> mitaEnd = new List<EndingType>();

	public List<string> imageHistory = new List<string>();

	public List<string> animationKeyHistory = new List<string>();

	private const int ANIMATION_KEY_SAVE_COUNT = 15;

	public List<int> unLockedZip = new List<int>();

	public bool adieu;

	private AsyncSubject<Unit> onLoadSubject = new AsyncSubject<Unit>();

	public IEnumerable<string> NotDuplicateAnimationKeyHistory => animationKeyHistory.Distinct();

	public IObservable<Unit> OnLoadObservable => onLoadSubject;

	private new void Awake()
	{
		if (CheckInstance())
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void ChangeLanguage(LanguageType lang)
	{
		CurrentLanguage.Value = lang;
	}

	public void Save()
	{
		SaveRelayer.SaveSettings(new SettingData
		{
			languageType = CurrentLanguage.Value,
			bgmVolume = BgmVolume,
			seVolume = SeVolume,
			haishinSpeed = haishinSpeed,
			mitaEnd = mitaEnd,
			imageHistory = imageHistory,
			animationKeyHistory = animationKeyHistory,
			unLockedZip = unLockedZip,
			resolution = Resolution.Value,
			vibrationType = VibrationType.Value
		});
		Debug.Log("設定データのセーブが完了しました");
	}

	public bool checkAllZipUnlocked()
	{
		return unLockedZip.Distinct().ToList().Count == 30;
	}

	public void OpenZip(int num, List<string> ImageIdList)
	{
		foreach (string ImageId in ImageIdList)
		{
			if (!imageHistory.Exists((string _) => _ == ImageId))
			{
				imageHistory.Add(ImageId);
			}
		}
		unLockedZip.Add(num);
		Save();
	}

	public void Load()
	{
		SettingData settingData = SaveRelayer.LoadSettings();
		CurrentLanguage.Value = settingData.languageType;
		BgmVolume = settingData.bgmVolume;
		SeVolume = settingData.seVolume;
		haishinSpeed = settingData.haishinSpeed;
		mitaEnd = settingData.mitaEnd;
		imageHistory = settingData.imageHistory;
		animationKeyHistory = settingData.animationKeyHistory;
		unLockedZip = settingData.unLockedZip;
		Resolution.Value = settingData.resolution;
		VibrationType.Value = settingData.vibrationType;
		SetResolution();
		onLoadSubject.OnNext(Unit.Default);
		onLoadSubject.OnCompleted();
		Debug.Log("設定データのロードが完了しました");
	}

	public void AddAnimationKeyHistory(string animationKeyId)
	{
		animationKeyHistory = NotDuplicateAnimationKeyHistory.ToList();
		animationKeyHistory.Where((string aniKey) => aniKey != animationKeyId).ToList();
		if (animationKeyHistory.Count >= 15)
		{
			animationKeyHistory.RemoveAt(0);
		}
		animationKeyHistory.Add(animationKeyId);
		animationKeyHistory = animationKeyHistory.Take(15).ToList();
		Save();
	}

	public void addImage(string ImageId, bool doSave = true)
	{
		if (!imageHistory.Exists((string _) => _ == ImageId))
		{
			imageHistory.Add(ImageId);
			if (doSave)
			{
				Save();
			}
		}
	}

	public void AddCreditImage()
	{
		addImage("Ngocredits_1");
		addImage("Ngocredits_2");
	}

	public void SetResolution()
	{
		switch (Resolution.Value)
		{
		case ResolutionType.FullScreen:
			if (Screen.width / Screen.height > 1)
			{
				Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
			}
			else
			{
				Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen);
			}
			break;
		case ResolutionType.Toubai:
			Screen.SetResolution(960, 540, FullScreenMode.Windowed);
			break;
		case ResolutionType.Window:
			Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
			break;
		}
	}
}
