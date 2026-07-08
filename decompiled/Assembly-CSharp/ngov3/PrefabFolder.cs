using UnityEngine;

namespace ngov3;

public class PrefabFolder
{
	public static T InstantiateTo<T>(MonoBehaviour obj, Transform parent) where T : Component
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		T component = ((Component)Object.Instantiate<MonoBehaviour>(obj)).GetComponent<T>();
		((Component)component).transform.SetParent(parent);
		((Component)component).transform.localPosition = Vector3.zero;
		((Component)component).transform.eulerAngles = Vector3.zero;
		((Component)component).transform.localScale = Vector3.one;
		return component;
	}

	public static T InstantiateTo<T>(MonoBehaviour obj) where T : Component
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		T component = ((Component)Object.Instantiate<MonoBehaviour>(obj)).GetComponent<T>();
		((Component)component).transform.localPosition = Vector3.zero;
		((Component)component).transform.eulerAngles = Vector3.zero;
		((Component)component).transform.localScale = Vector3.one;
		return component;
	}

	public static T InstantiateTo<T>(GameObject obj, Transform parent) where T : Component
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		T component = Object.Instantiate<GameObject>(obj).GetComponent<T>();
		((Component)component).transform.SetParent(parent);
		((Component)component).transform.localPosition = Vector3.zero;
		((Component)component).transform.eulerAngles = Vector3.zero;
		((Component)component).transform.localScale = Vector3.one;
		return component;
	}

	public static GameObject InstantiateTo(GameObject obj, Transform parent)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		GameObject obj2 = Object.Instantiate<GameObject>(obj);
		obj2.transform.SetParent(parent);
		obj2.transform.localPosition = Vector3.zero;
		obj2.transform.eulerAngles = Vector3.zero;
		obj2.transform.localScale = Vector3.one;
		return obj2;
	}

	public static GameObject InstantiateTo(GameObject obj)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		GameObject obj2 = Object.Instantiate<GameObject>(obj);
		obj2.transform.localPosition = Vector3.zero;
		obj2.transform.eulerAngles = Vector3.zero;
		obj2.transform.localScale = Vector3.one;
		return obj2;
	}

	public static T ResourcesLoadInstantiateTo<T>(string path, Transform parent) where T : Component
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		T component = Object.Instantiate<GameObject>((GameObject)Resources.Load(path)).GetComponent<T>();
		((Component)component).transform.SetParent(parent);
		((Component)component).transform.localPosition = Vector3.zero;
		((Component)component).transform.localScale = Vector3.one;
		return component;
	}

	public static GameObject ResourcesLoadInstantiateTo(string path, Transform parent)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		GameObject obj = Object.Instantiate<GameObject>((GameObject)Resources.Load(path));
		obj.transform.SetParent(parent);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		return obj;
	}

	public static GameObject ResourcesLoadInstantiateTo(string path)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		GameObject obj = Object.Instantiate<GameObject>((GameObject)Resources.Load(path));
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		return obj;
	}
}
