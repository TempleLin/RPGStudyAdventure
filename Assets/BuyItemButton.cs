using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class BuyItemButton : MonoBehaviour, EventTriggerSettings.TriggerOnClick, 
    EventTriggerSettings.TriggerOnHover
{
    [SerializeField] private MoneySaver moneySaverRef;
    [SerializeField] private GameObject confirmBuyPanelRef;
    // [SerializeField] private GameObject notEnoughMoneyPanelRef;
    
    private EventTrigger eventTrigger;
    public EventTrigger EventTrigger { get => eventTrigger; set => eventTrigger = value; }
    private Vector3 originalScale;

    private void Start() {
        eventTrigger = GetComponent<EventTrigger>();
        originalScale = transform.localScale;
        confirmBuyPanelRef.SetActive(false);
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        if (ItemInShopList.currentSelectedWeapon.ItemInfo.price <= moneySaverRef.moneyCount) {
            confirmBuyPanelRef.SetActive(true);
        }
    }

    void EventTriggerSettings.TriggerOnHover.onHoverEntry(BaseEventData baseEventData) {
        transform.localScale = new Vector3(originalScale.x + .3f, originalScale.y + .3f, originalScale.z);
    }

    void EventTriggerSettings.TriggerOnHover.onExitHoverEntry(BaseEventData baseEventData) {
        transform.localScale = originalScale;
    }
}
