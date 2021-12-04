using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotItem : MonoBehaviour, EventTriggerSettings.TriggerOnDragDrop, EventTriggerSettings.TriggerOnHover
{
    private EventTrigger _eventTrigger;
    private Vector3 originalPosition;
    public EventTrigger EventTrigger
    {
        get => _eventTrigger;
        set => _eventTrigger = value;
    }

    public void getCalledStart()
    {
        _eventTrigger = gameObject.AddComponent<EventTrigger>();
        var tempPosition = transform.localPosition;
        originalPosition = new Vector3(tempPosition.x, tempPosition.y, tempPosition.z);
    }

    public void onHoverEntry(BaseEventData baseEventData)
    {
        var originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x + .3f, originalScale.y + .3f, originalScale.z);
    }

    public void onExitHoverEntry(BaseEventData baseEventData)
    {
        var originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x - .3f, originalScale.y - .3f, originalScale.z);
    }


    public void onDrag(BaseEventData baseEventData)
    {
        transform.localPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalPosition.z);
    }

    public void onDrop(BaseEventData baseEventData)
    {
        // throw new System.NotImplementedException();
    }
}
