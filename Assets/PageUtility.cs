using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageUtility : MonoBehaviour
{
    [SerializeField]    
    protected Sprite background;

    public Sprite @Background => background;
    protected UtilitiesSharedData _utilitiesSharedData;
    public abstract void getCalledStart();
    public abstract void getCalledUpdate();
    public abstract void getCalledStop();

    public void utilityStart()
    {
        _utilitiesSharedData = GetComponent<UtilitiesSharedData>();
    }
}
