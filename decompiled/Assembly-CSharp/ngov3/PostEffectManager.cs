using System;
using DG.Tweening;
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
			if (!(_instance == null))
			{
				return _instance;
			}
			return UnityEngine.Object.FindObjectOfType<PostEffectManager>();
		}
	}

	public IReadOnlyReactiveProperty<EffectType> CurrentShaderType => _currentShaderType;

	public Volume BloomLight => _bloomlight;

	private Sequence ResetShaderCalmlyTweener { get; set; }

	private void Awake()
	{
		if (UnityEngine.Object.FindObjectsOfType<PostEffectManager>().Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private void Start()
	{
		_currentShaderType.SkipLatestValueOnSubscribe().Subscribe(delegate(EffectType type)
		{
			switch (type)
			{
			case EffectType.Kenjo:
				_overdose.enabled = false;
				_overdosePron.enabled = false;
				_overdoseHyporon.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = false;
				_goCrazy.enabled = false;
				_kyouizon.enabled = false;
				_bleeding.enabled = false;
				_satujinNoise.enabled = false;
				_satujinGata.enabled = false;
				_anmaku.enabled = false;
				_otona.enabled = false;
				_noisy.enabled = false;
				_invert.enabled = false;
				_horror.enabled = false;
				_yugami.enabled = false;
				_bloomlight.enabled = false;
				_kakusei.enabled = false;
				_powapowa.enabled = false;
				_audioEffect.UpdateAudioEffect(EffectType.Kenjo, 0f);
				break;
			case EffectType.OD:
				_overdose.enabled = true;
				_psyche.enabled = false;
				_weed.enabled = false;
				break;
			case EffectType.OD2:
				_overdosePron.enabled = true;
				break;
			case EffectType.OD3:
				_overdoseHyporon.enabled = true;
				break;
			case EffectType.Invert:
				_invert.enabled = true;
				break;
			case EffectType.Psyche:
				_overdose.enabled = false;
				_psyche.enabled = true;
				_weed.enabled = false;
				break;
			case EffectType.Weed:
				_overdose.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = true;
				break;
			case EffectType.GoCrazy:
				_overdose.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = false;
				_goCrazy.enabled = true;
				break;
			case EffectType.SatujinNoise:
				_satujinNoise.enabled = true;
				_overdose.enabled = false;
				_overdosePron.enabled = false;
				_overdoseHyporon.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = false;
				_goCrazy.enabled = false;
				_kyouizon.enabled = false;
				_bleeding.enabled = false;
				_satujinGata.enabled = false;
				_anmaku.enabled = false;
				_otona.enabled = false;
				_noisy.enabled = false;
				_invert.enabled = false;
				_horror.enabled = false;
				_yugami.enabled = false;
				_bloomlight.enabled = false;
				_kakusei.enabled = false;
				_powapowa.enabled = false;
				break;
			case EffectType.horror:
				_horror.enabled = true;
				_overdose.enabled = false;
				_overdosePron.enabled = false;
				_overdoseHyporon.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = false;
				_goCrazy.enabled = false;
				_kyouizon.enabled = false;
				_bleeding.enabled = false;
				_satujinNoise.enabled = false;
				_satujinGata.enabled = false;
				_anmaku.enabled = false;
				_otona.enabled = false;
				_noisy.enabled = false;
				_invert.enabled = false;
				_yugami.enabled = false;
				_bloomlight.enabled = false;
				_kakusei.enabled = false;
				_powapowa.enabled = false;
				break;
			case EffectType.Yugami:
				_yugami.enabled = true;
				_overdose.enabled = false;
				_overdosePron.enabled = false;
				_overdoseHyporon.enabled = false;
				_psyche.enabled = false;
				_weed.enabled = false;
				_goCrazy.enabled = false;
				_kyouizon.enabled = false;
				_bleeding.enabled = false;
				_satujinNoise.enabled = false;
				_satujinGata.enabled = false;
				_anmaku.enabled = false;
				_otona.enabled = false;
				_noisy.enabled = false;
				_invert.enabled = false;
				_horror.enabled = false;
				_bloomlight.enabled = false;
				_kakusei.enabled = false;
				_powapowa.enabled = false;
				break;
			case EffectType.Anmaku:
				_anmaku.enabled = true;
				break;
			case EffectType.Otona:
				_otona.enabled = true;
				_otona.weight = 0f;
				DOTween.To(() => _otona.weight, delegate(float x)
				{
					_otona.weight = x;
				}, 1f, 1f).Play();
				break;
			case EffectType.Noisy:
				_noisy.enabled = true;
				_otona.weight = 0f;
				DOTween.To(() => _noisy.weight, delegate(float x)
				{
					_noisy.weight = x;
				}, 1f, 1f).SetEase(Ease.InExpo).Play();
				break;
			case EffectType.Kyouizon:
				_kyouizon.enabled = true;
				break;
			case EffectType.Bleeding:
				_bleeding.enabled = true;
				break;
			case EffectType.BloomLight:
				_bloomlight.enabled = true;
				break;
			case EffectType.Kakusei:
				_kakusei.enabled = true;
				break;
			case EffectType.Powapowa:
				_powapowa.enabled = true;
				break;
			case EffectType.WristCut:
			case EffectType.Gatagata:
			case EffectType.ChoosingComment:
				break;
			}
		}).AddTo(base.gameObject);
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
		DOTween.To(() => _anmaku.weight, delegate(float x)
		{
			_anmaku.weight = x;
		}, targetWeight, 0.8f).Play();
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
		if (effectType != CurrentShaderType.Value)
		{
			return;
		}
		if (killCurrentShaderCalmly)
		{
			ResetShaderCalmlyTweener?.Kill(complete: true);
		}
		ResetShaderCalmlyTweener = DOTween.Sequence().Append(DOTween.To(() => _overdose.weight, delegate(float x)
		{
			SetShaderWeight(x, effectType);
		}, 0f, 16f).SetEase(Ease.Linear)).OnComplete(delegate
		{
			if (_currentShaderType.Value == effectType)
			{
				_currentShaderType.Value = EffectType.Kenjo;
			}
		})
			.Play();
	}

	public void Dispose()
	{
		_instance = null;
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
