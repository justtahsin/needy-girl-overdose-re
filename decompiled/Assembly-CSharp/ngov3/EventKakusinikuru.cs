using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

public class EventKakusinikuru : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	private Vector3 localpos = new Vector3(591f, -228f, 0f);

	[SerializeField]
	private AppType hiderAppType;

	private Sequence move;

	public void OnPointerEnter(PointerEventData eventData)
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.appType == hiderAppType);
		if (window != null && window.windowState != WindowState.minimized)
		{
			RectTransform component = window.UnityGameObject.GetComponent<RectTransform>();
			if (move != null)
			{
				TweenExtensions.Kill((Tween)(object)move, true);
			}
			window.ResetSize();
			move = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)component, 1f, 0.05f)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)component, 591f, 0.05f, true), false)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)component, 852f, 0.05f, true), false)));
		}
	}
}
