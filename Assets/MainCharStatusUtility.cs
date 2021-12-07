using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharStatusUtility : PageUtility {
    [SerializeField] private GameObject inventoryObject;
    [SerializeField] private GameObject statusPanelObject;
    [SerializeField] private GameObject mainCharImg;
    [SerializeField] private GameObject charShowcasePanel;
    //private Vector3 mainCharOriginalPos;
    void Start() {
        base.utilityStart();
        inventoryObject.SetActive(false);
        statusPanelObject.SetActive(false);
        mainCharImg.SetActive(false);
        charShowcasePanel.SetActive(false);
        //mainCharImg = _utilitiesSharedData.MainCharObject;
    }

    public override void getCalledStart() {
        inventoryObject.SetActive(true);
        statusPanelObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        mainCharImg.SetActive(true);
        charShowcasePanel.SetActive(true);
        //Vector3 tempPosRef = mainCharImg.transform.position;
        //mainCharOriginalPos = tempPosRef;
        //mainCharImg.transform.position = new Vector3(-1f, mainCharOriginalPos.y + + 1f, mainCharOriginalPos.z);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        inventoryObject.SetActive(false);
        statusPanelObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        //mainCharImg.transform.position = mainCharOriginalPos;
        mainCharImg.SetActive(false);
        charShowcasePanel.SetActive(false);
    }
}
