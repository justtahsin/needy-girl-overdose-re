using UnityEngine;
using UnityEngine.UI;

namespace ngov3.demo;

public class DemoAnimationKeyItem : MonoBehaviour
{
	[SerializeField]
	private Text text;

	public void Initialize(AnimationKeyVO vo)
	{
		text.text = vo.Id;
	}

	private void Start()
	{
	}
}
