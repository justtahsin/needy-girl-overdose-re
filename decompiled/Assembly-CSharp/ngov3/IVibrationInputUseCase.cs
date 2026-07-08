namespace ngov3;

public interface IVibrationInputUseCase
{
	void Vibrate(float duration, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh);
}
