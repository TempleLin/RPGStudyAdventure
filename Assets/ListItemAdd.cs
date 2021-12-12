using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItemAdd : MonoBehaviour
{
    [SerializeField] private GameObject listItemPrefab;
    [SerializeField] private GameObject confirmBuyPopupRef;
    public GameObject ConfirmBuyPopupRef => confirmBuyPopupRef;
    [SerializeField] private MoneySaver moneySaverRef;
    public MoneySaver MoneySaverRef => moneySaverRef;
    
    public void addItem(ItemInfo itemInfo) {
        Debug.Log("0: " + itemInfo.name);
        var instantiated = Instantiate(listItemPrefab, transform);
        ItemInShopList itemInShopList = instantiated.transform.GetChild(0).GetComponent<ItemInShopList>();
        if (itemInShopList == null) {
            Debug.Log("Failed");
        }
        itemInShopList.ItemInfo = itemInfo;
        itemInShopList.getCalledStart();
    }
}
