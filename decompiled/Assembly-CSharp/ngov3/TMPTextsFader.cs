using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ngov3;

public class TMPTextsFader : MonoBehaviour
{
	[SerializeField]
	private List<TMP_Text> _tmpTexts = new List<TMP_Text>();

	[Range(0f, 1f)]
	[SerializeField]
	private float _alpha = 1f;

	public float Alpha
	{
		get
		{
			return _alpha;
		}
		set
		{
			_alpha = value;
			foreach (TMP_Text tmpText in _tmpTexts)
			{
				Color color = tmpText.color;
				color.a = _alpha;
				tmpText.color = color;
			}
		}
	}

	private async UniTask OnChangeAlpha()
	{
		await UniTask.WaitForEndOfFrame();
		foreach (TMP_Text tmpText in _tmpTexts)
		{
			Color color = tmpText.color;
			color.a = _alpha;
			tmpText.color = color;
		}
	}
}
