using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    WEAPON,
    OUTFIT,
    ACCESSORIES
}

public class ItemInfo : MonoBehaviour
{
    public string name;
    public string description;
    public int price;
    public Sprite sprite;
    public ItemType itemType;
    public GameObject spriteHolderObject;
}
