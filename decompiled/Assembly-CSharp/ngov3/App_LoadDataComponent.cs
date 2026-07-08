using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class App_LoadDataComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _Hyouji;

	[SerializeField]
	private int _DataNumber;

	[SerializeField]
	private Transform _DataContainer;

	[SerializeField]
	private DataPrefab _DataPrefab;

	[SerializeField]
	private Button _NewGame;

	public void Awake()
	{
		_Hyouji.text = $"Data{_DataNumber}";
		for (int num = 30; num >= 1; num--)
		{
			if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day{num}{SaveRelayer.EXTENTION}"))
			{
				Object.Instantiate(_DataPrefab, _DataContainer).SetLoadable(_DataNumber, num);
			}
		}
		if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day1{SaveRelayer.EXTENTION}"))
		{
			_NewGame.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			_NewGame.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		_NewGame.OnClickAsObservable().Subscribe(delegate
		{
			StartGame();
		}).AddTo(base.gameObject);
	}

	private async UniTask StartGame()
	{
		AudioManager.Instance.StopBgm();
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "";
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		AudioManager.Instance.PlaySeByType(SoundType.SE_command_execute);
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = _DataNumber;
		await Resources.UnloadUnusedAssets().ToUniTask();
		SceneManager.LoadScene("WindowUITestScene");
	}
}
