using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUtility : PageUtility {
    [SerializeField]
    private GameObject shopLadyObject;
    void Start() {
        base.utilityStart();
        shopLadyObject.SetActive(false);
    }

    public override void getCalledStart() {
        shopLadyObject.SetActive(true);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        shopLadyObject.SetActive(false);
    }
}
