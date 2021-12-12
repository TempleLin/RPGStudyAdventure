using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInShopList : MonoBehaviour
{
    public static ItemInShopList currentSelectedWeapon = null;
    public static ItemInShopList currentSelectedOutfit = null;
    public static ItemInShopList currentSelectedAccessory = null;
    public ItemInShopList CurrentSelectedWeapon
    {
        get => currentSelectedWeapon;
        set => currentSelectedWeapon = value;
    }
    public ItemInShopList CurrentSelectedOutfit
    {
        get => currentSelectedOutfit;
        set => currentSelectedOutfit = value;
    }

    public ItemInShopList CurrentSelectedAccessory
    {
        get => currentSelectedAccessory;
        set => currentSelectedAccessory = value;
    }
    
    private Text text;
    private ItemInfo itemInfo;
    public ItemInfo @ItemInfo { get => itemInfo; set => itemInfo = value; }
    public Sprite sprite => itemInfo.sprite;
    public void getCalledStart() {
        text = GetComponent<Text>();
        text.text = itemInfo.name;
    }
}
