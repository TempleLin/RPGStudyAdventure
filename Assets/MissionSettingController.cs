using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSettingController : MonoBehaviour {
    private Scrollbar _scrollbar;

    [SerializeField]
    private Text text;

    private string textDefaultStr;

    public bool StartCountingDown { get; set; } = false;
    public float CountDownValueShow { get; set; } = 0f;

    void Start() {
        _scrollbar = GetComponent<Scrollbar>();
        textDefaultStr = text.text;
    }

    void Update() {
        if (!StartCountingDown) {
            Debug.Log("NoStartCountingDown");
            text.text = (_scrollbar.value > 0) ? (_scrollbar.value * 24f) + "小時" : textDefaultStr;
            _scrollbar.interactable = true;
        } else {
            Debug.Log("StartCountingDown");
            // _scrollbar.value -= (_scrollbar.value - (Time.deltaTime / 3600f / 24f) >= 0)? Time.deltaTime / 3600f / 24f : _scrollbar.value;
            _scrollbar.value = CountDownValueShow;
            text.text = (_scrollbar.value).ToString();
            _scrollbar.interactable = false;
        }
    }
}
