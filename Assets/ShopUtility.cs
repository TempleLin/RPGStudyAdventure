using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUtility : PageUtility {
    [SerializeField] private GameObject shopLadyObject;
    [SerializeField] private GameObject shopPageUIObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private GameObject mainCharPreviewPanel;
    private Vector3 mainCharImgOriginPos;
    void Start() {
        base.utilityStart();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImgOriginPos = mainCharImg.transform.position;
    }

    public override void getCalledStart() {
        shopLadyObject.SetActive(true);
        shopPageUIObject.SetActive(true);
        mainCharImg.transform.position = mainCharPreviewPanel.transform.position;
        mainCharImg.SetActive(true);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
        mainCharImg.transform.position = mainCharImgOriginPos;
        mainCharImg.SetActive(false);
    }
}
