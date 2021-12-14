using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * All controls below either are just temporary features or needs better enhancements in the future.
 */
public class TempControls : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Backspace)) {
            Debug.Log("Application Quit");
            Application.Quit();
        }
    }
}
