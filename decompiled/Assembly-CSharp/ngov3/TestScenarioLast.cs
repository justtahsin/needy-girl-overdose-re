using Cysharp.Threading.Tasks;

namespace ngov3;

public class TestScenarioLast : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		playing.Add(new Playing(isJimaku: true, "プチ裏技紹介しちゃおうかな"));
		playing.Add(new Playing(isJimaku: false, "えっっマジで？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "ワクワクテカテカ"));
		playing.Add(new Playing(isJimaku: false, "裏技なんてあったのか", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "教えてほしーー", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "どうせ何も無いだろ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "めっちゃやり込んでる！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "伝説の木の下であるコマンドを押すと…"));
		playing.Add(new Playing(isJimaku: false, "何なに！？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "知りたいよ〜〜！", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "ドキドキドキ……", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "もったいぶるなカス", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "それ攻略本にも載ってないやつ？", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "親友の妹隠しルートが出るんだよ"));
		playing.Add(new Playing(isJimaku: false, "マ？"));
		playing.Add(new Playing(isJimaku: false, "ほんと！？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "これは良いこと聞いた", StatusType.Tension, 4));
		playing.Add(new Playing(isJimaku: false, "いやお前ら騙されんなよ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "SUGEEEEEEEEEE", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "それは知らなかった", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "親友の妹キメさせてぇ〜〜", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "さすが超てんちゃん！！", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "それじゃ今日はこの辺で！†昇天†"));
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
