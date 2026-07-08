using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class DataPrefab : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _label;

	[SerializeField]
	private Button _button;

	[SerializeField]
	private string _datapath;

	private int DataNum;

	public void SetLoadable(int DataNum, int day)
	{
		this.DataNum = DataNum;
		_datapath = $"Data{DataNum}_Day{day}";
		_label.text = _datapath;
		_button = ((Component)this).GetComponent<Button>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_button), (Action<Unit>)delegate
		{
			Resume();
		}), ((Component)this).gameObject);
	}

	private void Resume()
	{
		AudioManager.Instance?.StopBgm();
		AudioManager.Instance?.PlaySeByType(SoundType.SE_command_execute);
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = DataNum;
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = true;
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = _datapath + SaveRelayer.EXTENTION;
		SceneManager.LoadScene("WindowUITestScene");
	}
}
