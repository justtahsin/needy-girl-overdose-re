using Cysharp.Threading.Tasks;

namespace ngov3;

public class Ending_Meta_haishin : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		title = "Ending_Meta_Haisin_Title001";
		title = NgoEx.TenTalk("Ending_Meta_Haisin_Title001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Meta_Comment001", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Meta_Comment002", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Meta_Comment003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Meta_Comment004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Meta_Comment005", _lang)));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
	}
}
