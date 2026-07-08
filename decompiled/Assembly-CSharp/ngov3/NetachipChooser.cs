using System;
using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class NetachipChooser : MonoBehaviour
{
	public int MAXCHIPSHOWING = 10;

	[SerializeField]
	private Button StartButton;

	[SerializeField]
	private TMP_Text StartButtonText;

	[SerializeField]
	private TMP_Text GuideText;

	public AlphaType ChoosedAlphaType = AlphaType.none;

	public int level;

	[SerializeField]
	private GameObject AlphaButton;

	public BetaType ChoosedBetaType = BetaType.none;

	[SerializeField]
	private Button BetaButton;

	[SerializeField]
	private Image bg;

	[SerializeField]
	private Sprite AlphaChoosingbg;

	[SerializeField]
	private Sprite BetaChoosingbg;

	public ChoosingStatus status;

	public int nowPage;

	[SerializeField]
	private Transform ChipChoosingParent;

	[SerializeField]
	private GameObject KaimakuParent;

	[SerializeField]
	private Transform PagingParent;

	[SerializeField]
	private Button PagingPrev;

	[SerializeField]
	private Button PagingNext;

	[SerializeField]
	private GameObject PageNowPrefab;

	[SerializeField]
	private GameObject PagePrefab;

	private int alphaMaxPage;

	private int betaMaxPage;

	private TooltipCaller _tooltipCaller;

	[SerializeField]
	private Button backButton;

	[SerializeField]
	private GameObject AlphaPrefab;

	private List<GameObject> _selectableObjects = new List<GameObject>();

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	private void Awake()
	{
		_tooltipCaller = ((Component)this).GetComponent<TooltipCaller>();
		AlphaButton.gameObject.SetActive(false);
		ChoosedAlphaType = AlphaType.none;
		level = 0;
		status = ChoosingStatus.alpha;
		if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
		{
			ShowAlphaLevelChip();
		}
		else
		{
			ShowAlphaChip(0);
		}
		((Component)backButton).gameObject.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Reselect, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void CleanChilds()
	{
		_selectableObjects.Clear();
		for (int num = ChipChoosingParent.childCount - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)((Component)ChipChoosingParent.GetChild(num)).gameObject);
		}
	}

	private void ShowAlphaLevelChip()
	{
		ChoosedAlphaType = AlphaType.none;
		level = 0;
		AlphaButton.gameObject.SetActive(false);
		status = ChoosingStatus.alpha;
		((Component)ChipChoosingParent).gameObject.SetActive(true);
		KaimakuParent.SetActive(false);
		CleanChilds();
		int num = Enum.GetNames(typeof(AlphaType)).Length - 1;
		for (int i = 0; i < MAXCHIPSHOWING; i++)
		{
			if (i <= num)
			{
				GameObject obj = Object.Instantiate<GameObject>(AlphaPrefab, ChipChoosingParent);
				int alphaLevel = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.testAlphaLevel);
				bool isUsed = false;
				obj.GetComponent<NetaChipAlpha>().SetData(i, alphaLevel, isUsed);
			}
		}
	}

	private void ShowAlphaChip(int page)
	{
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) < 4)
		{
			_tooltipCaller.isShowTooltip = true;
			_tooltipCaller.isTutorial = true;
			_tooltipCaller.type = TooltipType.tutorial_haishin;
		}
		else
		{
			_tooltipCaller.isShowTooltip = false;
		}
		ChoosedAlphaType = AlphaType.none;
		this.level = 0;
		AlphaButton.gameObject.SetActive(false);
		status = ChoosingStatus.alpha;
		((Component)ChipChoosingParent).gameObject.SetActive(true);
		KaimakuParent.SetActive(false);
		CleanChilds();
		int num = Enum.GetNames(typeof(AlphaType)).Length - 1;
		for (int i = page * MAXCHIPSHOWING; i < (page + 1) * MAXCHIPSHOWING; i++)
		{
			if (i <= num)
			{
				GameObject val = Object.Instantiate<GameObject>(AlphaPrefab, ChipChoosingParent);
				int level = SingletonMonoBehaviour<NetaManager>.Instance.GetAlphaChipLevel((AlphaType)Enum.ToObject(typeof(AlphaType), i));
				bool isUsed = SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel a) => a.alphaType == (AlphaType)Enum.ToObject(typeof(AlphaType), i) && a.level == level);
				val.GetComponent<NetaChipAlpha>().SetData(i, level, isUsed);
				_selectableObjects.Add(val);
			}
		}
		List<GameObject> list = new List<GameObject>(_selectableObjects.Count);
		int num2 = 2;
		int num3 = Mathf.CeilToInt((float)(_selectableObjects.Count / num2));
		for (int num4 = 0; num4 < num3; num4++)
		{
			for (int num5 = 0; num5 < num2; num5++)
			{
				int num6 = num3 * num5 + num4;
				if (num6 >= _selectableObjects.Count)
				{
					break;
				}
				list.Add(_selectableObjects[num6]);
			}
		}
		_selectableObjects = list;
	}

	private void ShowKaimaku()
	{
		status = ChoosingStatus.go;
		((Component)ChipChoosingParent).gameObject.SetActive(false);
		KaimakuParent.SetActive(true);
		_selectableObjects.Clear();
		_selectableObjects.Add(((Component)backButton).gameObject);
		_selectableObjects.Add(((Component)StartButton).gameObject);
		string text = NgoEx.SystemTextFromType(SystemTextType.haisin_start_button, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		StartButtonText.text = text;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(StartButton), (Action<Unit>)delegate
		{
			StartHaisin(ChoosedAlphaType, level, ChoosedBetaType);
		}), (Component)(object)StartButton);
	}

	private void ShowPager(int page)
	{
		int num = 0;
		if (status == ChoosingStatus.go)
		{
			return;
		}
		if (status == ChoosingStatus.alpha)
		{
			num = alphaMaxPage;
		}
		if (status == ChoosingStatus.beta)
		{
			num = betaMaxPage;
		}
		nowPage = page;
		CleanPaging();
		for (int i = 0; i < num; i++)
		{
			if (i == page)
			{
				Object.Instantiate<GameObject>(PageNowPrefab, PagingParent);
				continue;
			}
			GameObject val = Object.Instantiate<GameObject>(PagePrefab, PagingParent);
			int index = i;
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(val.GetComponent<Button>()), (Action<Unit>)delegate
			{
				PageTo(index);
			}), val);
		}
	}

	private void CleanPaging()
	{
		for (int num = PagingParent.childCount - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)((Component)PagingParent.GetChild(num)).gameObject);
		}
	}

	private void PageTo(int page)
	{
		if (status == ChoosingStatus.alpha)
		{
			ShowAlphaChip(page);
		}
	}

	public void Choosed(AlphaType alpha, int level)
	{
		ChoosedAlphaType = alpha;
		this.level = level;
		AlphaButton.gameObject.SetActive(true);
		AlphaButton.gameObject.GetComponent<NetaChipAlpha>().ShowType(alpha, level, isDiscovered: true);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(backButton), (Action<Unit>)delegate
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
			{
				ShowAlphaLevelChip();
			}
			else
			{
				ShowAlphaChip((int)alpha / MAXCHIPSHOWING);
			}
		}), AlphaButton);
		ChooseNext();
	}

	private void ChooseNext()
	{
		if (ChoosedAlphaType == AlphaType.none)
		{
			ShowAlphaChip(0);
		}
		else
		{
			ShowKaimaku();
		}
	}

	private void StartHaisin(AlphaType alpha, int level, BetaType beta)
	{
		SingletonMonoBehaviour<EventManager>.Instance.StartHaishin(alpha, level, beta);
	}
}
