using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class EgosaView : MonoBehaviour
{
	[SerializeField]
	private GameObject musimegane;

	[SerializeField]
	private KusoRepView kusoPrefab;

	[SerializeField]
	private Transform kusoParent;

	[SerializeField]
	private TMP_Text searchText;

	[SerializeField]
	private VerticalGridLayout2D verticalGridLayout2D;

	private async void Start()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_yokan);
		RectTransform musirect = musimegane.GetComponent<RectTransform>();
		searchText.text = NgoEx.SystemTextFromType(SystemTextType.Search_egosa, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		musirect.localPosition = new Vector3(4f, -4f, 0f);
		await UniTask.Delay(120);
		musirect.localPosition = new Vector3(-4f, 4f, 0f);
		await UniTask.Delay(120);
		musirect.localPosition = new Vector3(4f, 4f, 0f);
		await UniTask.Delay(120);
		musirect.localPosition = new Vector3(-4f, -4f, 0f);
		await UniTask.Delay(120);
		musirect.localPosition = new Vector3(0f, 0f, 0f);
		await UniTask.Delay(120);
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
	}

	private void ShowAllEgosas()
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		for (int i = 0; i < NgoEx.getEgosas().ToList().Count - 1; i++)
		{
			KusoRepView kusoRepView = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			kusoRepView.gameObject.transform.SetAsLastSibling();
			kusoRepView.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i)));
			kusoRepView.Show();
			verticalGridLayout2D.AddLayoutObject(kusoRepView);
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
			KusoRepView kusoRepView = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			kusoRepView.gameObject.transform.SetAsLastSibling();
			kusoRepView.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
			kusoRepView.Show();
			verticalGridLayout2D.AddLayoutObject(kusoRepView);
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		KusoRepView kusoRepView2 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
		kusoRepView2.gameObject.transform.SetAsLastSibling();
		kusoRepView2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "follower", getFollowerRank(status))));
		kusoRepView2.Show();
		verticalGridLayout2D.AddLayoutObject(kusoRepView2);
		for (int num = 0; num < ContentCount(status); num++)
		{
			KusoRepView kusoRepView3 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			kusoRepView3.gameObject.transform.SetAsLastSibling();
			kusoRepView3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value)));
			kusoRepView3.Show();
			verticalGridLayout2D.AddLayoutObject(kusoRepView3);
		}
		AlphaLevel item = SingletonMonoBehaviour<EventManager>.Instance.nextActionHint.FirstOrDefault((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == ActionType.InternetPoketterEgosa).Item2;
		if (item.alphaType == AlphaType.PR && item.level == 5)
		{
			KusoRepView kusoRepView4 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
			kusoRepView4.gameObject.transform.SetAsLastSibling();
			kusoRepView4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "NetaGet_PR5", "NetaGet_PR5")));
			kusoRepView4.Show();
			verticalGridLayout2D.AddLayoutObject(kusoRepView4);
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
				KusoRepView kusoRepView = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				kusoRepView.gameObject.transform.SetAsLastSibling();
				kusoRepView.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i, "horror", "horrorday2Before")));
				kusoRepView.Show();
			}
		}
		if (horrorDay == 2 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) != 0)
		{
			num = 8;
			for (int j = 0; j < num; j++)
			{
				KusoRepView kusoRepView2 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				kusoRepView2.gameObject.transform.SetAsLastSibling();
				kusoRepView2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, j, "horror", "horrorday2Afterr")));
				kusoRepView2.Show();
			}
		}
		if (horrorDay == 1)
		{
			string text = SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.FindLast((string st) => st.Contains("_"));
			if (text != null)
			{
				KusoRepView kusoRepView3 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				kusoRepView3.gameObject.transform.SetAsLastSibling();
				kusoRepView3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
				kusoRepView3.Show();
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				KusoRepView kusoRepView4 = UnityEngine.Object.Instantiate(kusoPrefab, kusoParent);
				kusoRepView4.gameObject.transform.SetAsLastSibling();
				kusoRepView4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, num2, "horror", "horrorday1")));
				kusoRepView4.Show();
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
