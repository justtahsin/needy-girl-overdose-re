using UnityEngine;

namespace ngov3;

public class HyporonView : SheetView
{
	[SerializeField]
	private GameObject _hintObj;

	[SerializeField]
	private GameObject _subHintObj;

	protected override void Start()
	{
		base.Start();
	}

	public override void OnDose()
	{
		base.OnDose();
		if (_currentDoseCount.Value == 1 && _hintObj.activeInHierarchy != _subHintObj.activeInHierarchy)
		{
			_subHintObj.SetActive(_hintObj.activeInHierarchy);
		}
	}
}
