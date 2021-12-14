using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopUtility : PageUtility {
    [SerializeField] private GameObject shopLadyObject;
    [SerializeField] private GameObject shopPageUIObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private Image mainCharWeaponImgEquipHolder;
    [SerializeField] private Image mainCharOutfitImgEquipHolder;
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
    private Sprite mainCharWeaponImgEquipHolderOriginalSprite;
    void Start() {
        base.utilityStart();
        mainCharMoneySaver.initializeReadMoneyCount();
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

        mainCharWeaponImgEquipHolderOriginalSprite = mainCharWeaponImgEquipHolder.sprite;
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        resetScrollPos();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImg.transform.position = mainCharImgOriginPos;
        mainCharImg.SetActive(false);

        /*
         * Reset equipment back when changing page. 
         * (Since the equipments clicked in this page are only for preview.)
         */
        mainCharWeaponImgEquipHolder.sprite = mainCharWeaponImgEquipHolderOriginalSprite;
        if (mainCharWeaponImgEquipHolder.sprite == null)
            mainCharWeaponImgEquipHolder.color = new Color(1, 1, 1, 0); //Prevent having color the the image comp if not equipment is assigned.
        ItemInShopList.currentSelectedItem = null; //Release item selection in preview when changing page.
    }

    private void updateItemsInShopList() {
        List<string> lines;
        using (StreamReader streamReader = new StreamReader("Assets/Resources/ItemsInShop/WeaponsInShop.txt")) {
            lines = new List<string>(streamReader.ReadToEnd().Split('\n'));
        }
        //List<string> lines = new List<string>(shopWeaponsListtxt.text.Split('\n'));
        for (int i = 0; i < lines.Count; i += 3) {
            shopWeaponsSelections.addItem(new ItemInfo {
                name = lines[i].Trim(),
                sprite = Resources.Load<Sprite>(lines[i + 1].Trim()),
                price = int.Parse(lines[i + 2].Trim()),
                itemType = ItemType.WEAPON,
                spriteHolderObject = mainCharWeaponImgEquipHolder.gameObject
            });
        }

        using (StreamReader streamReader = new StreamReader("Assets/Resources/ItemsInShop/OutfitsInShop.txt")) {
            lines = new List<string>(streamReader.ReadToEnd().Split('\n'));
        }
        //lines = new List<string>(shopOutfitListtxt.text.Split('\n'));
        for (int i = 0; i < lines.Count; i += 3) {
            shopOutfitSelections.addItem(new ItemInfo {
                name = lines[i].Trim(),
                sprite = Resources.Load<Sprite>(lines[i + 1].Trim()),
                price = int.Parse(lines[i + 2].Trim()),
                itemType = ItemType.OUTFIT,
                spriteHolderObject = mainCharOutfitImgEquipHolder.gameObject
            });
        }
    }

    private void resetScrollPos() {
        itemsListScrollbar.value = 1f;
    }
}
