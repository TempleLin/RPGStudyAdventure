using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class BuyItemButton : MonoBehaviour, EventTriggerSettings.TriggerOnClick, 
    EventTriggerSettings.TriggerOnHover
{
    [SerializeField] private MoneySaver moneySaverRef;
    [SerializeField] private GameObject confirmBuyPanelRef;
    [SerializeField] private GameObject notEnoughMoneyPanelRef;
    [Space(10)] [SerializeField] private Button confirmBuyYes;
    [SerializeField] private TextAsset containedWeaponsRef;
    [SerializeField] private TextAsset containedOutfitsRef;
    [SerializeField] private TextAsset containedAccessoriesRef;
    private StreamWriter streamWriter;
    
    private EventTrigger eventTrigger;
    public EventTrigger EventTrigger { get => eventTrigger; set => eventTrigger = value; }
    private Vector3 originalScale;

    private ItemType itemTypeToWrite;
    
    private void Start()
    {
        confirmBuyYes.onClick.AddListener(delegate {
            switch (itemTypeToWrite) {
                case ItemType.OUTFIT:
                    break;
                case ItemType.WEAPON:
                    using (streamWriter = File.AppendText("Assets/Resources/Equipments/ContainedWeapons.txt")) { 
                        streamWriter.WriteLine(ItemInShopList.currentSelectedItem.ItemInfo.name);
                        streamWriter.WriteLine("Resources/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name);
                        streamWriter.WriteLine("Weapon");
                    }
                    break;
                case ItemType.ACCESSORIES:
                    break;
            }
            confirmBuyPanelRef.gameObject.SetActive(false);
        });
        
        eventTrigger = GetComponent<EventTrigger>();
        originalScale = transform.localScale;
        confirmBuyPanelRef.SetActive(false);
        notEnoughMoneyPanelRef.SetActive(false);
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        if (ItemInShopList.currentSelectedItem.ItemInfo.price <= moneySaverRef.moneyCount) {
            confirmBuyPanelRef.SetActive(true);
        } else {
            notEnoughMoneyPanelRef.SetActive(true);
        }
    }

    void EventTriggerSettings.TriggerOnHover.onHoverEntry(BaseEventData baseEventData) {
        transform.localScale = new Vector3(originalScale.x + .3f, originalScale.y + .3f, originalScale.z);
    }

    void EventTriggerSettings.TriggerOnHover.onExitHoverEntry(BaseEventData baseEventData) {
        transform.localScale = originalScale;
    }
}
