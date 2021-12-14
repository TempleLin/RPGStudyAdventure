using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListSelections : MonoBehaviour
{
    [SerializeField] private GameObject listItemPrefab;
    [SerializeField] private GameObject confirmBuyPopupRef;
    public GameObject ConfirmBuyPopupRef => confirmBuyPopupRef;
    [SerializeField] private MoneySaver moneySaverRef;
    public MoneySaver MoneySaverRef => moneySaverRef;
    
    public void addItem(string name, Sprite sprite, int price, ItemType itemType, GameObject spriteHolderObject) {
        Debug.Log(126);
        var instantiated = Instantiate(listItemPrefab, transform);
        ItemInShopList itemInShopList = instantiated.transform.GetChild(0).GetComponent<ItemInShopList>();
        if (itemInShopList == null) {
            Debug.Log("Failed");
        }
        itemInShopList.ItemInfo = itemInShopList.gameObject.GetComponent<ItemInfo>();

        itemInShopList.ItemInfo.name = name;
        itemInShopList.ItemInfo.sprite = sprite;
        itemInShopList.ItemInfo.price = price;
        itemInShopList.ItemInfo.itemType = itemType;
        itemInShopList.ItemInfo.spriteHolderObject = spriteHolderObject;

        itemInShopList.getCalledStart();
    }
    //public void addItem(ItemInfo itemInfo) {
    //    Debug.Log("0: " + itemInfo.name);
    //    var instantiated = Instantiate(listItemPrefab, transform);
    //    ItemInShopList itemInShopList = instantiated.transform.GetChild(0).GetComponent<ItemInShopList>();
    //    if (itemInShopList == null) {
    //        Debug.Log("Failed");
    //    }
    //    if (itemInfo == null) {
    //        Debug.Log("Item info is empty");
    //    }
    //    itemInShopList.ItemInfo = itemInfo;
    //    itemInShopList.getCalledStart();
    //}
}
