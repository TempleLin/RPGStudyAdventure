using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUtility : PageUtility {
    [SerializeField] private GameObject shopLadyObject;
    [SerializeField] private GameObject shopPageUIObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private Image mainCharWeaponImgEquipHolder;
    [SerializeField] private GameObject mainCharPreviewPanel;
    [SerializeField] private MoneySaver mainCharMoneySaver;
    [SerializeField] private Scrollbar itemsListScrollbar;
    [SerializeField] private BuyItemButton buyItemButton;
    [SerializeField] private ShopListSelections shopWeaponsSelections;
    [SerializeField] private ShopListSelections shopOutfitSelections;
    [SerializeField] private ShopListSelections shopAccessoriesSelections;
    [SerializeField] private TextAsset shopWeaponsListtxt;
    [SerializeField] private TextAsset shopOutfitListtxt;
    [SerializeField] private TextAsset shopAccessoriesListtxt;
    private Vector3 mainCharImgOriginPos;
    void Start() {
        base.utilityStart();
        resetScrollPos();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImgOriginPos = mainCharImg.transform.position;
        EventTriggerSettings.setEventTriggerOnClick(buyItemButton);
        EventTriggerSettings.setEventTriggerHoveringScale(buyItemButton);
        updateItemsInShopList();
    }

    public override void getCalledStart() {
        resetScrollPos();
        shopLadyObject.SetActive(true);
        shopPageUIObject.SetActive(true);
        mainCharImg.transform.position = mainCharPreviewPanel.transform.position;
        mainCharImg.SetActive(true);
        mainCharMoneySaver.updateMoneyCount();
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        resetScrollPos();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImg.transform.position = mainCharImgOriginPos;
        mainCharImg.SetActive(false);
    }

    private void updateItemsInShopList() {
        List<string> lines = new List<string>(shopWeaponsListtxt.text.Split('\n'));
        for (int i = 0; i < lines.Count; i += 3) {
            shopWeaponsSelections.addItem(new ItemInfo {
                name = lines[i].Trim(),
                sprite = Resources.Load<Sprite>(lines[i + 1].Trim()),
                price = int.Parse(lines[i + 2].Trim()),
                itemType = ItemType.WEAPON,
                spriteHolderObject = mainCharWeaponImgEquipHolder.gameObject
            });
        }
    }

    private void resetScrollPos() {
        itemsListScrollbar.value = 1f;
    }
}
