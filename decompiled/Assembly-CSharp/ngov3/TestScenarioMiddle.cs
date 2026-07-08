using Cysharp.Threading.Tasks;

namespace ngov3;

public class TestScenarioMiddle : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		playing.Add(new Playing(isJimaku: true, "もっと盛り上げていこう"));
		playing.Add(new Playing(isJimaku: false, "可愛いよ超てんちゃん！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "うおおおおおおおお", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "もっとサービスしろよ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "キメキメ誰派？"));
		playing.Add(new Playing(isJimaku: true, "やっぱ生徒会長ルートだよね"));
		playing.Add(new Playing(isJimaku: false, "すご！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "あの激ムズルート！？"));
		playing.Add(new Playing(isJimaku: false, "超マニアックなのもイイ！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "嘘に決まってんじゃん", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "やるじゃん！"));
		playing.Add(new Playing(isJimaku: false, "え？どんなゲーム？", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "キメキメやってみたい〜"));
		playing.Add(new Playing(isJimaku: false, "生徒会長キメさせるのはやばい", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "後輩ちゃんのストーリーも好きだよ"));
		playing.Add(new Playing(isJimaku: false, "わかる〜〜"));
		playing.Add(new Playing(isJimaku: false, "筋トレの話は？", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "きた！俺の推し！"));
		playing.Add(new Playing(isJimaku: false, "ニワカじゃん", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "漏れは弓道部の先輩派"));
		playing.Add(new Playing(isJimaku: false, "超てんちゃんと趣味合いそう"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.SetScenario<TestScenarioLast>();
		await _Live.NowPlaying.StartScenario();
	}
}
