using UnityEngine;

namespace ngov3;

public class YakujoView : MonoBehaviour
{
	[SerializeField]
	private GameObject _puron;

	[SerializeField]
	private GameObject _hypron;

	[SerializeField]
	private GameObject _happa;

	[SerializeField]
	private GameObject _psyche;

	private void Awake()
	{
	}

	public void setYamiRank(int yami, int yamiMax)
	{
		if (yami >= 20)
		{
			_puron.SetActive(true);
		}
		if (yami >= 40)
		{
			_hypron.SetActive(true);
		}
		if (yami >= 60)
		{
			_happa.SetActive(true);
		}
		if (yami >= 80)
		{
			_psyche.SetActive(true);
		}
	}
}
