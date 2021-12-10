using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInShopList : MonoBehaviour
{
    private Text text;
    private ItemInfo itemInfo;
    public ItemInfo @ItemInfo { set => itemInfo = value; }
    public void getCalledStart() {
        text = GetComponent<Text>();
        text.text = itemInfo.name;
    }
}
