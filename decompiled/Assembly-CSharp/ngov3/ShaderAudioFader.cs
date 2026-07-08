using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Audio;

namespace ngov3;

public class ShaderAudioFader : MonoBehaviour
{
	[SerializeField]
	private AudioMixer _audioMixer;

	private float _ageSlider = 1f;

	private BoolReactiveProperty _isSlipping = new BoolReactiveProperty(initialValue: false);

	private bool _isHiding;

	private PostEffectManager _postEffectManager;

	private void Start()
	{
		ResetAudioEffect();
	}

	private async UniTaskVoid SlippingSliderAsync()
	{
		while (_isSlipping.Value)
		{
			await UniTask.Delay(100);
			float num = (_isHiding ? 50f : 100f);
			_ageSlider -= Mathf.Sqrt(_ageSlider) / num;
		}
	}

	public void ResetAudioEffect()
	{
		_audioMixer.SetFloat("Master_Pitch", 1f);
		_audioMixer.SetFloat("Dist_Level", 0f);
		_audioMixer.SetFloat("PS_Pitch", 1f);
		_audioMixer.SetFloat("Flange_Drymix", 1f);
		_audioMixer.SetFloat("Flange_WetMix", 0f);
		_audioMixer.SetFloat("Flange_Depth", 1f);
		_audioMixer.SetFloat("Flange_Rate", 0.1f);
		_audioMixer.SetFloat("Lowpass_Cutoff", 22000f);
		_audioMixer.SetFloat("Lowpass_Resonance", 1f);
		_audioMixer.SetFloat("Echo_Delay", 500f);
		_audioMixer.SetFloat("Echo_Decay", 0f);
		_audioMixer.SetFloat("Echo_DryMix", 1f);
		_audioMixer.SetFloat("Echo_WetMix", 0f);
		_audioMixer.SetFloat("Highpass_Cutoff", 10f);
	}

	public void MogoMogo(bool onoff)
	{
		if (onoff)
		{
			_audioMixer.SetFloat("Master_Pitch", 1f);
			_audioMixer.SetFloat("Dist_Level", 0f);
			_audioMixer.SetFloat("PS_Pitch", 0.8f);
			_audioMixer.SetFloat("Flange_Drymix", 1f);
			_audioMixer.SetFloat("Flange_WetMix", 0f);
			_audioMixer.SetFloat("Flange_Depth", 1f);
			_audioMixer.SetFloat("Flange_Rate", 0.1f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 1200f);
			_audioMixer.SetFloat("Lowpass_Resonance", 1f);
			_audioMixer.SetFloat("Echo_Delay", 500f);
			_audioMixer.SetFloat("Echo_Decay", 0f);
			_audioMixer.SetFloat("Echo_DryMix", 1f);
			_audioMixer.SetFloat("Echo_WetMix", 0f);
			_audioMixer.SetFloat("Highpass_Cutoff", 10f);
		}
		else
		{
			ResetAudioEffect();
		}
	}

