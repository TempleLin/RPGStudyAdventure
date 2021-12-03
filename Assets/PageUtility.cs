using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageUtility : MonoBehaviour
{
    [SerializeField]    
    protected Sprite background;

    public Sprite @Background => background;
    public abstract void getCalledStart();
    public abstract void getCalledUpdate();
    public abstract void getCalledStop();
}
