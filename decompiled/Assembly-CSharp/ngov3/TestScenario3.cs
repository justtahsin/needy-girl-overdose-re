using Cysharp.Threading.Tasks;

namespace ngov3;

public class TestScenario3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		playing.Add(new Playing(isJimaku: true, "ジェルばんは..."));
		playing.Add(new Playing(isJimaku: false, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "ジェルばん〜", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "どうしたの？"));
		playing.Add(new Playing(isJimaku: false, "元気無いね", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "闇闇闇闇闇誰もみるな闇病み"));
		playing.Add(new Playing(isJimaku: false, "何があったの！？"));
		playing.Add(new Playing(isJimaku: false, "それでも顔は良い"));
		playing.Add(new Playing(isJimaku: false, "可哀想な天使様。。"));
		playing.Add(new Playing(isJimaku: false, "かまってちゃんだな", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "泣きそう"));
		playing.Add(new Playing(isJimaku: false, "慰めてあげたい"));
		playing.Add(new Playing(isJimaku: false, "可哀想で泣けてきた"));
		playing.Add(new Playing(isJimaku: false, "どうせ嘘", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "病んでも顔良すぎない？"));
		playing.Add(new Playing(isJimaku: false, "堕天使じゃん"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: true, "みるなみるなみるなみるなみるな"));
		playing.Add(new Playing(isJimaku: false, "そんなこと言わないで", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "筋トレしよう", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "降臨してくれてありがとう！！"));
		playing.Add(new Playing(isJimaku: false, "どこまでもついていくよ"));
		playing.Add(new Playing(isJimaku: false, "涙で画面見えない"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "キモ。コミュ抜けるわ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "私も生きるから頑張ろう；；"));
		playing.Add(new Playing(isJimaku: true, "堕天するわ……†昇天†"));
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
