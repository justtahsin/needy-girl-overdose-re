using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;

namespace ngov3;

public sealed class PostEffectManager : MonoBehaviour, IDisposable
{
	private static PostEffectManager _instance;

	[SerializeField]
	private ShaderAudioFader _audioEffect;

	[SerializeField]
	private Volume _overdose;

	[SerializeField]
	private Volume _overdosePron;

	[SerializeField]
	private Volume _overdoseHyporon;

	[SerializeField]
	private Volume _psyche;

	[SerializeField]
	private Volume _weed;

	[SerializeField]
	private Volume _goCrazy;

	[SerializeField]
	private Volume _kyouizon;

	[SerializeField]
	private Volume _bleeding;

	[SerializeField]
	private Volume _satujinNoise;

	[SerializeField]
	private Volume _satujinGata;

	[SerializeField]
	private Volume _anmaku;

	[SerializeField]
	private Volume _otona;

	[SerializeField]
	private Volume _noisy;

	[SerializeField]
	private Volume _invert;

	[SerializeField]
	private Volume _horror;

	[SerializeField]
	private Volume _yugami;

	[SerializeField]
	private Volume _bloomlight;

	[SerializeField]
	private Volume _kakusei;

	[SerializeField]
	private Volume _powapowa;

	private ReactiveProperty<EffectType> _currentShaderType = new ReactiveProperty<EffectType>(EffectType.Kenjo);

	public static PostEffectManager Instance
	{
		get
		{
			if (!((Object)(object)_instance == (Object)null))
			{
				return _instance;
			}
			return Object.FindObjectOfType<PostEffectManager>();
		}
	}

	public IReadOnlyReactiveProperty<EffectType> CurrentShaderType => (IReadOnlyReactiveProperty<EffectType>)(object)_currentShaderType;

	public Volume BloomLight => _bloomlight;

	private Sequence ResetShaderCalmlyTweener { get; set; }

	private void Awake()
	{
		if (Object.FindObjectsOfType<PostEffectManager>().Length > 1)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
		else
		{
			Object.DontDestroyOnLoad((Object)(object)((Component)this).gameObject);
		}
	}

