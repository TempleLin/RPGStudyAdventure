using System.Collections;
using System.Collections.Generic;
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
    private Image mainCharEquipmentImg0;

    [SerializeField]
    private GameObject equpimentHolder;

    [SerializeField]
    private TextAsset containedWeaponsTxt;

    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject inventoryObject;

    [SerializeField]
    private List<InventorySlot> weaponSlots;
    void Start() {
        weaponSlots = new List<InventorySlot>();
        if (singleton == null) {
            singleton = this;
        }
        startupContainments(); 
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.A)) {
        //     var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
        //     var itemObject = instantiated.transform.GetChild(1);
        //     var textHolder = itemObject.GetComponent<Text>();
        //     var itemInfo = instantiated.GetComponent<ItemInfo>();
        //     InventorySlotItem inventorySlotItem = instantiated.transform.GetChild(1).GetComponent<InventorySlotItem>();
        //     inventorySlotItem.getCalledStart();
        //     EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
        //     EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
        //     EventTriggerSettings.setEventTriggerOnClick(inventorySlotItem);
        //     textHolder.text = "我雞雞好癢";
        //     slots.Add(new InventorySlot {
        //         _gameObject = instantiated,
        //         textHolder = textHolder
        //     });
        // }
    }
    
    //Get called by outside to add item to inventory. 
    public void addItem(ItemInfo itemInfo, Sprite sprite, string path, string weaponChineseName, ItemType itemType) {
        Debug.Log("ItemInfo: " + itemInfo);
        var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
        var itemObject = instantiated.transform.GetChild(1);
        var textHolder = itemObject.GetComponent<Text>();
        var _itemInfo = instantiated.GetComponent<ItemInfo>();
        InventorySlotItem inventorySlotItem = textHolder.gameObject.GetComponent<InventorySlotItem>();
        inventorySlotItem.mainCharEquipmentImg0 = mainCharEquipmentImg0;
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
        int childs = inventoryObject.transform.childCount;
        for (int i = childs - 1; i > 0; i--) {
            Destroy(inventoryObject.transform.GetChild(i).gameObject);
        }
        
        List<string> lines = new List<string>(containedWeaponsTxt.text.Split('\n'));
        Debug.Log("Count: " + lines.Count);
        if (lines.Count == 1 && (lines[0] == "" || lines[0] == "\n")) {
            Debug.Log(13);
            return;
        }
        
        for (int i = 0; i < lines.Count - 1; i += 3) {
            Debug.Log(14);
            Debug.Log("Print contains:");
            Debug.Log(containedWeaponsTxt.text);
            Debug.Log("End print contains.");
            
            var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
            var itemObject = instantiated.transform.GetChild(1);
            var textHolder = itemObject.GetComponent<Text>();
            var itemInfo = instantiated.GetComponent<ItemInfo>();
            InventorySlotItem inventorySlotItem = textHolder.gameObject.GetComponent<InventorySlotItem>();
            inventorySlotItem.mainCharEquipmentImg0 = mainCharEquipmentImg0;
            inventorySlotItem.getCalledStart();
            EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
            EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
            EventTriggerSettings.setEventTriggerOnClick(inventorySlotItem);
            textHolder.text = lines[i];
        
            string linei_1Replaced = Regex.Replace(lines[i+1], @"\t|\n|\r", "");
            itemInfo.sprite = Resources.Load<Sprite>(linei_1Replaced);
            if (itemInfo.sprite == null) {
                Debug.Log("Failed to load equipment sprite: Equipments/" + lines[i + 1]);
            }
        
            itemInfo.name = lines[i];
            switch(lines[i + 2]) {
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

            weaponSlots.Add(new InventorySlot
            {
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
