using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class EgosaView2D : MonoBehaviour, IStorable
{
	[SerializeField]
	private GameObject musimegane;

	[SerializeField]
	private EgosaRepView2D kusoPrefab;

	[SerializeField]
	private Transform kusoParent;

	[SerializeField]
	private TMP_Text searchText;

	[SerializeField]
	private VerticalGridLayout2D verticalGridLayout2D;

	private CancellationTokenSource _egosaCancelSource;

	private void Start()
	{
	}

	public void OnPicked()
	{
		_egosaCancelSource = new CancellationTokenSource();
		if (_egosaCancelSource != null)
		{
			EgosaAnimation();
		}
	}

	public void OnStored()
	{
		if (_egosaCancelSource == null)
		{
			return;
		}
		_egosaCancelSource.Cancel();
		_egosaCancelSource.Dispose();
		foreach (Transform item in kusoParent.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	private async UniTask EgosaAnimation()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_yokan);
		musimegane.SetActive(value: true);
		RectTransform musirect = musimegane.GetComponent<RectTransform>();
		searchText.text = NgoEx.SystemTextFromType(SystemTextType.Search_egosa, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		musirect.localPosition = new Vector3(4f, -4f, 0f);
		await UniTask.Delay(120, ignoreTimeScale: false, PlayerLoopTiming.Update, _egosaCancelSource.Token);
		musirect.localPosition = new Vector3(-4f, 4f, 0f);
		await UniTask.Delay(120, ignoreTimeScale: false, PlayerLoopTiming.Update, _egosaCancelSource.Token);
		musirect.localPosition = new Vector3(4f, 4f, 0f);
		await UniTask.Delay(120, ignoreTimeScale: false, PlayerLoopTiming.Update, _egosaCancelSource.Token);
		musirect.localPosition = new Vector3(-4f, -4f, 0f);
		await UniTask.Delay(120, ignoreTimeScale: false, PlayerLoopTiming.Update, _egosaCancelSource.Token);
		musirect.localPosition = new Vector3(0f, 0f, 0f);
		await UniTask.Delay(120, ignoreTimeScale: false, PlayerLoopTiming.Update, _egosaCancelSource.Token);
		musimegane.SetActive(value: false);
		if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
		{
			ShowAllEgosas();
		}
		if (!SingletonMonoBehaviour<EventManager>.Instance.isHorror)
		{
			UpdateContents();
		}
		else
		{
			UpdateHorror(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) - 24);
		}
		AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_kusorep);
	}

	private void ShowAllEgosas()
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		for (int i = 0; i < NgoEx.getEgosas().ToList().Count - 1; i++)
		{
			EgosaRepView2D egosaRepView2D = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			egosaRepView2D.gameObject.transform.SetAsLastSibling();
			egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i)));
			egosaRepView2D.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
		}
	}

	private int ContentCount(int follower)
	{
		return Mathf.Max((int)Mathf.Log10(follower) - 4, 1);
	}

	private void UpdateContents()
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		string text = SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.FindLast((string st) => st.Contains("_"));
		if (text != null)
		{
			EgosaRepView2D egosaRepView2D = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			egosaRepView2D.gameObject.transform.SetAsLastSibling();
			egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
			egosaRepView2D.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		EgosaRepView2D egosaRepView2D2 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
		egosaRepView2D2.gameObject.transform.SetAsLastSibling();
		egosaRepView2D2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "follower", getFollowerRank(status))));
		egosaRepView2D2.Show();
		verticalGridLayout2D.AddLayoutObject(egosaRepView2D2);
		for (int num = 0; num < ContentCount(status); num++)
		{
			EgosaRepView2D egosaRepView2D3 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			egosaRepView2D3.gameObject.transform.SetAsLastSibling();
			egosaRepView2D3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value)));
			egosaRepView2D3.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D3);
		}
		AlphaLevel alphaLevel = ((SingletonMonoBehaviour<EventManager>.Instance.nextActionHint.FirstOrDefault((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == ActionType.InternetPoketterEgosa) == null) ? null : SingletonMonoBehaviour<EventManager>.Instance.nextActionHint.FirstOrDefault((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == ActionType.InternetPoketterEgosa).Item2);
		if (alphaLevel != null && alphaLevel.alphaType == AlphaType.PR && alphaLevel.level == 5)
		{
			EgosaRepView2D egosaRepView2D4 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			egosaRepView2D4.gameObject.transform.SetAsLastSibling();
			egosaRepView2D4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "NetaGet_PR5", "NetaGet_PR5")));
			egosaRepView2D4.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D4);
		}
	}

	private void UpdateHorror(int horrorDay)
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		int num = 2;
		if (horrorDay == 2 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0)
		{
			num = 10;
			for (int i = 0; i < num; i++)
			{
				EgosaRepView2D egosaRepView2D = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				egosaRepView2D.gameObject.transform.SetAsLastSibling();
				egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i, "horror", "horrorday2Before")));
				egosaRepView2D.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
			}
		}
		if (horrorDay == 2 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) != 0)
		{
			num = 8;
			for (int j = 0; j < num; j++)
			{
				EgosaRepView2D egosaRepView2D2 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				egosaRepView2D2.gameObject.transform.SetAsLastSibling();
				egosaRepView2D2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, j, "horror", "horrorday2Afterr")));
				egosaRepView2D2.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D2);
			}
		}
		if (horrorDay == 1)
		{
			string text = SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.FindLast((string st) => st.Contains("_"));
			if (text != null)
			{
				EgosaRepView2D egosaRepView2D3 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				egosaRepView2D3.gameObject.transform.SetAsLastSibling();
				egosaRepView2D3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
				egosaRepView2D3.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D3);
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				EgosaRepView2D egosaRepView2D4 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				egosaRepView2D4.gameObject.transform.SetAsLastSibling();
				egosaRepView2D4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, num2, "horror", "horrorday1")));
				egosaRepView2D4.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D4);
			}
		}
	}

	private string getFollowerRank(int follower)
	{
		if (follower < 10000)
		{
			return "small";
		}
		if (follower < 100000)
		{
			return "middle";
		}
		return "large";
	}
}
