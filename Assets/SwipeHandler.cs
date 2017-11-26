using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeHandler : Selectable, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public float Coefficient;
    Vector2 startPosition;
    Vector2 lastPosition;
    Vector2 changeInThisFrame;

    public float deadZone = 10;
    bool leftDeadZone = false;

    public IceConeController iceCone;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!interactable)
            return;
        leftDeadZone = false;
        startPosition = eventData.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!leftDeadZone && (eventData.position - startPosition).x > deadZone)
        {
            leftDeadZone = true;
        }
        // if (leftDeadZone)
        {
            iceCone.SwipeUpdate(eventData.delta.x);
        }

        lastPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!interactable)
            return;
        if (leftDeadZone)
        {
            iceCone.SwipeDone();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        iceCone.LickTapped(pointerEventData.position);
    }
}
