using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotItem : MonoBehaviour, EventTriggerSettings.TriggerOnDragDrop, EventTriggerSettings.TriggerOnHover {
    private EventTrigger _eventTrigger;
    private Vector3 originalPosition;
    private RectTransform _rectTransform;
    public EventTrigger EventTrigger {
        get => _eventTrigger;
        set => _eventTrigger = value;
    }

    public void getCalledStart() {
        _eventTrigger = gameObject.AddComponent<EventTrigger>();
        var tempPosition = transform.localPosition;
        _rectTransform = gameObject.GetComponent<RectTransform>();
        originalPosition = _rectTransform.localPosition;
    }

    public void onHoverEntry(BaseEventData baseEventData) {
        var originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x + .3f, originalScale.y + .3f, originalScale.z);
    }

    public void onExitHoverEntry(BaseEventData baseEventData) {
        var originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x - .3f, originalScale.y - .3f, originalScale.z);
    }


    public void onDrag(BaseEventData baseEventData) {
        _rectTransform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalPosition.z);
    }

    public void onDrop(BaseEventData baseEventData) {
        _rectTransform.localPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
    }
}
