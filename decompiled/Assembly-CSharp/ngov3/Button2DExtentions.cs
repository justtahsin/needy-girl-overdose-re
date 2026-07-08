using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

public static class Button2DExtentions
{
	public static IObservable<Unit> OnClickAsObservable(this Button2D button)
	{
		return button.onClick.AsObservable();
	}

	public static IObservable<PointerEventData> OnPointerClickAsObservable(this Button2D button)
	{
		if (button == null || button.gameObject == null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerClickTrigger>(button.gameObject).OnPointerClickAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerDownAsObservable(this Button2D button)
	{
		if (button == null || button.gameObject == null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerDownTrigger>(button.gameObject).OnPointerDownAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerUpAsObservable(this Button2D button)
	{
		if (button == null || button.gameObject == null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerUpTrigger>(button.gameObject).OnPointerUpAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerEnterAsObservable(this Button2D button)
	{
		if (button == null || button.gameObject == null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerEnterTrigger>(button.gameObject).OnPointerEnterAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerExitAsObservable(this Button2D button)
	{
		if (button == null || button.gameObject == null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerExitTrigger>(button.gameObject).OnPointerExitAsObservable();
	}

	private static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
	{
		T val = gameObject.GetComponent<T>();
		if (val == null)
		{
			val = gameObject.AddComponent<T>();
		}
		return val;
	}
}
