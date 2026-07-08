using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Audio;

namespace ngov3;

public class AudioManager : MonoBehaviour
{
	public class TargetAudio
	{
		public Sound Sound;

		public AudioSource Source;

		public float PlayTime;
	}

	private static AudioManager _instance;

	[SerializeField]
	private List<AudioSource> _audioSources = new List<AudioSource>();

	[SerializeField]
	private SoundMaster _soundMaster;

	[SerializeField]
	private AudioMixer _audioMixer;

	private bool _isReady;

	private ReactiveCollection<TargetAudio> _playingSeList = new ReactiveCollection<TargetAudio>();

	private ReactiveProperty<TargetAudio> _playingBgm = new ReactiveProperty<TargetAudio>();

	private CancellationToken _onDestroyToken;

	public TargetAudio baseMusic;

	public TargetAudio OneShotMusic;

	public static AudioManager Instance
	{
		get
		{
			if (!(_instance == null))
			{
				return _instance;
			}
			return UnityEngine.Object.FindObjectOfType<AudioManager>();
		}
	}

	public IReadOnlyReactiveCollection<TargetAudio> PlayingSeList => _playingSeList;

	public IReadOnlyReactiveProperty<TargetAudio> PlayingBgm => _playingBgm;

	private void Awake()
	{
		_onDestroyToken = this.GetCancellationTokenOnDestroy();
		if (UnityEngine.Object.FindObjectsOfType<AudioManager>().Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private async void Start()
	{
		Initialize();
		await SingletonMonoBehaviour<Settings>.Instance.OnLoadObservable;
		ChangeVolume(SoundCategory.BGM, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
		ChangeVolume(SoundCategory.BANK, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
		ChangeSeVolume(SingletonMonoBehaviour<Settings>.Instance.SeVolume);
		Debug.Log("AudioSetCompleat");
	}

	private void Initialize()
	{
		if (_isReady)
		{
			return;
		}
		_audioSources = GetComponents<AudioSource>()?.ToList();
		_isReady = true;
		_playingBgm.Buffer(2, 1).Subscribe(delegate(IList<TargetAudio> audios)
		{
			TargetAudio targetAudio = audios[0];
			TargetAudio targetAudio2 = audios[1];
			if (!(targetAudio?.Sound.Id == targetAudio2?.Sound.Id) || !targetAudio.Source.isPlaying)
			{
				if (targetAudio != null)
				{
					Stop(targetAudio);
				}
				if (targetAudio2 != null)
				{
					Play(targetAudio2);
				}
			}
		}).AddTo(base.gameObject);
		(from x in _playingSeList.ObserveAdd()
			where x.Value.Source != null
			select x).Subscribe(async delegate(CollectionAddEvent<TargetAudio> audio)
		{
			Play(audio.Value);
			await UniTask.NextFrame(PlayerLoopTiming.LastUpdate, _onDestroyToken);
			await UniTask.WaitUntil(() => !audio.Value.Source.isPlaying).AttachExternalCancellation(_onDestroyToken);
			_onDestroyToken.ThrowIfCancellationRequested();
			_playingSeList.Remove(audio.Value);
		}).AddTo(base.gameObject);
	}

	public void AddAudioSource(AudioSource source)
	{
		_audioSources.Add(source);
	}

	public void RemoveAudioSource(AudioSource source)
	{
		_audioSources.Add(source);
	}

	public AudioSource GetAudioSource(string category)
	{
		Initialize();
		return _audioSources.First((AudioSource x) => x.outputAudioMixerGroup.name == category);
	}

	public void Play(TargetAudio target)
	{
		switch (FetchCategory(target))
		{
		case SoundCategory.BGM:
		case SoundCategory.BANK:
			target.Source.clip = target.Sound.Clip;
			target.Source.Play();
			break;
		case SoundCategory.SE:
		case SoundCategory.CLICK:
			target.Source.PlayOneShot(target.Sound.Clip);
			break;
		}
	}

	private async UniTask PlayBgmOneShotAsync(TargetAudio target)
	{
		baseMusic = _playingBgm.Value;
		_ = target.Source.loop;
		_playingBgm.Value = target;
		await UniTask.WaitUntil(() => _playingBgm.Value.Source.isPlaying).AttachExternalCancellation(_onDestroyToken);
		await UniTask.WaitUntil(() => !_playingBgm.Value.Source.isPlaying).AttachExternalCancellation(_onDestroyToken);
		_onDestroyToken.ThrowIfCancellationRequested();
		_playingBgm.Value = baseMusic;
	}

	public AudioSource PlayBgm(string name, bool isLoop = true)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		if (currentSource.Source.isPlaying && currentSource.Source.clip.name == name)
		{
			return currentSource.Source;
		}
		currentSource.Source.loop = isLoop;
		currentSource.Source.clip = currentSource.Sound.Clip;
		RegisterTargetAudio(currentSource);
		baseMusic = currentSource;
		return currentSource.Source;
	}

	public AudioSource PlayBgmById(string Id, bool isLoop = true)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(Id);
		currentSourceById.Source.loop = isLoop;
		currentSourceById.Source.clip = currentSourceById.Sound.Clip;
		RegisterTargetAudio(currentSourceById);
		baseMusic = currentSourceById;
		return currentSourceById.Source;
	}

	public AudioSource PlayBgmByType(SoundType type, bool isLoop = false)
	{
		return PlayBgmById(type.ToString(), isLoop);
	}

	public TargetAudio PlaySe(string name, bool isLoop = false)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		currentSource.Source.loop = isLoop;
		RegisterTargetAudio(currentSource);
		return currentSource;
	}

	public TargetAudio PlaySeById(string Id, bool isLoop = false)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(Id);
		currentSourceById.Source.loop = isLoop;
		RegisterTargetAudio(currentSourceById);
		return currentSourceById;
	}

