using System.Collections;
using UnityEngine;

namespace ngov3;

public sealed class DebugUtilities : MonoBehaviour
{
	private void Start()
	{
		Initialize();
	}

	public async void Initialize()
	{
		((MonoBehaviour)this).StartCoroutine(FpsAsync());
	}

	private IEnumerator FpsAsync()
	{
		while (true)
		{
			if (Input.GetKeyDown((KeyCode)115) && Time.timeScale == 1f)
			{
				Time.timeScale = 10f;
			}
			if (Input.GetKeyUp((KeyCode)115) && Time.timeScale == 10f)
			{
				Time.timeScale = 1f;
			}
			yield return null;
		}
	}
}
