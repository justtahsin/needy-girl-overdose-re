using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public static class Button2DExtentions
{
	public static IObservable<Unit> OnClickAsObservable(this Button2D button)
	{
		return UnityEventExtensions.AsObservable((UnityEvent)(object)((Button)button).onClick);
	}

	public static IObservable<PointerEventData> OnPointerClickAsObservable(this Button2D button)
	{
		if ((Object)(object)button == (Object)null || (Object)(object)((Component)button).gameObject == (Object)null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerClickTrigger>(((Component)button).gameObject).OnPointerClickAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerDownAsObservable(this Button2D button)
	{
		if ((Object)(object)button == (Object)null || (Object)(object)((Component)button).gameObject == (Object)null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerDownTrigger>(((Component)button).gameObject).OnPointerDownAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerUpAsObservable(this Button2D button)
	{
		if ((Object)(object)button == (Object)null || (Object)(object)((Component)button).gameObject == (Object)null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerUpTrigger>(((Component)button).gameObject).OnPointerUpAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerEnterAsObservable(this Button2D button)
	{
		if ((Object)(object)button == (Object)null || (Object)(object)((Component)button).gameObject == (Object)null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerEnterTrigger>(((Component)button).gameObject).OnPointerEnterAsObservable();
	}

	public static IObservable<PointerEventData> OnPointerExitAsObservable(this Button2D button)
	{
		if ((Object)(object)button == (Object)null || (Object)(object)((Component)button).gameObject == (Object)null)
		{
			return Observable.Empty<PointerEventData>();
		}
		return GetOrAddComponent<ObservablePointerExitTrigger>(((Component)button).gameObject).OnPointerExitAsObservable();
	}

	private static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
	{
		T val = gameObject.GetComponent<T>();
		if ((Object)(object)val == (Object)null)
		{
			val = gameObject.AddComponent<T>();
		}
		return val;
	}
}
