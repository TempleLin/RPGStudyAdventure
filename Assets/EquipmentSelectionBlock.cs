using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class EquipmentSelectionBlock : MonoBehaviour, EventTriggerSettings.TriggerOnHover,
    EventTriggerSettings.TriggerOnClick
{
    private ItemInShopList itemInShopListRef;
    private EventTrigger eventTrigger;
    public EventTrigger @EventTrigger { get => eventTrigger; set => eventTrigger = value; }

    private Vector3 originalScale;

    void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();
        itemInShopListRef = transform.GetChild(0).GetComponent<ItemInShopList>();
        EventTriggerSettings.setEventTriggerHoveringScale(this);
        EventTriggerSettings.setEventTriggerOnClick(this);
        originalScale = transform.localScale;
    }

    void EventTriggerSettings.TriggerOnHover.onHoverEntry(BaseEventData baseEventData) {
        transform.localScale = new Vector3(originalScale.x + .1f, originalScale.y + .1f, originalScale.z);
    }

    void EventTriggerSettings.TriggerOnHover.onExitHoverEntry(BaseEventData baseEventData) {
        transform.localScale = originalScale;
    }

    public void onClick(BaseEventData baseEventData) {
        switch (itemInShopListRef.ItemInfo.itemType) {
            case ItemType.OUTFIT:
                break;
            case ItemType.WEAPON:
                if (itemInShopListRef.CurrentSelectedWeapon == itemInShopListRef)
                {
                    itemInShopListRef.CurrentSelectedWeapon = null;
                    Debug.Log("Removed equipment from selection.");
                    return;
                }
                itemInShopListRef.CurrentSelectedWeapon = itemInShopListRef;
                Debug.Log("Saved equipment to currentSelectionWeapon.");
                break;
            case ItemType.ACCESSORIES:
                break;
        }
    }
}
