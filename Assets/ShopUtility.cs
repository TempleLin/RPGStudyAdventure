using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUtility : PageUtility {
    [SerializeField] private GameObject shopLadyObject;
    [SerializeField] private GameObject shopPageUIObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private GameObject mainCharPreviewPanel;
    [SerializeField] private MoneySaver mainCharMoneySaver;
    [SerializeField] private Scrollbar itemsListScrollbar;
    private Vector3 mainCharImgOriginPos;
    void Start() {
        base.utilityStart();
        resetScrollPos();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImgOriginPos = mainCharImg.transform.position;
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

    private void resetScrollPos() {
        itemsListScrollbar.value = 1f;
    }
}
