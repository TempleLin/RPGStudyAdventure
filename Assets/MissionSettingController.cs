using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSettingController : MonoBehaviour
{
    private Scrollbar _scrollbar;

    [SerializeField]
    private Text text;

    private string textDefaultStr;
    // Start is called before the first frame update
    void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
        textDefaultStr = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (_scrollbar.value > 0) ? (_scrollbar.value * 24f) + "小時" : textDefaultStr;
    }
}
