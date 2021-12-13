using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class EquipmentSelectionBlock : MonoBehaviour, EventTriggerSettings.TriggerOnHover,
    EventTriggerSettings.TriggerOnClick
{
    private ItemInShopList itemInShopListRef;
    private EventTrigger eventTrigger;
    public EventTrigger @EventTrigger { get => eventTrigger; set => eventTrigger = value; }

    private Vector3 originalScale;

    [SerializeField]
    private Image mainCharWeaponEquipmentImg;

    void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();
        itemInShopListRef = transform.GetChild(0).GetComponent<ItemInShopList>();
        EventTriggerSettings.setEventTriggerHoveringScale(this);
        EventTriggerSettings.setEventTriggerOnClick(this);
        originalScale = transform.localScale;

        mainCharWeaponEquipmentImg = itemInShopListRef.ItemInfo.spriteHolderObject.GetComponent<Image>();
        Debug.Log(mainCharWeaponEquipmentImg);
    }

    void EventTriggerSettings.TriggerOnHover.onHoverEntry(BaseEventData baseEventData) {
        transform.localScale = new Vector3(originalScale.x + .1f, originalScale.y + .1f, originalScale.z);
    }

    void EventTriggerSettings.TriggerOnHover.onExitHoverEntry(BaseEventData baseEventData) {
        transform.localScale = originalScale;
    }

    public void onClick(BaseEventData baseEventData) {
        if (ItemInShopList.currentSelectedItem == itemInShopListRef) {
            ItemInShopList.currentSelectedItem = null;
            Debug.Log("Removed equipment from selection.");
            return;
        }
        ItemInShopList.currentSelectedItem = itemInShopListRef;
        mainCharWeaponEquipmentImg.sprite = itemInShopListRef.ItemInfo.sprite;
        mainCharWeaponEquipmentImg.color = Color.white;
        Debug.Log("Saved equipment to currentSelectionItem.");
    }
}
