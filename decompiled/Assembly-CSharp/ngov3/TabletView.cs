using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class TabletView : MonoBehaviour
{
	[SerializeField]
	private Image _view;

	private BoolReactiveProperty _hasDosed = new BoolReactiveProperty(initialValue: false);

	public Image View => _view;

	public IReadOnlyReactiveProperty<bool> HasDosed => _hasDosed;
}
