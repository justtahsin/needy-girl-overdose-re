using Cysharp.Threading.Tasks;

namespace ngov3;

public class TestScenario2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		playing.Add(new Playing(isJimaku: true, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "初見です", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "かわいい"));
		playing.Add(new Playing(isJimaku: false, "良い感じじゃん", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "今日はいつもより一段と超絶可愛いでしょ？でしょ？？"));
		playing.Add(new Playing(isJimaku: false, "待ってたよ！"));
		playing.Add(new Playing(isJimaku: false, "今日も顔が良い"));
		playing.Add(new Playing(isJimaku: false, "私の天使さま。。。"));
		playing.Add(new Playing(isJimaku: false, "は？なんて？", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "いい感じ〜〜"));
		playing.Add(new Playing(isJimaku: false, "こんな可愛い顔初めて…"));
		playing.Add(new Playing(isJimaku: false, "感動で泣けてきた"));
		playing.Add(new Playing(isJimaku: false, "どうせ整形", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "顔良すぎない？"));
		playing.Add(new Playing(isJimaku: false, "ガチの天使じゃん"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: true, "今日もあたいの顔面でゆっくりしていってね"));
		playing.Add(new Playing(isJimaku: false, "1日の疲れが吹っ飛んだ", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "そうだね、筋肉だね", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "降臨してくれてありがとう！！"));
		playing.Add(new Playing(isJimaku: false, "どこまでもついていくよ"));
		playing.Add(new Playing(isJimaku: false, "まぶしくて画面見えない"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "ぶっさコミュ抜けるわ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "生きててくれてありがとう；；私も生きるね"));
		playing.Add(new Playing(isJimaku: true, "今日もありがと！†昇天†"));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
