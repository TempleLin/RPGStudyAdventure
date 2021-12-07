using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class EventTriggerSettings {
    public interface TriggerOnHover {
        public EventTrigger @EventTrigger { get; set; }
        public void onHoverEntry(BaseEventData baseEventData);
        public void onExitHoverEntry(BaseEventData baseEventData);
    }

    public interface TriggerOnDragDrop {
        public EventTrigger EventTrigger { get; set; }
        public void onDrag(BaseEventData baseEventData);
        public void onDrop(BaseEventData baseEventData);
    }

    public interface TriggerOnClick {
        public EventTrigger @EventTrigger { get; set; }
        public void onClick(BaseEventData baseEventData);
    }

    public static void setEventTriggerHoveringScale(TriggerOnHover triggerOnHover) {
        EventTrigger.Entry onHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerEnter};
        onHoverEntry.callback.AddListener(triggerOnHover.onHoverEntry);
        triggerOnHover.EventTrigger.triggers.Add(onHoverEntry);

        EventTrigger.Entry onExitHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerExit};
        onExitHoverEntry.callback.AddListener(triggerOnHover.onExitHoverEntry);
        triggerOnHover.EventTrigger.triggers.Add(onExitHoverEntry);
    }

    public static void setEventTriggerDragDrop(TriggerOnDragDrop triggerOnDragDrop) {
        EventTrigger.Entry onDrag = new EventTrigger.Entry {eventID = EventTriggerType.Drag};
        onDrag.callback.AddListener(triggerOnDragDrop.onDrag);
        triggerOnDragDrop.EventTrigger.triggers.Add(onDrag);
        
        EventTrigger.Entry onDrop = new EventTrigger.Entry {eventID = EventTriggerType.EndDrag};
        onDrop.callback.AddListener(triggerOnDragDrop.onDrop);
        triggerOnDragDrop.EventTrigger.triggers.Add(onDrop);
    }

    public static void setEventTriggerOnClick(TriggerOnClick triggerOnClick) {
        EventTrigger.Entry onClick = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
        onClick.callback.AddListener(triggerOnClick.onClick);
        triggerOnClick.EventTrigger.triggers.Add(onClick);
    }
}
