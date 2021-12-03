using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainhallUtility : PageUtility
{
    [SerializeField] private GameObject mainCharObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void getCalledStart()
    {
        mainCharObject.SetActive(true);
    }

    public override void getCalledUpdate()
    {
        
    }

    public override void getCalledStop()
    {
        mainCharObject.SetActive(false);
    }
}
