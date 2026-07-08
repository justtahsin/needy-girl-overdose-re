using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Login : MonoBehaviour
{
	[SerializeField]
	private Button _login;

	[SerializeField]
	private GameObject _badge;

	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	private TMP_Text _passText;

	[SerializeField]
	private TMP_Text _placeholderText;

	public GameObject LoginButtonObj => _login.gameObject;

	private void Awake()
	{
		_passText.gameObject.SetActive(value: false);
		_placeholderText.gameObject.SetActive(value: false);
		SteamInput();
	}

	private async UniTask ConsoleInput()
	{
		_input.gameObject.SetActive(value: false);
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		CancellationToken token = this.GetCancellationTokenOnDestroy();
		_badge.SetActive(value: false);
		_login.interactable = false;
		_passText.maxVisibleCharacters = 0;
		await UniTask.Delay(Constants.FAST, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		if (this == null)
		{
			return;
		}
		_placeholderText.gameObject.SetActive(value: false);
		await _passText.DOMaxVisibleCharacters(12, 3f).Play().WithCancellation(token);
		if (!(this == null))
		{
			_login.OnClickAsObservable().Subscribe(delegate
			{
				SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_loop1_day0_night_AfterLogin>();
			}).AddTo(base.gameObject);
			_badge.SetActive(value: true);
			_login.interactable = true;
		}
	}

	private void SteamInput()
	{
		_input.ObserveEveryValueChanged((TMP_InputField _input) => _input.text).Subscribe(delegate(string text)
		{
			couldLogin(text);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		_badge.SetActive(value: false);
		_login.interactable = false;
		_login.OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_loop1_day0_night_AfterLogin>();
		}).AddTo(base.gameObject);
	}

	private void couldLogin(string text)
	{
		if (text == "angelkawaii2" || text == "angelikawaii2")
		{
			_badge.SetActive(value: true);
			_login.interactable = true;
		}
		else
		{
			_badge.SetActive(value: false);
			_login.interactable = false;
		}
	}
}
