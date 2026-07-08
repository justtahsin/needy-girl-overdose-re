using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MediaPlayer : Window
{
	[SerializeField]
	private MusicTitleMaster _musicTitleMaster;

	[SerializeField]
	private RectTransform _titleMask;

	[SerializeField]
	private TMP_Text _musicTitle;

	[SerializeField]
	private Slider _volumeSlider;

	[SerializeField]
	private Button _playButton;

	private AudioManager _manager;

	public bool isChippy;

	private List<MusicTitle> _playList = new List<MusicTitle>();

	private int _listIndex = -1;

	private Vector2 _titleOriginalPosition;

	[SerializeField]
	private float rightX = 1000f;

	private Sequence _titleScroll;

	private SoundType _currentMainloop = SoundType.BGM_mainloop_normal;

	private void Start()
	{
		_manager = AudioManager.Instance;
		_volumeSlider.value = SingletonMonoBehaviour<Settings>.Instance.BgmVolume;
	}

	private void OnShowMediaPlayer()
	{
		_playList = _musicTitleMaster.MusicTitleList;
		_titleOriginalPosition = _musicTitle.rectTransform.anchoredPosition;
		_titleScroll = DOTween.Sequence();
		_manager.PlayingBgm.Where((AudioManager.TargetAudio x) => x != null).Subscribe(delegate(AudioManager.TargetAudio bgm)
		{
			MusicTitle musicTitle = _playList.FirstOrDefault((MusicTitle p) => p.Id == bgm.Sound.Id);
			if (musicTitle != null)
			{
				_listIndex = _playList.IndexOf(musicTitle);
			}
			OnMarquee(bgm.Sound.Music.Id);
		}).AddTo(base.gameObject);
		_playButton.OnClickAsObservable().Subscribe(delegate
		{
			isChippy = !isChippy;
		}).AddTo(base.gameObject);
		IObservable<float> source = _volumeSlider.OnValueChangedAsObservable().Share();
		source.Subscribe(delegate
		{
			base.transform.SetAsLastSibling();
		}).AddTo(base.gameObject);
		source.ThrottleFrame(5).Subscribe(delegate(float v)
		{
			_manager.ChangeVolume(SoundCategory.BGM, v);
		}).AddTo(base.gameObject);
	}

	private void PlayMainloop()
	{
		_manager.PlayBgmByType(_currentMainloop, isLoop: true);
		_listIndex++;
	}

	private async UniTask OnTitleScrollAsync()
	{
		try
		{
			await UniTask.Yield();
			_titleScroll.Kill();
			_musicTitle.rectTransform.anchoredPosition = _titleOriginalPosition;
			if (!(_musicTitle.rectTransform.sizeDelta.x <= _titleMask.sizeDelta.x))
			{
				_ = _musicTitle.rectTransform.sizeDelta;
				_ = _titleMask.sizeDelta;
				float x = _musicTitle.rectTransform.offsetMax.x;
				float endValue = Mathf.Min(600f, 0f - _musicTitle.rectTransform.sizeDelta.x - 400f);
				float duration = 80f / (float)_musicTitle.text.Length;
				_titleScroll = DOTween.Sequence();
				_titleScroll.Append(_musicTitle.rectTransform.DOLocalMoveX(endValue, duration).SetEase(Ease.Linear)).Append(_musicTitle.rectTransform.DOLocalMoveX(x, 0f).From().SetEase(Ease.Linear)).SetRelative()
					.SetLoops(-1)
					.Play();
			}
		}
		catch (MissingReferenceException)
		{
		}
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		if (_manager.PlayingBgm.Value != null)
		{
			OnMarquee(_manager.PlayingBgm.Value.Sound.Music.Id);
		}
	}

	private void OnMarquee(string id)
	{
		_musicTitle.text = "♪" + _musicTitleMaster.MusicTitleList.FirstOrDefault((MusicTitle t) => t.Id == id).BodyJp;
		OnTitleScrollAsync().Forget();
	}
}
