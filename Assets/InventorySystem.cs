using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot {
    public GameObject _gameObject;
    public Text textHolder;
}
public class InventorySystem : MonoBehaviour {
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject inventoryObject;

    private List<InventorySlot> slots;
    void Start() {
        slots = new List<InventorySlot>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
            var textHolder = instantiated.transform.GetChild(1).GetComponent<Text>();
            InventorySlotItem inventorySlotItem = instantiated.transform.GetChild(1).GetComponent<InventorySlotItem>();
            inventorySlotItem.getCalledStart();
            EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
            EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
            textHolder.text = "§ÚÂûÂû¦nÄo";
            slots.Add(new InventorySlot {
                _gameObject = instantiated,
                textHolder = textHolder
            });
        }
    }

    //public void receiveItem<gameObject>(Typ) {

    //}
}
