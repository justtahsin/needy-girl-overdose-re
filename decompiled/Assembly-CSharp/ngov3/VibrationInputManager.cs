namespace ngov3;

public class VibrationInputManager : SingletonMonoBehaviour<VibrationInputManager>
{
	private IVibrationInputUseCase VibrationInputUseCase { get; set; }

	private void Start()
	{
	}

	public void Vibrate(float duration = 0.3f, float amplitudeLow = 1f, float frequencyLow = 50f, float amplitudeHigh = 0.5f, float frequencyHigh = 100f)
	{
		if (SingletonMonoBehaviour<Settings>.Instance.VibrationType.Value == VibrationType.On)
		{
			VibrationInputUseCase?.Vibrate(duration, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}
	}
}
