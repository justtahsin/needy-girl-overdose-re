using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
		TweenExtensions.Play<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(meate, newAim, 0.4f, true, (ScrambleMode)1, (string)null));
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
