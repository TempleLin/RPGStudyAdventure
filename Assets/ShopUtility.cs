using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUtility : PageUtility {
    [SerializeField]
    private GameObject shopLadyObject;
    // Start is called before the first frame update
    void Start() {
        base.utilityStart();

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
