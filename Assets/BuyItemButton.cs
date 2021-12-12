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
    [Space(10)] [SerializeField] private Button confirmBuyButtom;
    [SerializeField] private TextAsset containedWeaponsRef;
    [SerializeField] private TextAsset containedOutfitsRef;
    [SerializeField] private TextAsset containedAccessoriesRef;
    private StreamWriter streamWriter;
    
    private EventTrigger eventTrigger;
    public EventTrigger EventTrigger { get => eventTrigger; set => eventTrigger = value; }
    private Vector3 originalScale;

    private bool writeToWeaponTxt = false, writeToOutfitTxt = false, writeToAccessoryTxt = false;
    private void Start()
    {
        // weaponsWriter = new StreamWriter("Assets/Resources/Equipments/ContainedWeapons.txt");
        // outfitsWriter = new StreamWriter("Assets/Resources/Equipments/ContainedOutfits.txt");
        // accessoriesWriter = new StreamWriter("Assets/Resources/Equipments/ContainedAccessories.txt");
        
        confirmBuyButtom.onClick.AddListener(delegate {
            if (writeToWeaponTxt) {
                using (streamWriter = File.AppendText("Assets/Resources/Equipments/ContainedWeapons.txt")) {
                    streamWriter.WriteLine(ItemInShopList.currentSelectedWeapon.ItemInfo.name);
                    streamWriter.WriteLine("Resources/" + ItemInShopList.currentSelectedWeapon.ItemInfo.sprite.name);
                    streamWriter.Write("Weapon");
                }
            }
            confirmBuyPanelRef.gameObject.SetActive(false);
        });
        
        eventTrigger = GetComponent<EventTrigger>();
        originalScale = transform.localScale;
        confirmBuyPanelRef.SetActive(false);
        notEnoughMoneyPanelRef.SetActive(false);
    }

    void EventTriggerSettings.TriggerOnClick.onClick(BaseEventData baseEventData) {
        int totalPrice = 0;
        if (ItemInShopList.currentSelectedWeapon != null) {
            totalPrice += ItemInShopList.currentSelectedWeapon.ItemInfo.price;
            writeToWeaponTxt = true;
        } else {
            writeToWeaponTxt = false;
        }

        if (ItemInShopList.currentSelectedOutfit != null) {
            totalPrice += ItemInShopList.currentSelectedOutfit.ItemInfo.price;
            writeToOutfitTxt = true;
        } else {
            writeToOutfitTxt = false;
        }

        if (ItemInShopList.currentSelectedAccessory != null) {
            totalPrice += ItemInShopList.currentSelectedOutfit.ItemInfo.price;
            writeToOutfitTxt = true;
        } else {
            writeToAccessoryTxt = false;
        }
        
        if (totalPrice <= moneySaverRef.moneyCount) {
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