	public void UpdateAudioEffect(EffectType type, float weight)
	{
		_ageSlider = weight;
		switch (type)
		{
		case EffectType.Weed:
			_audioMixer.SetFloat("Master_Pitch", 1f - _ageSlider / 1.5f);
			_audioMixer.SetFloat("Dist_Level", 0f);
			_audioMixer.SetFloat("PS_Pitch", 1f);
			_audioMixer.SetFloat("Flange_Drymix", 1f - _ageSlider);
			_audioMixer.SetFloat("Flange_WetMix", 0f + _ageSlider);
			_audioMixer.SetFloat("Flange_Depth", 1f - _ageSlider);
			_audioMixer.SetFloat("Flange_Rate", 0.1f + _ageSlider * 8f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 22000f);
			_audioMixer.SetFloat("Lowpass_Resonance", 1f);
			_audioMixer.SetFloat("Echo_Delay", 500f);
			_audioMixer.SetFloat("Echo_Decay", 0f);
			_audioMixer.SetFloat("Echo_DryMix", 1f);
			_audioMixer.SetFloat("Echo_WetMix", 0f);
			_audioMixer.SetFloat("Highpass_Cutoff", 10f);
			break;
		case EffectType.Psyche:
			_audioMixer.SetFloat("Master_Pitch", 1f + _ageSlider);
			_audioMixer.SetFloat("Dist_Level", 0f);
			_audioMixer.SetFloat("PS_Pitch", 1f + _ageSlider * 2f);
			_audioMixer.SetFloat("Flange_Drymix", 1f - _ageSlider);
			_audioMixer.SetFloat("Flange_WetMix", 0f + _ageSlider);
			_audioMixer.SetFloat("Flange_Depth", 0.7f + _ageSlider / 4f);
			_audioMixer.SetFloat("Flange_Rate", 0.2f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 2000f);
			_audioMixer.SetFloat("Lowpass_Resonance", 5f + _ageSlider * 2f);
			_audioMixer.SetFloat("Echo_Delay", 500f);
			_audioMixer.SetFloat("Echo_Decay", 0f);
			_audioMixer.SetFloat("Echo_DryMix", 1f);
			_audioMixer.SetFloat("Echo_WetMix", 0f);
			_audioMixer.SetFloat("Highpass_Cutoff", 1000f);
			break;
		case EffectType.OD:
		case EffectType.OD2:
		case EffectType.OD3:
			_audioMixer.SetFloat("Master_Pitch", 1f + _ageSlider * 2f);
			_audioMixer.SetFloat("Dist_Level", 0f);
			_audioMixer.SetFloat("PS_Pitch", 1f);
			_audioMixer.SetFloat("Flange_Drymix", 1f);
			_audioMixer.SetFloat("Flange_WetMix", 0f);
			_audioMixer.SetFloat("Flange_Depth", 1f);
			_audioMixer.SetFloat("Flange_Rate", 0.1f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 22000f - _ageSlider * 15000f);
			_audioMixer.SetFloat("Lowpass_Resonance", 1f + _ageSlider * 10f);
			_audioMixer.SetFloat("Echo_Delay", 800f + _ageSlider * 100f);
			_audioMixer.SetFloat("Echo_Decay", 0.7f - _ageSlider / 3f);
			_audioMixer.SetFloat("Echo_DryMix", 1f - _ageSlider);
			_audioMixer.SetFloat("Echo_WetMix", 0f + _ageSlider);
			_audioMixer.SetFloat("Highpass_Cutoff", 10f);
			break;
		case EffectType.WristCut:
			_audioMixer.SetFloat("Master_Pitch", 1f - _ageSlider * 0.9f);
			_audioMixer.SetFloat("Dist_Level", 0f + _ageSlider / 2f);
			_audioMixer.SetFloat("PS_Pitch", 1f + _ageSlider);
			_audioMixer.SetFloat("Flange_Drymix", 1f);
			_audioMixer.SetFloat("Flange_WetMix", 0f);
			_audioMixer.SetFloat("Flange_Depth", 1f);
			_audioMixer.SetFloat("Flange_Rate", 0.1f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 22000f);
			_audioMixer.SetFloat("Lowpass_Resonance", 1f);
			_audioMixer.SetFloat("Echo_Delay", 150f - _ageSlider * 10f);
			_audioMixer.SetFloat("Echo_Decay", 0.6f);
			_audioMixer.SetFloat("Echo_DryMix", 1f - _ageSlider);
			_audioMixer.SetFloat("Echo_WetMix", 0f + _ageSlider);
			_audioMixer.SetFloat("Highpass_Cutoff", 10f + _ageSlider * 3000f);
			break;
		case EffectType.GoCrazy:
		case EffectType.Kyouizon:
			_audioMixer.SetFloat("Master_Pitch", 1f + _ageSlider / 10f);
			_audioMixer.SetFloat("Dist_Level", 0f + _ageSlider / 4f);
			_audioMixer.SetFloat("PS_Pitch", 1f + _ageSlider * 2f);
			_audioMixer.SetFloat("Flange_Drymix", 1f);
			_audioMixer.SetFloat("Flange_WetMix", 0f);
			_audioMixer.SetFloat("Flange_Depth", 1f);
			_audioMixer.SetFloat("Flange_Rate", 0.1f);
			_audioMixer.SetFloat("Lowpass_Cutoff", 22000f);
			_audioMixer.SetFloat("Lowpass_Resonance", 1f);
			_audioMixer.SetFloat("Echo_Delay", 150f - _ageSlider * 10f);
			_audioMixer.SetFloat("Echo_Decay", 0.6f);
			_audioMixer.SetFloat("Echo_DryMix", 1f - _ageSlider);
			_audioMixer.SetFloat("Echo_WetMix", 0f + _ageSlider);
			_audioMixer.SetFloat("Highpass_Cutoff", 10f + _ageSlider * 5000f);
			break;
		case EffectType.Kenjo:
		case EffectType.Noisy:
			break;
		}
	}
}
