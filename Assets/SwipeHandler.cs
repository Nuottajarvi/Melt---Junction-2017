using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeHandler : Selectable, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 start;
    Vector2 changeInThisFrame;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!interactable)
            return;
        start = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        changeInThisFrame = eventData.position - start;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!interactable)
            return;
		
    }
}
