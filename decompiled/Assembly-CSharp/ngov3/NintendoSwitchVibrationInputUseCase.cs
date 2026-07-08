using Rewired;

namespace ngov3;

public class NintendoSwitchVibrationInputUseCase : IVibrationInputUseCase
{
	private readonly Player _player;

	public NintendoSwitchVibrationInputUseCase()
	{
		_player = ReInput.players.GetPlayer(0);
	}

	public void Vibrate(float duration = 0.5f, float amplitudeLow = 1f, float frequencyLow = 50f, float amplitudeHigh = 0.5f, float frequencyHigh = 100f)
	{
	}
}
