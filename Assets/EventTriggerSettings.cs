using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class EventTriggerSettings
{
    public interface TriggerOnHover
    {
        public EventTrigger @EventTrigger { get; }
        public void onHoverEntry(BaseEventData baseEventData);
        public void onExitHoverEntry(BaseEventData baseEventData);
    }
    public static void setEventTriggerHoveringScale(TriggerOnHover triggerOnHover)
    {
        EventTrigger.Entry onHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerEnter};
        onHoverEntry.callback.AddListener(triggerOnHover.onHoverEntry);
        triggerOnHover.EventTrigger.triggers.Add(onHoverEntry);

        EventTrigger.Entry onExitHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerExit};
        onExitHoverEntry.callback.AddListener(triggerOnHover.onExitHoverEntry);
        triggerOnHover.EventTrigger.triggers.Add(onExitHoverEntry);
    }
}
