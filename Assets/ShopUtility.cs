using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUtility : PageUtility {
    [SerializeField]
    private GameObject shopLadyObject;
    [SerializeField]
    private GameObject shopPageUIObject;
    void Start() {
        base.utilityStart();
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
    }

    public override void getCalledStart() {
        shopLadyObject.SetActive(true);
        shopPageUIObject.SetActive(true);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        shopLadyObject.SetActive(false);
        shopPageUIObject.SetActive(false);
    }
}
