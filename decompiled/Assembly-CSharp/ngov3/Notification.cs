using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Notification : MonoBehaviour
{
	public delegate void ClickedAction();

	[SerializeField]
	private TMP_Text nakami;

	[SerializeField]
	private Image icon;

	[SerializeField]
	public Button button;

	private const float NOTIFICATIONWIDTH = 320f;

	public AppType app;

	public ClickedAction clickedAction;

	public void SetData(AppType app, string nakami)
	{
		this.app = app;
		icon.sprite = GetAppIcon(app);
		nakami = nakami.Replace("\r", "\n");
		this.nakami.text = nakami;
	}

	public void Show()
	{
		button.transform.DOLocalMoveX(-320f, 0.1f, snapping: true).SetEase(Ease.OutQuad).SetRelative()
			.Play();
		SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.3f, 0.5f, 50f, 0.3f);
	}

	private Sprite GetAppIcon(AppType app)
	{
		return LoadAppData.ReadAppContent(app).appIcon;
	}
}