	public TargetAudio PlaySeByType(SoundType type, bool isLoop = false)
	{
		return PlaySeById(type.ToString(), isLoop);
	}

	public async UniTask PlaySeByTypeAsync(SoundType type)
	{
		await PlaySeByIdAsync(type.ToString()).AttachExternalCancellation(_onDestroyToken);
		_onDestroyToken.ThrowIfCancellationRequested();
	}

	public async UniTask PlaySeAsync(string name)
	{
		TargetAudio target = PlaySe(name);
		await UniTask.WaitWhile(() => target.Source.isPlaying).AttachExternalCancellation(_onDestroyToken);
		_onDestroyToken.ThrowIfCancellationRequested();
	}

	public async UniTask PlaySeByIdAsync(string name)
	{
		TargetAudio targetAudio = PlaySeById(name);
		try
		{
			await UniTask.Delay(Mathf.CeilToInt(targetAudio.Sound.Clip.length * 1000f), ignoreTimeScale: false, PlayerLoopTiming.Update, _onDestroyToken);
		}
		catch (OperationCanceledException)
		{
		}
		catch (NullReferenceException)
		{
		}
		_onDestroyToken.ThrowIfCancellationRequested();
	}

	public TargetAudio PlayBank(string name, bool isLoop = false)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		currentSource.Source.loop = isLoop;
		currentSource.Source.PlayOneShot(currentSource.Sound.Clip);
		return currentSource;
	}

	public TargetAudio PlayBankById(string Id, bool isLoop = false)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(Id);
		currentSourceById.Source.loop = isLoop;
		currentSourceById.Source.PlayOneShot(currentSourceById.Sound.Clip);
		return currentSourceById;
	}

	public TargetAudio PlayBankByType(SoundType type, bool isLoop = false)
	{
		return PlayBankById(type.ToString(), isLoop);
	}

	public async UniTask PlayBgmOneShotAsync(SoundType type, CancellationToken token)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(type.ToString());
		currentSourceById.Source.loop = false;
		await PlayBgmOneShotAsync(currentSourceById).AttachExternalCancellation(token);
	}

	public void StopBgm()
	{
		_playingBgm.Value?.Source?.Stop();
		_playingBgm.Value = null;
	}

	private AudioSource Stop(TargetAudio target)
	{
		if (!_isReady)
		{
			Initialize();
		}
		if (target.Source == null)
		{
			return null;
		}
		target.Source.Stop();
		return target.Source;
	}

	public AudioSource Stop(string name)
	{
		if (!_isReady)
		{
			Initialize();
		}
		Sound sound = _soundMaster.SoundList.FirstOrDefault((Sound x) => x.Music.FileName == name);
		AudioSource audioSource = _audioSources.FirstOrDefault((AudioSource x) => x.outputAudioMixerGroup.name == sound.Category);
		if ((object)audioSource != null)
		{
			audioSource.Stop();
			return audioSource;
		}
		return audioSource;
	}

	public AudioSource StopByType(SoundType type)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(type.ToString());
		return Stop(currentSourceById);
	}

	public void StopAll()
	{
		if (!_isReady)
		{
			Initialize();
		}
		foreach (AudioSource audioSource in _audioSources)
		{
			audioSource.Stop();
		}
	}

	public void ChangeMasterVolume(float value)
	{
		float num = 20f * Mathf.Log10(value);
		if (num == float.NegativeInfinity)
		{
			num = -96f;
		}
		_audioMixer.SetFloat("Master", num);
	}

	public void ChangeSeVolume(float value)
	{
		float num = 20f * Mathf.Log10(value);
		if (num == float.NegativeInfinity)
		{
			num = -96f;
		}
		_audioMixer.SetFloat("SE", num);
	}

	public void ChangeVolume(SoundCategory category, float value)
	{
		if (!_isReady)
		{
			Initialize();
		}
		float num = 20f * Mathf.Log10(value);
		if (float.IsNegativeInfinity(num))
		{
			num = -96f;
		}
		_audioMixer.SetFloat(category.ToString(), num);
	}

	private bool RegisterTargetAudio(TargetAudio audio)
	{
		if (string.IsNullOrEmpty(audio?.Sound?.Category))
		{
			Debug.LogError("SOUND: Unknown sound try to play.");
			return false;
		}
		switch (FetchCategory(audio))
		{
		case SoundCategory.BGM:
		case SoundCategory.BANK:
			if (_playingBgm.Value != null && _playingBgm.Value.Sound.Id == audio.Sound.Id)
			{
				return false;
			}
			_playingBgm.Value = audio;
			return true;
		case SoundCategory.SE:
		case SoundCategory.CLICK:
			Play(audio);
			return true;
		default:
			return false;
		}
	}

	private SoundCategory FetchCategory(TargetAudio audio)
	{
		if (string.IsNullOrEmpty(audio?.Sound?.Category))
		{
			Debug.LogError("SOUND: Unknown sound.");
			return SoundCategory.NONE;
		}
		if (audio.Sound.Category.Contains(SoundCategory.BANK.ToString()))
		{
			return SoundCategory.BANK;
		}
		if (audio.Sound.Category.Contains(SoundCategory.BGM.ToString()))
		{
			return SoundCategory.BGM;
		}
		if (audio.Sound.Category.Contains(SoundCategory.CLICK.ToString()))
		{
			return SoundCategory.CLICK;
		}
		if (audio.Sound.Category.Contains(SoundCategory.SE.ToString()))
		{
			return SoundCategory.SE;
		}
		Debug.LogError("SOUND: " + audio.Sound.Category + " is unexpected CATEGORY");
		return SoundCategory.NONE;
	}

	private TargetAudio GetCurrentSource(string name)
	{
		if (!_isReady)
		{
			Initialize();
		}
		Sound sound = _soundMaster.SoundList.FirstOrDefault((Sound x) => x.Music.FileName == name);
		AudioSource source = _audioSources.First((AudioSource x) => x.outputAudioMixerGroup.name == sound.Category);
		return new TargetAudio
		{
			Sound = sound,
			Source = source,
			PlayTime = sound.Clip.length
		};
	}

	private TargetAudio GetCurrentSourceById(string Id)
	{
		if (!_isReady)
		{
			Initialize();
		}
		Sound sound = _soundMaster.SoundList.FirstOrDefault((Sound x) => x.Id == Id);
		if (sound == null)
		{
			return null;
		}
		string mixerName = sound.Category ?? "";
		AudioSource source = _audioSources.First((AudioSource x) => x.outputAudioMixerGroup.name == mixerName);
		return new TargetAudio
		{
			Sound = sound,
			Source = source,
			PlayTime = sound.Clip.length
		};
	}

	private TargetAudio GetNextSource(SoundCategory category, out int newIndex, int index = 0)
	{
		if (!_isReady)
		{
			Initialize();
		}
		List<Sound> list = _soundMaster.SoundList.Where((Sound sound) => sound.Category == category.ToString()).ToList();
		newIndex = (index + 1) % list.Count;
		Sound audio = list.ElementAtOrDefault(newIndex);
		if (audio == null)
		{
			Debug.LogError("Cant Find Next Audio");
			Sound s = list.First();
			newIndex = index;
			return new TargetAudio
			{
				Sound = s,
				Source = _audioSources.FirstOrDefault((AudioSource a) => a.outputAudioMixerGroup.name == s.Category),
				PlayTime = s.Clip.length
			};
		}
		AudioSource source = _audioSources.First((AudioSource x) => x.outputAudioMixerGroup.name == audio.Category);
		return new TargetAudio
		{
			Sound = audio,
			Source = source,
			PlayTime = audio.Clip.length
		};
	}

	public bool IsPlaying(SoundCategory category)
	{
		if (!_isReady)
		{
			Initialize();
		}
		string name = category.ToString();
		return _audioSources.Where((AudioSource x) => x.outputAudioMixerGroup.name.Contains(name)).Any((AudioSource x) => x.isPlaying);
	}

	public bool IsPlaying(SoundCategory category, string name)
	{
		if (!_isReady)
		{
			Initialize();
		}
		return _audioSources.Where((AudioSource x) => x.outputAudioMixerGroup.name.Contains(category.ToString())).Any((AudioSource x) => x.name == name && x.isPlaying);
	}

	public bool IsPlayingByType(SoundType type)
	{
		return GetCurrentSourceById(type.ToString())?.Source.isPlaying ?? false;
	}

	public TargetAudio FetchPlayingAudio(string name)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		if (currentSource == null)
		{
			Debug.LogError("Invalid Audio name");
			return null;
		}
		return currentSource;
	}

	public TargetAudio FetchPlayingAudioByType(SoundType type)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(type.ToString());
		if (currentSourceById == null || !currentSourceById.Source.isPlaying)
		{
			return null;
		}
		return currentSourceById;
	}

	public TargetAudio FetchPlayingAudioByCategory(SoundCategory category)
	{
		TargetAudio targetAudio = FetchPlayingAudioListByType().FirstOrDefault((TargetAudio s) => s.Sound.Category.Contains(category.ToString()));
		if (targetAudio == null || !targetAudio.Source.isPlaying)
		{
			return null;
		}
		return targetAudio;
	}

	public List<TargetAudio> FetchPlayingAudioListByType()
	{
		if (!_isReady)
		{
			Initialize();
		}
		List<AudioSource> list = _audioSources.Where((AudioSource x) => x.isPlaying).ToList();
		List<TargetAudio> list2 = new List<TargetAudio>();
		foreach (AudioSource source in list)
		{
			if (!(source.clip == null))
			{
				Sound sound = _soundMaster.SoundList.First((Sound m) => m.Clip.name == source.clip.name);
				list2.Add(new TargetAudio
				{
					Source = source,
					PlayTime = source.clip.length,
					Sound = sound
				});
			}
		}
		return list2;
	}
}
