using DG.Tweening;
using UnityEngine;

namespace ngov3;

public static class WindowTweens
{
	public static Sequence minimize(this RectTransform ui)
	{
		return DOTween.Sequence().Join(ui.DOScale(0.1f, 0.2f)).Join(ui.DOLocalMoveY(-1500f, 0.2f, snapping: true).SetRelative())
			.Play();
	}

	public static Sequence maximize(this RectTransform ui)
	{
		return DOTween.Sequence().Join(ui.DOSizeDelta(new Vector2(1440f, 1030f), 0.2f, snapping: true)).Join(ui.DOLocalMove(new Vector3(0f, 1080f, ui.localPosition.z), 0.2f, snapping: true))
			.Play();
	}

	public static Sequence maximizeWindow2D(this RectTransform ui)
	{
		return DOTween.Sequence().Join(ui.DOSizeDelta(new Vector2(1440f, 1030f), 0.2f, snapping: true)).Join(ui.DOLocalMoveX(0f, 0.2f, snapping: true))
			.Join(ui.DOLocalMoveY(0f, 0.2f, snapping: true))
			.Play();
	}

	public static Sequence maximizeLiveGen(this RectTransform ui)
	{
		return DOTween.Sequence().Join(ui.DOSizeDelta(new Vector2(1440f, 1130f), 0.2f, snapping: true)).Join(ui.DOLocalMove(new Vector3(0f, 1080f, ui.localPosition.z), 0.2f, snapping: true))
			.Play();
	}

	public static Sequence pop(this RectTransform ui)
	{
		return DOTween.Sequence().Join(ui.DOScale(1f, 0.2f)).Join(ui.DOLocalMoveY(1500f, 0.2f, snapping: true).SetRelative())
			.Play();
	}

	public static Sequence born(this RectTransform ui)
	{
		return DOTween.Sequence().OnStart(delegate
		{
			ui.localScale = new Vector3(0f, 0f, 1f);
		}).Join(ui.DOScale(1f, 0.1f))
			.Play();
	}
}
