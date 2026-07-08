using UnityEngine;
using UnityEngine.Events;

namespace ngov3;

public class ChachedWindowObject : MonoBehaviour, IOpenable, IClosable
{
	[SerializeField]
	private bool isOpend;

	[SerializeField]
	private Window_Compact window;

	[SerializeField]
	private AppType appType;

	[SerializeField]
	private UnityEvent<int> numberEvent;

	public bool IsOpend => isOpend;

	public void ExecNumberEvent(int num)
	{
		numberEvent.Invoke(num);
	}

	public void Close()
	{
		window.Close();
		((Component)this).gameObject.SetActive(false);
		isOpend = false;
	}

	public void Open()
	{
		((Component)this).gameObject.SetActive(true);
		window.Open();
		window.SetCachedApp(LoadAppData.ReadAppContent(appType));
		window.OnLanguageUpdated();
		SingletonMonoBehaviour<WindowManager>.Instance.RegistPresetWindow(window);
		isOpend = true;
	}
}
