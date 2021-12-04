using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class StartMissionInputBtn : MonoBehaviour, HoveringEventTrigger.TriggerOnHover
{
    private EventTrigger _eventTrigger;
    public EventTrigger EventTrigger => _eventTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        HoveringEventTrigger.setEventTriggerHoveringScale(this);
    }

    // Update is called once per frame
    void Update()
    {
        
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
