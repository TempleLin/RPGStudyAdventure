using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatusUtility : PageUtility
{
    [SerializeField] private GameObject inventoryObject;
    
    void Start()
    {
        base.utilityStart();
        // inventoryObject.
    }

    void Update()
    {
        
    }

    public override void getCalledStart()
    {
        _utilitiesSharedData.MainCharObject.SetActive(true);
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        _utilitiesSharedData.MainCharObject.SetActive(false);
    }
}
