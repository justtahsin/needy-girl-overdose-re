using UniRx;

namespace ngov3;

public class PronHorror : SheetView
{
	protected override void Start()
	{
		OnDosed().Subscribe(delegate
		{
			_currentDoseCount.Value++;
		}).AddTo(base.gameObject);
		_currentDoseCount.Subscribe(delegate(int count)
		{
			FetchOverDose(count);
		}).AddTo(base.gameObject);
	}

	private void FetchOverDose(int count)
	{
		if (count > _tekiryou)
		{
			_odButton.gameObject.SetActive(value: true);
		}
	}
}
