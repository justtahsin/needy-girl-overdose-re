using UnityEngine;

namespace Extensions;

public static class GameObjectExtensions
{
	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
	}

	public static bool HasComponent<T>(this GameObject gameObject) where T : Component
	{
		return (Object)(object)gameObject.GetComponent<T>() != (Object)null;
	}
}
