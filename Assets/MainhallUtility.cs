using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainhallUtility : MonoBehaviour, PageUtility
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

    public void getCalledStart()
    {
        mainCharObject.SetActive(true);
    }

    public void getCalledUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void getCalledStop()
    {
        mainCharObject.SetActive(false);
    }
}
