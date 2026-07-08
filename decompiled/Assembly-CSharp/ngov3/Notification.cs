using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
		TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX(((Component)button).transform, -320f, 0.1f, true), (Ease)6)));
		SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.3f, 0.5f, 50f, 0.3f);
	}

	private Sprite GetAppIcon(AppType app)
	{
		return LoadAppData.ReadAppContent(app).appIcon;
	}
}
