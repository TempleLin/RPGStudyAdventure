using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class HoveringEventTrigger
{
    public static void setEventTriggerHoveringScale(EventTrigger eventTrigger, 
        UnityAction<BaseEventData> onHoverCallback, UnityAction<BaseEventData> onExitHoverCallback)
    {
        EventTrigger.Entry onHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerEnter};
        onHoverEntry.callback.AddListener(onHoverCallback);
        eventTrigger.triggers.Add(onHoverEntry);

        EventTrigger.Entry onExitHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerExit};
        onExitHoverEntry.callback.AddListener(onExitHoverCallback);
        eventTrigger.triggers.Add(onExitHoverEntry);
    }
}
