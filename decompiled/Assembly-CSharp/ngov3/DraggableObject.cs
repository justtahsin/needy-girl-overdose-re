using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggableObject : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
{
	private Subject<PointerEventData> onBeginDragAsObservableSubject = new Subject<PointerEventData>();

	private Subject<PointerEventData> onDragAsObservableSubject = new Subject<PointerEventData>();

	private Subject<PointerEventData> onEndDragAsObservableSubject = new Subject<PointerEventData>();

	public IObservable<PointerEventData> OnBeginDragAsObservable2D => onBeginDragAsObservableSubject;

	public IObservable<PointerEventData> OnDragAsObservable2D => onDragAsObservableSubject;

	public IObservable<PointerEventData> OnEndDragAsObservable2D => onEndDragAsObservableSubject;

	public void OnBeginDrag(PointerEventData eventData)
	{
		onBeginDragAsObservableSubject.OnNext(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		onDragAsObservableSubject.OnNext(eventData);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		onEndDragAsObservableSubject.OnNext(eventData);
	}
}
