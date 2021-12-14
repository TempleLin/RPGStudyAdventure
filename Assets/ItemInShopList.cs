using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInShopList : MonoBehaviour
{
    public static ItemInShopList currentSelectedItem = null;
    private Text text;
    private ItemInfo itemInfo;
    public ItemInfo @ItemInfo { get => itemInfo; set => itemInfo = value; }
    public Sprite sprite => itemInfo.sprite;

    public void getCalledStart() {
        text = GetComponent<Text>();
        text.text = itemInfo.name + "  " + itemInfo.price.ToString();
    }
}
