using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharStatusUtility : PageUtility {
    [SerializeField] private GameObject inventoryObject;
    [SerializeField] private GameObject statusPanelObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private GameObject charShowcasePanel;

    void Start() {
        base.utilityStart();
        inventoryObject.SetActive(false);
        statusPanelObject.SetActive(false);
        mainCharImg.SetActive(false);
        charShowcasePanel.SetActive(false);
    }

    public override void getCalledStart() {
        inventoryObject.SetActive(true);
        statusPanelObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        mainCharImg.SetActive(true);
        charShowcasePanel.SetActive(true);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        inventoryObject.SetActive(false);
        statusPanelObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        mainCharImg.SetActive(false);
        charShowcasePanel.SetActive(false);
    }
}
