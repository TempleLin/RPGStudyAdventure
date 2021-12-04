using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatusUtility : PageUtility
{
    [SerializeField] private GameObject inventoryObject;
    
    void Start()
    {
        base.utilityStart();
        inventoryObject.SetActive(false);
    }

    public override void getCalledStart()
    {
        inventoryObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(true);
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        inventoryObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
    }
}
