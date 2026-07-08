using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				Type typeFromHandle = typeof(T);
				instance = (T)UnityEngine.Object.FindObjectOfType(typeFromHandle);
				if (instance == null)
				{
					Debug.Log(typeFromHandle?.ToString() + " をアタッチしているGameObjectはありません");
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
		if (instance == null)
		{
			instance = this as T;
			return true;
		}
		if (Instance == this)
		{
			return true;
		}
		UnityEngine.Object.Destroy(this);
		return false;
	}

	protected virtual void OnDestroy()
	{
		if (this == instance)
		{
			instance = null;
		}
	}
}
