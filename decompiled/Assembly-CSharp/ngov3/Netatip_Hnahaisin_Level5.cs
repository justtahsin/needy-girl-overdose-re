using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Hnahaisin_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = "そういう動画に出演するよ";
		playing.Add(new Playing("first"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
