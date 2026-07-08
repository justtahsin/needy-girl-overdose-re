using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ngov3;

public class TaskManagerManager : MonoBehaviour
{
	[SerializeField]
	private TMP_Text meate;

	[SerializeField]
	private GraphManager _followerGraph;

	[SerializeField]
	private GraphManager _stressGraph;

	[SerializeField]
	private GraphManager _loveGraph;

	[SerializeField]
	private GraphManager _yamiGraph;

	private void Start()
	{
	}

	public void setMeate(string newAim = "#####")
	{
		meate.DOText(newAim, 0.4f, richTextEnabled: true, ScrambleMode.All).Play();
	}

	public void SetToolTip(bool onoff)
	{
		_followerGraph.SetTooltip(onoff);
		_stressGraph.SetTooltip(onoff);
		_loveGraph.SetTooltip(onoff);
		_yamiGraph.SetTooltip(onoff);
	}

	public void ReadyToOutOfOrder()
	{
		_followerGraph.OnReadyToOutOfOrder();
		_stressGraph.OnReadyToOutOfOrder();
		_loveGraph.OnReadyToOutOfOrder();
		_yamiGraph.OnReadyToOutOfOrder();
	}

	public void GoOutOfOrder()
	{
		_followerGraph.OnGoOutOfOrder();
		_stressGraph.OnGoOutOfOrder();
		_loveGraph.OnGoOutOfOrder();
		_yamiGraph.OnGoOutOfOrder();
	}
}
