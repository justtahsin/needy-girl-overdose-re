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
		StartCoroutine(FpsAsync());
	}

	private IEnumerator FpsAsync()
	{
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.S) && Time.timeScale == 1f)
			{
				Time.timeScale = 10f;
			}
			if (Input.GetKeyUp(KeyCode.S) && Time.timeScale == 10f)
			{
				Time.timeScale = 1f;
			}
			yield return null;
		}
	}
}
