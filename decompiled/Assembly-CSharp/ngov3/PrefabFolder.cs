using UnityEngine;

namespace ngov3;

public class PrefabFolder
{
	public static T InstantiateTo<T>(MonoBehaviour obj, Transform parent) where T : Component
	{
		T component = Object.Instantiate(obj).GetComponent<T>();
		component.transform.SetParent(parent);
		component.transform.localPosition = Vector3.zero;
		component.transform.eulerAngles = Vector3.zero;
		component.transform.localScale = Vector3.one;
		return component;
	}

	public static T InstantiateTo<T>(MonoBehaviour obj) where T : Component
	{
		T component = Object.Instantiate(obj).GetComponent<T>();
		component.transform.localPosition = Vector3.zero;
		component.transform.eulerAngles = Vector3.zero;
		component.transform.localScale = Vector3.one;
		return component;
	}

	public static T InstantiateTo<T>(GameObject obj, Transform parent) where T : Component
	{
		T component = Object.Instantiate(obj).GetComponent<T>();
		component.transform.SetParent(parent);
		component.transform.localPosition = Vector3.zero;
		component.transform.eulerAngles = Vector3.zero;
		component.transform.localScale = Vector3.one;
		return component;
	}

	public static GameObject InstantiateTo(GameObject obj, Transform parent)
	{
		GameObject gameObject = Object.Instantiate(obj);
		gameObject.transform.SetParent(parent);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.eulerAngles = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	public static GameObject InstantiateTo(GameObject obj)
	{
		GameObject gameObject = Object.Instantiate(obj);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.eulerAngles = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	public static T ResourcesLoadInstantiateTo<T>(string path, Transform parent) where T : Component
	{
		T component = Object.Instantiate((GameObject)Resources.Load(path)).GetComponent<T>();
		component.transform.SetParent(parent);
		component.transform.localPosition = Vector3.zero;
		component.transform.localScale = Vector3.one;
		return component;
	}

	public static GameObject ResourcesLoadInstantiateTo(string path, Transform parent)
	{
		GameObject gameObject = Object.Instantiate((GameObject)Resources.Load(path));
		gameObject.transform.SetParent(parent);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	public static GameObject ResourcesLoadInstantiateTo(string path)
	{
		GameObject gameObject = Object.Instantiate((GameObject)Resources.Load(path));
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}
}
