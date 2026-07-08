using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayBgmOneShotAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public AudioManager _003C_003E4__this;

		public TargetAudio target;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AudioManager CS_0024_003C_003E8__locals10 = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0144;
					}
					CS_0024_003C_003E8__locals10.baseMusic = CS_0024_003C_003E8__locals10._playingBgm.Value;
					_ = target.Source.loop;
					CS_0024_003C_003E8__locals10._playingBgm.Value = target;
					val2 = UniTaskExtensions.AttachExternalCancellation(UniTask.WaitUntil((Func<bool>)(() => CS_0024_003C_003E8__locals10._playingBgm.Value.Source.isPlaying), (PlayerLoopTiming)8, default(CancellationToken), false), CS_0024_003C_003E8__locals10._onDestroyToken);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayBgmOneShotAsync_003Ed__24>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				val2 = UniTaskExtensions.AttachExternalCancellation(UniTask.WaitUntil((Func<bool>)(() => !CS_0024_003C_003E8__locals10._playingBgm.Value.Source.isPlaying), (PlayerLoopTiming)8, default(CancellationToken), false), CS_0024_003C_003E8__locals10._onDestroyToken);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayBgmOneShotAsync_003Ed__24>(ref val, ref this);
					return;
				}
				goto IL_0144;
				IL_0144:
				((Awaiter)(ref val)).GetResult();
				CS_0024_003C_003E8__locals10._onDestroyToken.ThrowIfCancellationRequested();
				CS_0024_003C_003E8__locals10._playingBgm.Value = CS_0024_003C_003E8__locals10.baseMusic;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayBgmOneShotAsync_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public AudioManager _003C_003E4__this;

		public SoundType type;

		public CancellationToken token;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AudioManager audioManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					TargetAudio currentSourceById = audioManager.GetCurrentSourceById(type.ToString());
					currentSourceById.Source.loop = false;
					UniTask val = UniTaskExtensions.AttachExternalCancellation(audioManager.PlayBgmOneShotAsync(currentSourceById), token);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayBgmOneShotAsync_003Ed__37>(ref val2, ref this);
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlaySeAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public AudioManager _003C_003E4__this;

		public string name;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AudioManager audioManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					TargetAudio target = audioManager.PlaySe(name);
					UniTask val = UniTaskExtensions.AttachExternalCancellation(UniTask.WaitWhile((Func<bool>)(() => target.Source.isPlaying), (PlayerLoopTiming)8, default(CancellationToken), false), audioManager._onDestroyToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlaySeAsync_003Ed__32>(ref val2, ref this);
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
				audioManager._onDestroyToken.ThrowIfCancellationRequested();
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlaySeByIdAsync_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public AudioManager _003C_003E4__this;

		public string name;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AudioManager audioManager = _003C_003E4__this;
			try
			{
				TargetAudio targetAudio = default(TargetAudio);
				if (num != 0)
				{
					targetAudio = audioManager.PlaySeById(name);
				}
				try
				{
					Awaiter val2;
					if (num != 0)
					{
						UniTask val = UniTask.Delay(Mathf.CeilToInt(targetAudio.Sound.Clip.length * 1000f), false, (PlayerLoopTiming)8, audioManager._onDestroyToken, false);
						val2 = ((UniTask)(ref val)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlaySeByIdAsync_003Ed__33>(ref val2, ref this);
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
				}
				catch (OperationCanceledException)
				{
				}
				catch (NullReferenceException)
				{
				}
				audioManager._onDestroyToken.ThrowIfCancellationRequested();
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlaySeByTypeAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public AudioManager _003C_003E4__this;

		public SoundType type;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AudioManager audioManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = UniTaskExtensions.AttachExternalCancellation(audioManager.PlaySeByIdAsync(type.ToString()), audioManager._onDestroyToken);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlaySeByTypeAsync_003Ed__31>(ref val2, ref this);
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
				audioManager._onDestroyToken.ThrowIfCancellationRequested();
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
			if (!((Object)(object)_instance == (Object)null))
			{
				return _instance;
			}
			return Object.FindObjectOfType<AudioManager>();
		}
	}

	public IReadOnlyReactiveCollection<TargetAudio> PlayingSeList => (IReadOnlyReactiveCollection<TargetAudio>)(object)_playingSeList;

	public IReadOnlyReactiveProperty<TargetAudio> PlayingBgm => (IReadOnlyReactiveProperty<TargetAudio>)(object)_playingBgm;

	private void Awake()
	{
		_onDestroyToken = UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this);
		if (Object.FindObjectsOfType<AudioManager>().Length > 1)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
		else
		{
			Object.DontDestroyOnLoad((Object)(object)((Component)this).gameObject);
		}
	}

	private async void Start()
	{
		Initialize();
		AsyncSubject<Unit> val = Observable.GetAwaiter<Unit>(SingletonMonoBehaviour<Settings>.Instance.OnLoadObservable);
		if (!val.IsCompleted)
		{
			await val;
			object obj = default(object);
			val = (AsyncSubject<Unit>)obj;
		}
		val.GetResult();
		ChangeVolume(SoundCategory.BGM, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
		ChangeVolume(SoundCategory.BANK, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
		ChangeSeVolume(SingletonMonoBehaviour<Settings>.Instance.SeVolume);
		Debug.Log((object)"AudioSetCompleat");
	}

	private void Initialize()
	{
		if (_isReady)
		{
			return;
		}
		_audioSources = ((Component)this).GetComponents<AudioSource>()?.ToList();
		_isReady = true;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<IList<TargetAudio>>(Observable.Buffer<TargetAudio>((IObservable<TargetAudio>)_playingBgm, 2, 1), (Action<IList<TargetAudio>>)delegate(IList<TargetAudio> audios)
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
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<TargetAudio>>(Observable.Where<CollectionAddEvent<TargetAudio>>(_playingSeList.ObserveAdd(), (Func<CollectionAddEvent<TargetAudio>, bool>)((CollectionAddEvent<TargetAudio> x) => (Object)(object)x.Value.Source != (Object)null)), (Action<CollectionAddEvent<TargetAudio>>)async delegate(CollectionAddEvent<TargetAudio> audio)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			Play(audio.Value);
			await UniTask.NextFrame((PlayerLoopTiming)9, _onDestroyToken, false);
			await UniTaskExtensions.AttachExternalCancellation(UniTask.WaitUntil((Func<bool>)(() => !audio.Value.Source.isPlaying), (PlayerLoopTiming)8, default(CancellationToken), false), _onDestroyToken);
			_onDestroyToken.ThrowIfCancellationRequested();
			((Collection<TargetAudio>)(object)_playingSeList).Remove(audio.Value);
		}), ((Component)this).gameObject);
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
		return _audioSources.First((AudioSource x) => ((Object)x.outputAudioMixerGroup).name == category);
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

	[AsyncStateMachine(typeof(_003CPlayBgmOneShotAsync_003Ed__24))]
	private UniTask PlayBgmOneShotAsync(TargetAudio target)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayBgmOneShotAsync_003Ed__24 _003CPlayBgmOneShotAsync_003Ed__38 = default(_003CPlayBgmOneShotAsync_003Ed__24);
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003E4__this = this;
		_003CPlayBgmOneShotAsync_003Ed__38.target = target;
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder)).Start<_003CPlayBgmOneShotAsync_003Ed__24>(ref _003CPlayBgmOneShotAsync_003Ed__38);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder)).Task;
	}

	public AudioSource PlayBgm(string name, bool isLoop = true)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		if (currentSource.Source.isPlaying && ((Object)currentSource.Source.clip).name == name)
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

	[AsyncStateMachine(typeof(_003CPlaySeByTypeAsync_003Ed__31))]
	public UniTask PlaySeByTypeAsync(SoundType type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlaySeByTypeAsync_003Ed__31 _003CPlaySeByTypeAsync_003Ed__32 = default(_003CPlaySeByTypeAsync_003Ed__31);
		_003CPlaySeByTypeAsync_003Ed__32._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlaySeByTypeAsync_003Ed__32._003C_003E4__this = this;
		_003CPlaySeByTypeAsync_003Ed__32.type = type;
		_003CPlaySeByTypeAsync_003Ed__32._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlaySeByTypeAsync_003Ed__32._003C_003Et__builder)).Start<_003CPlaySeByTypeAsync_003Ed__31>(ref _003CPlaySeByTypeAsync_003Ed__32);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlaySeByTypeAsync_003Ed__32._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPlaySeAsync_003Ed__32))]
	public UniTask PlaySeAsync(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlaySeAsync_003Ed__32 _003CPlaySeAsync_003Ed__33 = default(_003CPlaySeAsync_003Ed__32);
		_003CPlaySeAsync_003Ed__33._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlaySeAsync_003Ed__33._003C_003E4__this = this;
		_003CPlaySeAsync_003Ed__33.name = name;
		_003CPlaySeAsync_003Ed__33._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlaySeAsync_003Ed__33._003C_003Et__builder)).Start<_003CPlaySeAsync_003Ed__32>(ref _003CPlaySeAsync_003Ed__33);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlaySeAsync_003Ed__33._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPlaySeByIdAsync_003Ed__33))]
	public UniTask PlaySeByIdAsync(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlaySeByIdAsync_003Ed__33 _003CPlaySeByIdAsync_003Ed__34 = default(_003CPlaySeByIdAsync_003Ed__33);
		_003CPlaySeByIdAsync_003Ed__34._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlaySeByIdAsync_003Ed__34._003C_003E4__this = this;
		_003CPlaySeByIdAsync_003Ed__34.name = name;
		_003CPlaySeByIdAsync_003Ed__34._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlaySeByIdAsync_003Ed__34._003C_003Et__builder)).Start<_003CPlaySeByIdAsync_003Ed__33>(ref _003CPlaySeByIdAsync_003Ed__34);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlaySeByIdAsync_003Ed__34._003C_003Et__builder)).Task;
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

	[AsyncStateMachine(typeof(_003CPlayBgmOneShotAsync_003Ed__37))]
	public UniTask PlayBgmOneShotAsync(SoundType type, CancellationToken token)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayBgmOneShotAsync_003Ed__37 _003CPlayBgmOneShotAsync_003Ed__38 = default(_003CPlayBgmOneShotAsync_003Ed__37);
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003E4__this = this;
		_003CPlayBgmOneShotAsync_003Ed__38.type = type;
		_003CPlayBgmOneShotAsync_003Ed__38.token = token;
		_003CPlayBgmOneShotAsync_003Ed__38._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder)).Start<_003CPlayBgmOneShotAsync_003Ed__37>(ref _003CPlayBgmOneShotAsync_003Ed__38);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayBgmOneShotAsync_003Ed__38._003C_003Et__builder)).Task;
	}

	public void StopBgm()
	{
		TargetAudio value = _playingBgm.Value;
		if (value != null)
		{
			AudioSource source = value.Source;
			if (source != null)
			{
				source.Stop();
			}
		}
		_playingBgm.Value = null;
	}

	private AudioSource Stop(TargetAudio target)
	{
		if (!_isReady)
		{
			Initialize();
		}
		if ((Object)(object)target.Source == (Object)null)
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
		AudioSource? obj = _audioSources.FirstOrDefault((AudioSource x) => ((Object)x.outputAudioMixerGroup).name == sound.Category);
		if (obj != null)
		{
			obj.Stop();
			return obj;
		}
		return obj;
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
			Debug.LogError((object)"SOUND: Unknown sound try to play.");
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
			Debug.LogError((object)"SOUND: Unknown sound.");
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
		Debug.LogError((object)("SOUND: " + audio.Sound.Category + " is unexpected CATEGORY"));
		return SoundCategory.NONE;
	}

	private TargetAudio GetCurrentSource(string name)
	{
		if (!_isReady)
		{
			Initialize();
		}
		Sound sound = _soundMaster.SoundList.FirstOrDefault((Sound x) => x.Music.FileName == name);
		AudioSource source = _audioSources.First((AudioSource x) => ((Object)x.outputAudioMixerGroup).name == sound.Category);
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
		AudioSource source = _audioSources.First((AudioSource x) => ((Object)x.outputAudioMixerGroup).name == mixerName);
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
			Debug.LogError((object)"Cant Find Next Audio");
			Sound s = list.First();
			newIndex = index;
			return new TargetAudio
			{
				Sound = s,
				Source = _audioSources.FirstOrDefault((AudioSource a) => ((Object)a.outputAudioMixerGroup).name == s.Category),
				PlayTime = s.Clip.length
			};
		}
		AudioSource source = _audioSources.First((AudioSource x) => ((Object)x.outputAudioMixerGroup).name == audio.Category);
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
		return _audioSources.Where((AudioSource x) => ((Object)x.outputAudioMixerGroup).name.Contains(name)).Any((AudioSource x) => x.isPlaying);
	}

	public bool IsPlaying(SoundCategory category, string name)
	{
		if (!_isReady)
		{
			Initialize();
		}
		return _audioSources.Where((AudioSource x) => ((Object)x.outputAudioMixerGroup).name.Contains(category.ToString())).Any((AudioSource x) => ((Object)x).name == name && x.isPlaying);
	}

	public bool IsPlayingByType(SoundType type)
	{
		TargetAudio currentSourceById = GetCurrentSourceById(type.ToString());
		if (currentSourceById == null)
		{
			return false;
		}
		return currentSourceById.Source.isPlaying;
	}

	public TargetAudio FetchPlayingAudio(string name)
	{
		TargetAudio currentSource = GetCurrentSource(name);
		if (currentSource == null)
		{
			Debug.LogError((object)"Invalid Audio name");
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
			if (!((Object)(object)source.clip == (Object)null))
			{
				Sound sound = _soundMaster.SoundList.First((Sound m) => ((Object)m.Clip).name == ((Object)source.clip).name);
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
