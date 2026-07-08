using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class TabletView : MonoBehaviour
{
	[SerializeField]
	private Image _view;

	private BoolReactiveProperty _hasDosed = new BoolReactiveProperty(false);

	public Image View => _view;

	public IReadOnlyReactiveProperty<bool> HasDosed => (IReadOnlyReactiveProperty<bool>)(object)_hasDosed;
}
