using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Shortcut_boot : MonoBehaviour
{
	protected Button _shortcut;

	public AppType appType;

	[SerializeField]
	private WindowManager windowManager;

	public void Awake()
	{
		_shortcut = GetComponent<Button>();
		if (appType != AppType.None)
		{
			_shortcut.OnClickAsObservable().Subscribe(delegate
			{
				windowManager.NewWindow(appType);
			}).AddTo(_shortcut);
		}
	}
}
