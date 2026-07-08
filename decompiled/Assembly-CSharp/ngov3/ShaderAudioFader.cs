using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.Audio;

namespace ngov3;

public class ShaderAudioFader : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSlippingSliderAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public ShaderAudioFader _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ShaderAudioFader shaderAudioFader = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					goto IL_00b2;
				}
				Awaiter val = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter);
				num = (_003C_003E1__state = -1);
				goto IL_007c;
				IL_007c:
				((Awaiter)(ref val)).GetResult();
				float num2 = (shaderAudioFader._isHiding ? 50f : 100f);
				shaderAudioFader._ageSlider -= Mathf.Sqrt(shaderAudioFader._ageSlider) / num2;
				goto IL_00b2;
				IL_00b2:
				if (((ReactiveProperty<bool>)(object)shaderAudioFader._isSlipping).Value)
				{
					UniTask val2 = UniTask.Delay(100, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CSlippingSliderAsync_003Ed__6>(ref val, ref this);
						return;
					}
					goto IL_007c;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	private AudioMixer _audioMixer;

	private float _ageSlider = 1f;

	private BoolReactiveProperty _isSlipping = new BoolReactiveProperty(false);

	private bool _isHiding;

	private PostEffectManager _postEffectManager;

	private void Start()
	{
		ResetAudioEffect();
	}

	[AsyncStateMachine(typeof(_003CSlippingSliderAsync_003Ed__6))]
	private UniTaskVoid SlippingSliderAsync()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSlippingSliderAsync_003Ed__6 _003CSlippingSliderAsync_003Ed__7 = default(_003CSlippingSliderAsync_003Ed__6);
		_003CSlippingSliderAsync_003Ed__7._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CSlippingSliderAsync_003Ed__7._003C_003E4__this = this;
		_003CSlippingSliderAsync_003Ed__7._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CSlippingSliderAsync_003Ed__7._003C_003Et__builder)).Start<_003CSlippingSliderAsync_003Ed__6>(ref _003CSlippingSliderAsync_003Ed__7);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CSlippingSliderAsync_003Ed__7._003C_003Et__builder)).Task;
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
