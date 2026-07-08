using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class EndingManager : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _summary;

	[SerializeField]
	private GameObject _endingAchievement;

	[SerializeField]
	private GameObject _achievedBlock;

	[SerializeField]
	private GameObject _unachievedBlock;

	[SerializeField]
	private GameObject _achievingBlock;

	[SerializeField]
	private Window _windowPoketter;

	private EndingType end;

	private AsyncOperation asyncLoad;

	private CancellationToken token;

	private void Awake()
	{
		token = this.GetCancellationTokenOnDestroy();
		token.ThrowIfCancellationRequested();
		PostEffectManager.Instance.ResetShader();
		end = SingletonMonoBehaviour<EventManager>.Instance.nowEnding;
		Transform parent = _endingAchievement.transform;
		List<EndingType> mitaEnd = SingletonMonoBehaviour<Settings>.Instance.mitaEnd;
		string[] names = Enum.GetNames(typeof(EndingType));
		foreach (string id in names)
		{
			if (!(id == "Ending_None") && !(id == "Ending_Completed") && !(id == "Ending_NetShut"))
			{
				if (id == end.ToString())
				{
					UnityEngine.Object.Instantiate(_achievingBlock, parent);
				}
				else if (mitaEnd.Exists((EndingType gotend) => gotend.ToString() == id))
				{
					UnityEngine.Object.Instantiate(_achievedBlock, parent);
				}
				else
				{
					UnityEngine.Object.Instantiate(_unachievedBlock, parent);
				}
			}
		}
		_summary.text = GetEndingName(end, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		NgoEx.ChangeCursor(isLoading: false);
		AudioManager.Instance.StopAll();
		AudioManager.Instance.PlaySeByType(SoundType.SE_bluescreen);
		GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
		{
			OnAnykeyAsync(end, token).Forget();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Add(end);
		SingletonMonoBehaviour<Settings>.Instance.Save();
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Jisatu)
		{
			string sceneName = (SingletonMonoBehaviour<Settings>.Instance.checkAllZipUnlocked() ? "BiosToLoad" : "ChooseZip");
			asyncLoad = SceneManager.LoadSceneAsync(sceneName);
			asyncLoad.allowSceneActivation = false;
		}
	}

	private async UniTask OnAnykeyAsync(EndingType end, CancellationToken token = default(CancellationToken))
	{
		AudioManager.Instance.StopAll();
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Jisatu)
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Event_Rentan_Comeback>();
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_None;
		Resources.UnloadUnusedAssets();
		await UniTask.Delay(1400);
		asyncLoad.allowSceneActivation = true;
	}

	private string GetEndingName(EndingType end, LanguageType lang)
	{
		EndingMaster.Param param = NgoEx.EndingFromType(end);
		return lang switch
		{
			LanguageType.JP => param.EndingNameJp, 
			LanguageType.CN => param.EndingNameCn, 
			LanguageType.KO => param.EndingNameKo, 
			LanguageType.TW => param.EndingNameTw, 
			LanguageType.VN => param.EndingNameVn, 
			LanguageType.FR => param.EndingNameFr, 
			LanguageType.IT => param.EndingNameIt, 
			LanguageType.GE => param.EndingNameGe, 
			LanguageType.SP => param.EndingNameSp, 
			LanguageType.RU => param.EndingNameRu, 
			_ => param.EndingNameEn, 
		};
	}
}
