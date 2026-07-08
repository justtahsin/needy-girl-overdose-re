using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if ((Object)(object)instance == (Object)null)
			{
				Type typeFromHandle = typeof(T);
				instance = (T)(object)Object.FindObjectOfType(typeFromHandle);
				if ((Object)(object)instance == (Object)null)
				{
					Debug.Log((object)(typeFromHandle?.ToString() + " をアタッチしているGameObjectはありません"));
				}
			}
			return instance;
		}
	}

	protected virtual void Awake()
	{
		CheckInstance();
	}

	protected bool CheckInstance()
	{
		if ((Object)(object)instance == (Object)null)
		{
			instance = (T)(object)((this is T) ? this : null);
			return true;
		}
		if ((Object)(object)Instance == (Object)(object)this)
		{
			return true;
		}
		Object.Destroy((Object)(object)this);
		return false;
	}

	protected virtual void OnDestroy()
	{
		if ((Object)(object)this == (Object)(object)instance)
		{
			instance = default(T);
		}
	}
}
