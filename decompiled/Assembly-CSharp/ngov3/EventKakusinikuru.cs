using System.Linq;
using DG.Tweening;
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
				move.Kill(complete: true);
			}
			window.ResetSize();
			move = DOTween.Sequence().Join(component.DOScale(1f, 0.05f)).Join(component.DOLocalMoveX(591f, 0.05f, snapping: true).SetRelative(isRelative: false))
				.Join(component.DOLocalMoveY(852f, 0.05f, snapping: true).SetRelative(isRelative: false))
				.Play();
		}
	}
}
