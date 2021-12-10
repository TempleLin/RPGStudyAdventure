using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class BuyItemButton : MonoBehaviour, EventTriggerSettings.TriggerOnClick, 
    EventTriggerSettings.TriggerOnHover
{
    private EventTrigger eventTrigger;
    public EventTrigger EventTrigger { get => eventTrigger; set => eventTrigger = value; }
    private Vector3 originalScale;

    private void Start() {
        eventTrigger = GetComponent<EventTrigger>();
        originalScale = transform.localScale;
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        Debug.Log("OnClick buy item.");
    }

    void EventTriggerSettings.TriggerOnHover.onHoverEntry(BaseEventData baseEventData) {
        transform.localScale = new Vector3(originalScale.x + .3f, originalScale.y + .3f, originalScale.z);
    }

    void EventTriggerSettings.TriggerOnHover.onExitHoverEntry(BaseEventData baseEventData) {
        transform.localScale = originalScale;
    }
}
