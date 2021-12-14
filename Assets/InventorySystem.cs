using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot {
    public GameObject _gameObject;
    public Text textHolder;
    public string path;
    public ItemInfo itemInfo;
}
public class InventorySystem : MonoBehaviour {
    public static InventorySystem singleton = null;

    [SerializeField]
    private Image mainCharEquipmentWeaponImg;
    [SerializeField]
    private Image mainCharEquipmentOutfitImg;

    [SerializeField]
    private GameObject equpimentHolder;

    [SerializeField]
    private TextAsset containedWeaponsTxt;

    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject inventoryWeaponsList;
    [SerializeField]
    private GameObject inventoryOutfitsList;

    [SerializeField]
    private List<InventorySlot> weaponSlots;
    void Start() {
        weaponSlots = new List<InventorySlot>();
        if (singleton == null) {
            singleton = this;
        }
        startupContainments(); 
    }

    //Get called by outside to add item to inventory. 
    public void addBoughtItem(Sprite sprite, string path, string weaponChineseName, ItemType itemType) {
        GameObject instantiated = null;
        switch (itemType) {
            case ItemType.WEAPON:
                instantiated = Instantiate(slotPrefab, inventoryWeaponsList.transform);
                break;
            case ItemType.OUTFIT:
                instantiated = Instantiate(slotPrefab, inventoryOutfitsList.transform);
                break;
        }
        var itemObject = instantiated.transform.GetChild(1);
        var textHolder = itemObject.GetComponent<Text>();
        var _itemInfo = instantiated.GetComponent<ItemInfo>();
        InventorySlotItem inventorySlotItem = textHolder.gameObject.GetComponent<InventorySlotItem>();
        switch (itemType) {
            case ItemType.WEAPON:
                inventorySlotItem.mainCharWeaponEquipmentImg = mainCharEquipmentWeaponImg;
                break;
            case ItemType.OUTFIT:
                inventorySlotItem.mainCharWeaponEquipmentImg = mainCharEquipmentOutfitImg;
                break;
        }
        inventorySlotItem.getCalledStart();
        EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
        EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
        EventTriggerSettings.setEventTriggerOnClick(inventorySlotItem);
        textHolder.text = weaponChineseName;

        _itemInfo.name = weaponChineseName;
        _itemInfo.itemType = itemType;
        _itemInfo.sprite = sprite;
        _itemInfo.spriteHolderObject = equpimentHolder;
        
        weaponSlots.Add(new InventorySlot
        {
            _gameObject = instantiated,
            textHolder = textHolder,
            path = path,
            itemInfo = _itemInfo 
        });
    }

    //Only called on startup, to read all inventory items.
    private void startupContainments() {
        Debug.Log("Update Containments");
        int childs = inventoryWeaponsList.transform.childCount;
        for (int i = childs - 1; i > 0; i--) {
            Destroy(inventoryWeaponsList.transform.GetChild(i).gameObject);
        }

        List<string> lines;
        using (StreamReader streamReader = new StreamReader("Assets/Resources/Equipments/ContainedWeapons.txt")) {
            lines = new List<string>(streamReader.ReadToEnd().Split('\n'));
        }
        addItemToInventoryList(lines, inventoryWeaponsList);

        using (StreamReader streamReader = new StreamReader("Assets/Resources/Equipments/ContainedOutfits.txt")) {
            lines = new List<string>(streamReader.ReadToEnd().Split('\n'));
        }
        addItemToInventoryList(lines, inventoryOutfitsList);


        if (lines.Count == 1 && (lines[0] == "" || lines[0] == "\n")) {
            return;
        }

    }

    private void addItemToInventoryList(List<string> lines, GameObject inventoryList) {
        for (int i = 0; i < lines.Count - 1; i += 3) {
            var instantiated = Instantiate(slotPrefab, inventoryList.transform);
            var itemObject = instantiated.transform.GetChild(1);
            var textHolder = itemObject.GetComponent<Text>();
            var itemInfo = instantiated.GetComponent<ItemInfo>();
            InventorySlotItem inventorySlotItem = textHolder.gameObject.GetComponent<InventorySlotItem>();
            inventorySlotItem.mainCharWeaponEquipmentImg = mainCharEquipmentWeaponImg;
            inventorySlotItem.getCalledStart();
            EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
            EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
            EventTriggerSettings.setEventTriggerOnClick(inventorySlotItem);
            textHolder.text = lines[i];

            string linei_1Replaced = Regex.Replace(lines[i + 1], @"\t|\n|\r", "");
            itemInfo.sprite = Resources.Load<Sprite>(linei_1Replaced);
            if (itemInfo.sprite == null) {
                Debug.Log("Failed to load equipment sprite: Equipments/" + lines[i + 1]);
            }

            itemInfo.name = lines[i];
            switch (lines[i + 2]) {
                case "Weapon":
                    itemInfo.itemType = ItemType.WEAPON;
                    break;
                case "Outfit":
                    itemInfo.itemType = ItemType.OUTFIT;
                    break;
                case "Accessories":
                    itemInfo.itemType = ItemType.ACCESSORIES;
                    break;
            }
            itemInfo.spriteHolderObject = equpimentHolder;

            weaponSlots.Add(new InventorySlot {
                _gameObject = instantiated,
                textHolder = textHolder,
                path = lines[i + 1],
                itemInfo = itemInfo
            });
        }
    }

    //public void receiveItem<gameObject>(Typ) {

    //}
}
