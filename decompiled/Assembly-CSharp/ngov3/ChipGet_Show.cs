using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace ngov3;

public class ChipGet_Show : NgoEvent
{
	private ChipGetCover _chipGet;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<NetaManager>.Instance.ShowingGettingChip(SingletonMonoBehaviour<EventManager>.Instance.gotChipAlpha.alphaType, SingletonMonoBehaviour<EventManager>.Instance.gotChipAlpha.level);
		SingletonMonoBehaviour<EventManager>.Instance.chipget.isGetting.Where((bool v) => !v).Take(1).Subscribe(delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.isChipGetting.Value = false;
			endEvent();
		})
			.AddTo(compositeDisposable);
	}
}
