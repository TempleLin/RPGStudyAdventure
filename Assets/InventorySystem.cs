using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot
{
    public GameObject _gameObject;
    public Image spriteHolder;
}
public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject inventoryObject;

    [SerializeField] private List<Sprite> itemsImages;

    private List<InventorySlot> slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = new List<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var instantiated = Instantiate(slotPrefab, inventoryObject.transform);
            var spriteHolder = instantiated.transform.GetChild(1).GetComponent<Image>();
            InventorySlotItem inventorySlotItem = instantiated.transform.GetChild(1).GetComponent<InventorySlotItem>();
            inventorySlotItem.getCalledStart();
            EventTriggerSettings.setEventTriggerDragDrop(inventorySlotItem);
            EventTriggerSettings.setEventTriggerHoveringScale(inventorySlotItem);
            spriteHolder.sprite = itemsImages[0];
            slots.Add(new InventorySlot
            {
                _gameObject = instantiated,
                spriteHolder = spriteHolder
            });
        }
    }
}
