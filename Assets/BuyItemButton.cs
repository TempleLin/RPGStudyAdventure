using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class BuyItemButton : MonoBehaviour, EventTriggerSettings.TriggerOnClick
{
    private EventTrigger eventTrigger;
    public EventTrigger EventTrigger { get => eventTrigger; set => eventTrigger = value; }

    private void Start() {
        eventTrigger = GetComponent<EventTrigger>();
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        Debug.Log("OnClick buy item.");
    }
}
