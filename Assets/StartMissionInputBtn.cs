using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class StartMissionInputBtn : MonoBehaviour, EventTriggerSettings.TriggerOnHover
{
    private EventTrigger _eventTrigger;
    public EventTrigger EventTrigger
    {
        get => _eventTrigger;
        set => _eventTrigger = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        EventTriggerSettings.setEventTriggerHoveringScale(this);
    }

    public void onHoverEntry(BaseEventData baseEventData)
    {
        Debug.Log("OnHoverStartMissionInputBtn");
    }

    public void onExitHoverEntry(BaseEventData baseEventData)
    {
        Debug.Log("OnHoverExitStartMissionInputBtn");
    }
}
