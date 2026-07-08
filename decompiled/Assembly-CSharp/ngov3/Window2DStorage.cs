using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

public class Window2DStorage : MonoBehaviour
{
	[SerializeField]
	private List<Window2D> _preparedWindowInstances = new List<Window2D>();

	private Dictionary<string, Window2D> _preparedWindowDic = new Dictionary<string, Window2D>();

	private void Awake()
	{
		foreach (Window2D preparedWindowInstance in _preparedWindowInstances)
		{
			_preparedWindowDic.Add(preparedWindowInstance.nakamiApp.name, preparedWindowInstance);
		}
	}

	public bool IsTargetWindow(IWindow window)
	{
		if (window.nakamiApp == null)
		{
			return false;
		}
		return _preparedWindowDic.ContainsKey(window.nakamiApp.name);
	}

	public bool IsTargetWindow(AppTypeToData data)
	{
		if (data.InnerContent == null)
		{
			return false;
		}
		return _preparedWindowDic.ContainsKey(data.InnerContent.name);
	}

	public IWindow PickWindowFromStorage(string nakamiAppName)
	{
		Window2D window2D = _preparedWindowDic[nakamiAppName];
		IStorable component = window2D.nakamiApp.GetComponent<IStorable>();
		if (component != null)
		{
			component.OnPicked();
			return window2D;
		}
		return window2D;
	}

	public void StoreWindowInStorage(IWindow window)
	{
		Transform gameObjectTransform = window.GameObjectTransform;
		gameObjectTransform.localPosition = new Vector3(-3000f, 0f, 0f);
		if (gameObjectTransform.localScale.x < 1f)
		{
			gameObjectTransform.localScale = Vector3.one;
		}
		window.nakamiApp.GetComponent<IStorable>()?.OnStored();
	}
}
