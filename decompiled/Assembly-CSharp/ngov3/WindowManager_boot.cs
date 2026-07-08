using UnityEngine;

namespace ngov3;

public class WindowManager_boot : WindowManager
{
	[SerializeField]
	private GameObject controlPanel;

	[SerializeField]
	private GameObject Hint;

	private new void Start()
	{
		Hint.SetActive(value: false);
		controlPanel.SetActive(value: false);
	}

	public Window NewWindow(AppType appType)
	{
		switch (appType)
		{
		case AppType.ControlPanel:
			controlPanel.SetActive(value: true);
			break;
		default:
			NewWindow(appType, true);
			break;
		case AppType.MyPicture:
			break;
		}
		return null;
	}

	public void Close(Window w)
	{
		switch (w.appType)
		{
		case AppType.ControlPanel:
			controlPanel.SetActive(value: false);
			break;
		default:
			Close((IWindow)w);
			break;
		case AppType.MyPicture:
			break;
		}
	}
}
