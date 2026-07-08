using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class ChipGet_Imbouron_6 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Awake);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE005);
		PostEffectManager.Instance.SetShader(EffectType.Kakusei);
		PostEffectManager.Instance.SetShaderWeight(0.2f);
		await NgoEvent.DelaySkippable(Constants.FAST);
		PostEffectManager.Instance.SetShaderWeight(1f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE009);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_gedatsu_LINE010);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Scenario_gedatsu_Tweet001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<EventManager>.Instance.isGedatsu = true;
		await NgoEvent.DelaySkippable(Constants.SLOW);
		endEvent();
	}
}
