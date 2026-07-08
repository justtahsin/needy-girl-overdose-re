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
		_tooltipCaller = GetComponent<TooltipCaller>();
		AlphaButton.gameObject.SetActive(value: false);
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
		backButton.gameObject.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Reselect, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void CleanChilds()
	{
		_selectableObjects.Clear();
		for (int num = ChipChoosingParent.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(ChipChoosingParent.GetChild(num).gameObject);
		}
	}

	private void ShowAlphaLevelChip()
	{
		ChoosedAlphaType = AlphaType.none;
		level = 0;
		AlphaButton.gameObject.SetActive(value: false);
		status = ChoosingStatus.alpha;
		ChipChoosingParent.gameObject.SetActive(value: true);
		KaimakuParent.SetActive(value: false);
		CleanChilds();
		int num = Enum.GetNames(typeof(AlphaType)).Length - 1;
		for (int i = 0; i < MAXCHIPSHOWING; i++)
		{
			if (i <= num)
			{
				GameObject obj = UnityEngine.Object.Instantiate(AlphaPrefab, ChipChoosingParent);
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
		AlphaButton.gameObject.SetActive(value: false);
		status = ChoosingStatus.alpha;
		ChipChoosingParent.gameObject.SetActive(value: true);
		KaimakuParent.SetActive(value: false);
		CleanChilds();
		int num = Enum.GetNames(typeof(AlphaType)).Length - 1;
		for (int i = page * MAXCHIPSHOWING; i < (page + 1) * MAXCHIPSHOWING; i++)
		{
			if (i <= num)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(AlphaPrefab, ChipChoosingParent);
				int level = SingletonMonoBehaviour<NetaManager>.Instance.GetAlphaChipLevel((AlphaType)Enum.ToObject(typeof(AlphaType), i));
				bool isUsed = SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel a) => a.alphaType == (AlphaType)Enum.ToObject(typeof(AlphaType), i) && a.level == level);
				gameObject.GetComponent<NetaChipAlpha>().SetData(i, level, isUsed);
				_selectableObjects.Add(gameObject);
			}
		}
		List<GameObject> list = new List<GameObject>(_selectableObjects.Count);
		int num2 = 2;
		int num3 = Mathf.CeilToInt(_selectableObjects.Count / num2);
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
		ChipChoosingParent.gameObject.SetActive(value: false);
		KaimakuParent.SetActive(value: true);
		_selectableObjects.Clear();
		_selectableObjects.Add(backButton.gameObject);
		_selectableObjects.Add(StartButton.gameObject);
		string text = NgoEx.SystemTextFromType(SystemTextType.haisin_start_button, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		StartButtonText.text = text;
		StartButton.OnClickAsObservable().Subscribe(delegate
		{
			StartHaisin(ChoosedAlphaType, level, ChoosedBetaType);
		}).AddTo(StartButton);
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
				UnityEngine.Object.Instantiate(PageNowPrefab, PagingParent);
				continue;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(PagePrefab, PagingParent);
			int index = i;
			gameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
			{
				PageTo(index);
			})
				.AddTo(gameObject);
		}
	}

	private void CleanPaging()
	{
		for (int num = PagingParent.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(PagingParent.GetChild(num).gameObject);
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
		AlphaButton.gameObject.SetActive(value: true);
		AlphaButton.gameObject.GetComponent<NetaChipAlpha>().ShowType(alpha, level, isDiscovered: true);
		backButton.OnClickAsObservable().Subscribe(delegate
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
			{
				ShowAlphaLevelChip();
			}
			else
			{
				ShowAlphaChip((int)alpha / MAXCHIPSHOWING);
			}
		}).AddTo(AlphaButton);
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
