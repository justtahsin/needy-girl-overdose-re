using UnityEngine;

namespace Extensions;

public static class ComponentExtensions
{
	public static T AddComponent<T>(this Component component) where T : Component
	{
		return component.gameObject.AddComponent<T>();
	}

	public static T GetOrAddComponent<T>(this Component component) where T : Component
	{
		return component.GetComponent<T>() ?? component.AddComponent<T>();
	}

	public static bool HasComponent<T>(this Component component) where T : Component
	{
		return (Object)(object)component.GetComponent<T>() != (Object)null;
	}
}
