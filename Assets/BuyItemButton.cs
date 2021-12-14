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
    [Space(10)] 
    [SerializeField] private Button confirmBuyYes;
    [SerializeField] private Button confirmBuyNo;
    [SerializeField] private Button exitPopupBtn;
    [Space(10)]
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
            moneySaverRef.editMoneyCount(-ItemInShopList.currentSelectedItem.ItemInfo.price);
            using (streamWriter = new StreamWriter("Assets/Resources/Currency/MoneyCount.txt")) {
                streamWriter.WriteLine(moneySaverRef.MoneyCount.ToString());
            }
            switch (itemTypeToWrite) {
                case ItemType.OUTFIT:
                    Debug.Log("Bought outfit");
                    using (streamWriter = File.AppendText("Assets/Resources/Equipments/ContainedOutfits.txt")) {
                        streamWriter.WriteLine(ItemInShopList.currentSelectedItem.ItemInfo.name);
                        streamWriter.WriteLine("ItemsInShop/Outfits/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name);
                        streamWriter.WriteLine("Outfit");
                    }
                    Debug.Log("ItemInfo: " + ItemInShopList.currentSelectedItem.ItemInfo.name);
                    InventorySystem.singleton.addItem(ItemInShopList.currentSelectedItem.ItemInfo.sprite, "ItemsInShop/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name,
                        ItemInShopList.currentSelectedItem.ItemInfo.name, ItemType.OUTFIT);
                    break;
                case ItemType.WEAPON:
                    Debug.Log("Bought weapon");
                    using (streamWriter = File.AppendText("Assets/Resources/Equipments/ContainedWeapons.txt")) {
                        streamWriter.WriteLine(ItemInShopList.currentSelectedItem.ItemInfo.name);
                        streamWriter.WriteLine("ItemsInShop/Weapons/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name);
                        streamWriter.WriteLine("Weapon");
                    }
                    Debug.Log("ItemInfo: " + ItemInShopList.currentSelectedItem.ItemInfo.name);
                    InventorySystem.singleton.addItem(ItemInShopList.currentSelectedItem.ItemInfo.sprite, "ItemsInShop/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name, 
                        ItemInShopList.currentSelectedItem.ItemInfo.name, ItemType.WEAPON);
                    break;
                case ItemType.ACCESSORIES:
                    break;
            }
            // InventorySystem.singleton.startupContainments();
            // InventorySystem.singleton.addItem(ItemInShopList.currentSelectedItem.ItemInfo, ItemInShopList.currentSelectedItem.ItemInfo.sprite, "ItemsInShop/" + ItemInShopList.currentSelectedItem.ItemInfo.sprite.name, 
            //     ItemInShopList.currentSelectedItem.ItemInfo.name, ItemType.WEAPON);
            confirmBuyPanelRef.gameObject.SetActive(false);
        });
        confirmBuyNo.onClick.AddListener(delegate {
            confirmBuyPanelRef.gameObject.SetActive(false);
        });

        exitPopupBtn.onClick.AddListener(delegate {
            notEnoughMoneyPanelRef.gameObject.SetActive(false);
        });
        
        eventTrigger = GetComponent<EventTrigger>();
        originalScale = transform.localScale;
        confirmBuyPanelRef.SetActive(false);
        notEnoughMoneyPanelRef.SetActive(false);
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        if (ItemInShopList.currentSelectedItem == null) {
            Debug.Log("No item selected! Can't buy.");
            return;
        }
        if (ItemInShopList.currentSelectedItem.ItemInfo.price <= moneySaverRef.MoneyCount) {
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
