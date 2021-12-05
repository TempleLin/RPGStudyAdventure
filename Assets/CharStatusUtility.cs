using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatusUtility : PageUtility
{
    [SerializeField] private GameObject inventoryObject;
    private GameObject mainChar;
    private Vector3 mainCharOriginalPos;
    void Start()
    {
        base.utilityStart();
        inventoryObject.SetActive(false);
        mainChar = _utilitiesSharedData.MainCharObject;
    }

    public override void getCalledStart()
    {
        inventoryObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(true);
        Vector3 tempPosRef = mainChar.transform.position;
        mainCharOriginalPos = tempPosRef;
        mainChar.transform.position = new Vector3(-1f, mainCharOriginalPos.y + + 1f, mainCharOriginalPos.z);
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        inventoryObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        mainChar.transform.position = mainCharOriginalPos;
    }
}