	private void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<EffectType>(ReactivePropertyExtensions.SkipLatestValueOnSubscribe<EffectType>((IReadOnlyReactiveProperty<EffectType>)(object)_currentShaderType), (Action<EffectType>)delegate(EffectType type)
		{
			switch (type)
			{
			case EffectType.Kenjo:
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_overdosePron).enabled = false;
				((Behaviour)_overdoseHyporon).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				((Behaviour)_goCrazy).enabled = false;
				((Behaviour)_kyouizon).enabled = false;
				((Behaviour)_bleeding).enabled = false;
				((Behaviour)_satujinNoise).enabled = false;
				((Behaviour)_satujinGata).enabled = false;
				((Behaviour)_anmaku).enabled = false;
				((Behaviour)_otona).enabled = false;
				((Behaviour)_noisy).enabled = false;
				((Behaviour)_invert).enabled = false;
				((Behaviour)_horror).enabled = false;
				((Behaviour)_yugami).enabled = false;
				((Behaviour)_bloomlight).enabled = false;
				((Behaviour)_kakusei).enabled = false;
				((Behaviour)_powapowa).enabled = false;
				_audioEffect.UpdateAudioEffect(EffectType.Kenjo, 0f);
				break;
			case EffectType.OD:
				((Behaviour)_overdose).enabled = true;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				break;
			case EffectType.OD2:
				((Behaviour)_overdosePron).enabled = true;
				break;
			case EffectType.OD3:
				((Behaviour)_overdoseHyporon).enabled = true;
				break;
			case EffectType.Invert:
				((Behaviour)_invert).enabled = true;
				break;
			case EffectType.Psyche:
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_psyche).enabled = true;
				((Behaviour)_weed).enabled = false;
				break;
			case EffectType.Weed:
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = true;
				break;
			case EffectType.GoCrazy:
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				((Behaviour)_goCrazy).enabled = true;
				break;
			case EffectType.SatujinNoise:
				((Behaviour)_satujinNoise).enabled = true;
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_overdosePron).enabled = false;
				((Behaviour)_overdoseHyporon).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				((Behaviour)_goCrazy).enabled = false;
				((Behaviour)_kyouizon).enabled = false;
				((Behaviour)_bleeding).enabled = false;
				((Behaviour)_satujinGata).enabled = false;
				((Behaviour)_anmaku).enabled = false;
				((Behaviour)_otona).enabled = false;
				((Behaviour)_noisy).enabled = false;
				((Behaviour)_invert).enabled = false;
				((Behaviour)_horror).enabled = false;
				((Behaviour)_yugami).enabled = false;
				((Behaviour)_bloomlight).enabled = false;
				((Behaviour)_kakusei).enabled = false;
				((Behaviour)_powapowa).enabled = false;
				break;
			case EffectType.horror:
				((Behaviour)_horror).enabled = true;
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_overdosePron).enabled = false;
				((Behaviour)_overdoseHyporon).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				((Behaviour)_goCrazy).enabled = false;
				((Behaviour)_kyouizon).enabled = false;
				((Behaviour)_bleeding).enabled = false;
				((Behaviour)_satujinNoise).enabled = false;
				((Behaviour)_satujinGata).enabled = false;
				((Behaviour)_anmaku).enabled = false;
				((Behaviour)_otona).enabled = false;
				((Behaviour)_noisy).enabled = false;
				((Behaviour)_invert).enabled = false;
				((Behaviour)_yugami).enabled = false;
				((Behaviour)_bloomlight).enabled = false;
				((Behaviour)_kakusei).enabled = false;
				((Behaviour)_powapowa).enabled = false;
				break;
			case EffectType.Yugami:
				((Behaviour)_yugami).enabled = true;
				((Behaviour)_overdose).enabled = false;
				((Behaviour)_overdosePron).enabled = false;
				((Behaviour)_overdoseHyporon).enabled = false;
				((Behaviour)_psyche).enabled = false;
				((Behaviour)_weed).enabled = false;
				((Behaviour)_goCrazy).enabled = false;
				((Behaviour)_kyouizon).enabled = false;
				((Behaviour)_bleeding).enabled = false;
				((Behaviour)_satujinNoise).enabled = false;
				((Behaviour)_satujinGata).enabled = false;
				((Behaviour)_anmaku).enabled = false;
				((Behaviour)_otona).enabled = false;
				((Behaviour)_noisy).enabled = false;
				((Behaviour)_invert).enabled = false;
				((Behaviour)_horror).enabled = false;
				((Behaviour)_bloomlight).enabled = false;
				((Behaviour)_kakusei).enabled = false;
				((Behaviour)_powapowa).enabled = false;
				break;
			case EffectType.Anmaku:
				((Behaviour)_anmaku).enabled = true;
				break;
			case EffectType.Otona:
				((Behaviour)_otona).enabled = true;
				_otona.weight = 0f;
				TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _otona.weight), (DOSetter<float>)delegate(float x)
				{
					_otona.weight = x;
				}, 1f, 1f));
				break;
			case EffectType.Noisy:
				((Behaviour)_noisy).enabled = true;
				_otona.weight = 0f;
				TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _noisy.weight), (DOSetter<float>)delegate(float x)
				{
					_noisy.weight = x;
				}, 1f, 1f), (Ease)17));
				break;
			case EffectType.Kyouizon:
				((Behaviour)_kyouizon).enabled = true;
				break;
			case EffectType.Bleeding:
				((Behaviour)_bleeding).enabled = true;
				break;
			case EffectType.BloomLight:
				((Behaviour)_bloomlight).enabled = true;
				break;
			case EffectType.Kakusei:
				((Behaviour)_kakusei).enabled = true;
				break;
			case EffectType.Powapowa:
				((Behaviour)_powapowa).enabled = true;
				break;
			case EffectType.WristCut:
			case EffectType.Gatagata:
			case EffectType.ChoosingComment:
				break;
			}
		}), ((Component)this).gameObject);
	}

	public void MogoMogo(bool onoff)
	{
		_audioEffect.MogoMogo(onoff);
	}

	public void SetShaderWeight(float weight)
	{
		SetShaderWeight(weight, CurrentShaderType.Value);
	}

	public void SetShaderWeight(float weight, EffectType type)
	{
		if (CurrentShaderType.Value == type)
		{
			_overdose.weight = weight;
			_overdosePron.weight = weight;
			_overdoseHyporon.weight = weight;
			_psyche.weight = weight;
			_weed.weight = weight;
			_goCrazy.weight = weight;
			_kyouizon.weight = weight;
			_bleeding.weight = weight;
			_satujinNoise.weight = weight;
			_satujinGata.weight = weight;
			_anmaku.weight = weight;
			_otona.weight = weight;
			_noisy.weight = weight;
			_invert.weight = weight;
			_horror.weight = weight;
			_yugami.weight = weight;
			_bloomlight.weight = weight;
			_kakusei.weight = weight;
			_audioEffect.UpdateAudioEffect(CurrentShaderType.Value, weight);
		}
	}

	public void AnmakuWeight(float targetWeight)
	{
		_currentShaderType.Value = EffectType.Anmaku;
		_anmaku.weight = 0f;
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _anmaku.weight), (DOSetter<float>)delegate(float x)
		{
			_anmaku.weight = x;
		}, targetWeight, 0.8f));
	}

	public void SetShader(EffectType type)
	{
		_audioEffect.UpdateAudioEffect(type, 1f);
		_currentShaderType.Value = type;
	}

	public void ResetShader()
	{
		_audioEffect.ResetAudioEffect();
		_currentShaderType.Value = EffectType.Kenjo;
	}

	public void ResetShaderCalmly(bool killCurrentShaderCalmly = true)
	{
		ResetShaderCalmly(CurrentShaderType.Value, killCurrentShaderCalmly);
	}

	public void ResetShaderCalmly(EffectType effectType, bool killCurrentShaderCalmly = true)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		if (effectType != CurrentShaderType.Value)
		{
			return;
		}
		if (killCurrentShaderCalmly)
		{
			Sequence resetShaderCalmlyTweener = ResetShaderCalmlyTweener;
			if (resetShaderCalmlyTweener != null)
			{
				TweenExtensions.Kill((Tween)(object)resetShaderCalmlyTweener, true);
			}
		}
		ResetShaderCalmlyTweener = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _overdose.weight), (DOSetter<float>)delegate(float x)
		{
			SetShaderWeight(x, effectType);
		}, 0f, 16f), (Ease)1)), (TweenCallback)delegate
		{
			if (_currentShaderType.Value == effectType)
			{
				_currentShaderType.Value = EffectType.Kenjo;
			}
		}));
	}

	public void Dispose()
	{
		_instance = null;
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}
}
