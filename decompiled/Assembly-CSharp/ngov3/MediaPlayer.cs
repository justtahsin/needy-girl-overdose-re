using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MediaPlayer : Window
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnTitleScrollAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public MediaPlayer _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MediaPlayer mediaPlayer = _003C_003E4__this;
			try
			{
				try
				{
					Awaiter val2;
					if (num != 0)
					{
						YieldAwaitable val = UniTask.Yield();
						val2 = ((YieldAwaitable)(ref val)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnTitleScrollAsync_003Ed__16>(ref val2, ref this);
							return;
						}
					}
					else
					{
						val2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
					}
					((Awaiter)(ref val2)).GetResult();
					TweenExtensions.Kill((Tween)(object)mediaPlayer._titleScroll, false);
					mediaPlayer._musicTitle.rectTransform.anchoredPosition = mediaPlayer._titleOriginalPosition;
					if (!(mediaPlayer._musicTitle.rectTransform.sizeDelta.x <= mediaPlayer._titleMask.sizeDelta.x))
					{
						_ = mediaPlayer._musicTitle.rectTransform.sizeDelta;
						_ = mediaPlayer._titleMask.sizeDelta;
						float x = mediaPlayer._musicTitle.rectTransform.offsetMax.x;
						float num2 = Mathf.Min(600f, 0f - mediaPlayer._musicTitle.rectTransform.sizeDelta.x - 400f);
						float num3 = 80f / (float)mediaPlayer._musicTitle.text.Length;
						mediaPlayer._titleScroll = DOTween.Sequence();
						TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetLoops<Sequence>(TweenSettingsExtensions.SetRelative<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(mediaPlayer._titleScroll, (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)mediaPlayer._musicTitle.rectTransform, num2, num3, false), (Ease)1)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.From<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)mediaPlayer._musicTitle.rectTransform, x, 0f, false)), (Ease)1))), -1));
					}
				}
				catch (MissingReferenceException)
				{
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		_playList = _musicTitleMaster.MusicTitleList;
		_titleOriginalPosition = _musicTitle.rectTransform.anchoredPosition;
		_titleScroll = DOTween.Sequence();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<AudioManager.TargetAudio>(Observable.Where<AudioManager.TargetAudio>((IObservable<AudioManager.TargetAudio>)_manager.PlayingBgm, (Func<AudioManager.TargetAudio, bool>)((AudioManager.TargetAudio x) => x != null)), (Action<AudioManager.TargetAudio>)delegate(AudioManager.TargetAudio bgm)
		{
			MusicTitle musicTitle = _playList.FirstOrDefault((MusicTitle p) => p.Id == bgm.Sound.Id);
			if (musicTitle != null)
			{
				_listIndex = _playList.IndexOf(musicTitle);
			}
			OnMarquee(bgm.Sound.Music.Id);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_playButton), (Action<Unit>)delegate
		{
			isChippy = !isChippy;
		}), ((Component)this).gameObject);
		IObservable<float> observable = Observable.Share<float>(UnityUIComponentExtensions.OnValueChangedAsObservable(_volumeSlider));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(observable, (Action<float>)delegate
		{
			((Component)this).transform.SetAsLastSibling();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.ThrottleFrame<float>(observable, 5, (FrameCountType)0), (Action<float>)delegate(float v)
		{
			_manager.ChangeVolume(SoundCategory.BGM, v);
		}), ((Component)this).gameObject);
	}

	private void PlayMainloop()
	{
		_manager.PlayBgmByType(_currentMainloop, isLoop: true);
		_listIndex++;
	}

	[AsyncStateMachine(typeof(_003COnTitleScrollAsync_003Ed__16))]
	private UniTask OnTitleScrollAsync()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnTitleScrollAsync_003Ed__16 _003COnTitleScrollAsync_003Ed__17 = default(_003COnTitleScrollAsync_003Ed__16);
		_003COnTitleScrollAsync_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnTitleScrollAsync_003Ed__17._003C_003E4__this = this;
		_003COnTitleScrollAsync_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnTitleScrollAsync_003Ed__17._003C_003Et__builder)).Start<_003COnTitleScrollAsync_003Ed__16>(ref _003COnTitleScrollAsync_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnTitleScrollAsync_003Ed__17._003C_003Et__builder)).Task;
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
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		_musicTitle.text = "♪" + _musicTitleMaster.MusicTitleList.FirstOrDefault((MusicTitle t) => t.Id == id).BodyJp;
		UniTaskExtensions.Forget(OnTitleScrollAsync());
	}
}
