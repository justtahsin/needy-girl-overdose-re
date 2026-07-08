using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace ngov3;

public static class WindowTweens
{
	public static Sequence minimize(this RectTransform ui)
	{
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)ui, 0.1f, 0.2f)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ui, -1500f, 0.2f, true))));
	}

	public static Sequence maximize(this RectTransform ui)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOSizeDelta(ui, new Vector2(1440f, 1030f), 0.2f, true)), (Tween)(object)ShortcutExtensions.DOLocalMove((Transform)(object)ui, new Vector3(0f, 1080f, ((Transform)ui).localPosition.z), 0.2f, true)));
	}

	public static Sequence maximizeWindow2D(this RectTransform ui)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOSizeDelta(ui, new Vector2(1440f, 1030f), 0.2f, true)), (Tween)(object)ShortcutExtensions.DOLocalMoveX((Transform)(object)ui, 0f, 0.2f, true)), (Tween)(object)ShortcutExtensions.DOLocalMoveY((Transform)(object)ui, 0f, 0.2f, true)));
	}

	public static Sequence maximizeLiveGen(this RectTransform ui)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOSizeDelta(ui, new Vector2(1440f, 1130f), 0.2f, true)), (Tween)(object)ShortcutExtensions.DOLocalMove((Transform)(object)ui, new Vector3(0f, 1080f, ((Transform)ui).localPosition.z), 0.2f, true)));
	}

	public static Sequence pop(this RectTransform ui)
	{
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.Join(DOTween.Sequence(), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)ui, 1f, 0.2f)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ui, 1500f, 0.2f, true))));
	}

	public static Sequence born(this RectTransform ui)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Join(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			((Transform)ui).localScale = new Vector3(0f, 0f, 1f);
		}), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)ui, 1f, 0.1f)));
	}
}
