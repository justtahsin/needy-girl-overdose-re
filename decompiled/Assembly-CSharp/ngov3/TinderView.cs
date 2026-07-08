using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TinderView : MonoBehaviour
{
	[SerializeField]
	private Image _Otoko1;

	[SerializeField]
	private Image _Otoko2;

	[SerializeField]
	private List<Sprite> _otoko = new List<Sprite>();

	[SerializeField]
	private GameObject _buttonRoot;

	[SerializeField]
	private Button _nope;

	[SerializeField]
	private Button _like;

	[SerializeField]
	private int otokoindex;

	private bool isOmote = true;

	public void OnLanguageUpdated(LanguageType lang)
	{
		_nope.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dinder_Nope, lang);
		_like.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dinder_Like, lang);
	}

	public void Awake()
	{
	}

	protected void Start()
	{
		_nope.OnClickAsObservable().Subscribe(delegate
		{
			ChangeOtoko();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType lang)
		{
			OnLanguageUpdated(lang);
		}).AddTo(base.gameObject);
		_otoko = shuffleOtoko(_otoko);
		_Otoko1.sprite = _otoko[0];
		_Otoko2.sprite = _otoko[1];
	}

	private List<Sprite> shuffleOtoko(List<Sprite> aList)
	{
		System.Random random = new System.Random();
		int count = _otoko.Count;
		for (int i = 0; i < count; i++)
		{
			int index = i + (int)(random.NextDouble() * (double)(count - i));
			Sprite value = aList[index];
			aList[index] = aList[i];
			aList[i] = value;
		}
		return aList;
	}

	private async void ChangeOtoko()
	{
		await UniTask.Delay(10);
		_nope.interactable = false;
		AudioManager.Instance.PlaySeByType(SoundType.SE_kuraiSelect);
		if (otokoindex + 3 > _otoko.Count)
		{
			otokoindex = 0;
			_otoko = shuffleOtoko(_otoko);
		}
		if (isOmote)
		{
			await _Otoko1.rectTransform.DOLocalMoveX(-1920f, 0.8f).Play();
			_Otoko1.transform.SetAsFirstSibling();
			await _Otoko1.rectTransform.DOLocalMoveX(0f, 0.1f).Play();
			_Otoko1.sprite = _otoko[otokoindex + 2];
		}
		else
		{
			await _Otoko2.rectTransform.DOLocalMoveX(-1920f, 0.8f).Play();
			_Otoko2.transform.SetAsFirstSibling();
			await _Otoko2.rectTransform.DOLocalMoveX(0f, 0.1f).Play();
			_Otoko2.sprite = _otoko[otokoindex + 2];
		}
		isOmote = !isOmote;
		otokoindex++;
		_nope.interactable = true;
	}

	public async UniTask OnChoosed()
	{
		_buttonRoot.SetActive(value: false);
		_Otoko1.rectTransform.DOLocalMoveY(1080f, 0.5f).Play();
		_Otoko2.rectTransform.DOLocalMoveY(1080f, 0.5f).Play();
	}
}
