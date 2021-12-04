using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatusUtility : PageUtility
{
    // Start is called before the first frame update
    void Start()
    {
        base.utilityStart();
    }

    // Update is called once per frame
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
