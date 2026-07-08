using System;
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
		_shortcut = ((Component)this).GetComponent<Button>();
		if (appType != AppType.None)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_shortcut), (Action<Unit>)delegate
			{
				windowManager.NewWindow(appType);
			}), (Component)(object)_shortcut);
		}
	}
}
