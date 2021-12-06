using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainhallUtility : PageUtility {
    // Start is called before the first frame update
    void Start() {
        base.utilityStart();
    }

    public override void getCalledStart() {
        _utilitiesSharedData.MainCharObject.SetActive(true);
    }

    public override void getCalledUpdate() {
        
    }

    public override void getCalledStop() {
        _utilitiesSharedData.MainCharObject.SetActive(false);
    }
}
