using Cysharp.Threading.Tasks;

namespace ngov3;

public class TestScenario : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		playing.Add(new Playing(isJimaku: true, "まだこの配信は存在しないよ", StatusType.Follower));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
