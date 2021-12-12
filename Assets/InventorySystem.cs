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

    private List<InventorySlot> slots;
    void Start() {
        slots = new List<InventorySlot>();
        if (singleton == null) {
            singleton = this;
        }
        updateContainments(); 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
            var itemObject = instantiated.transform.GetChild(1);
            var textHolder = itemObject.GetComponent<Text>();
            var itemInfo = instantiated.GetComponent<ItemInfo>();
            InventorySlotItem inventorySlotItem = instantiated.transform.GetChild(1).GetComponent<InventorySlotItem>();
            inventorySlotItem.getCalledStart();
            EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
            EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
            EventTriggerSettings.setEventTriggerOnClick(inventorySlotItem);
            textHolder.text = "我雞雞好癢";
            slots.Add(new InventorySlot {
                _gameObject = instantiated,
                textHolder = textHolder
            });
        }
    }

    public void updateContainments() {
        Debug.Log("Update Containments");
        int childs = inventoryObject.transform.childCount;
        for (int i = childs - 1; i > 0; i--) {
            Destroy(inventoryObject.transform.GetChild(i).gameObject);
        }

        List<string> lines = new List<string>(containedWeaponsTxt.text.Split('\n'));
        for (int i = 0; i < lines.Count; i += 3) {
            if (i == lines.Count - 1 && (lines[i] == "" || lines[i] == "\n")) {
                break;
            }            
            
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
        }
    }

    //public void receiveItem<gameObject>(Typ) {

    //}
}
