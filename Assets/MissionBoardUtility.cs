using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoardUtility : PageUtility {
    [SerializeField] private GameObject shortcutObject;

    [SerializeField] private GameObject startInputMissionBtnObject;
    [SerializeField] private GameObject missionPaperObject;
    [SerializeField] private Button missionPaperConfirmBtn;
    [SerializeField] private Scrollbar missionPaperScrollbar;
    [SerializeField] private MissionSettingController _missionSettingController;

    private Button startInputMissionBtn;

    private Text startInputMissionBtnText;
    // private bool startCounting = false;
    // private float timeCounter = 0f;
    // private bool startCount = false;
    private float countDownTimer = 0f;

    private string[] startInputMissionBtnTextToChange = new[] {"加入新任務", "重置新任務"};

    // Start is called before the first frame update
    void Start() {
        base.utilityStart();
        
        startInputMissionBtn = startInputMissionBtnObject.GetComponent<Button>();
        startInputMissionBtn.onClick.AddListener(startInputMissionBtnOnClick);
        startInputMissionBtnObject.SetActive(false);

        startInputMissionBtnText = startInputMissionBtn.GetComponentInChildren<Text>();
        startInputMissionBtnText.text = startInputMissionBtnTextToChange[0];
        missionPaperObject.SetActive(false);
        
        missionPaperConfirmBtn.onClick.AddListener(missionPaperConfirmOnClick);
    }

    private void Update() {
        // if (startCount)
        // {
            // Debug.Log("Test");
        // }
        if (countDownTimer != 0) {
            countDownTimer -= (Time.deltaTime / 3600f / 24f > 0) ? Time.deltaTime / 3600f / 24f : countDownTimer;
            _missionSettingController.CountDownValueShow = countDownTimer * 24f;
        } else {
            _missionSettingController.StartCountingDown = false;
        }
    }

    public override void getCalledStart() {
        startInputMissionBtnObject.SetActive(true);
        if (countDownTimer > 0)
            missionPaperObject.SetActive(true);
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        startInputMissionBtnObject.SetActive(false);
        missionPaperObject.SetActive(false);
    }

    private void startInputMissionBtnOnClick() {
        missionPaperObject.SetActive(true);
        missionPaperConfirmBtn.gameObject.SetActive(true);
        startInputMissionBtnObject.SetActive(false);

        if (startInputMissionBtnText.text == startInputMissionBtnTextToChange[1]) {
            Debug.Log("ResetMissionCountdown");
            _missionSettingController.StartCountingDown = false;
            _missionSettingController.CountDownValueShow = 0f;
            missionPaperScrollbar.value = 0f;
        }
    }

    private void missionPaperConfirmOnClick() {
        missionPaperConfirmBtn.gameObject.SetActive(false);
        startInputMissionBtnObject.SetActive(true);
        startInputMissionBtnText.text = startInputMissionBtnTextToChange[1];
        _missionSettingController.StartCountingDown = true;
        countDownTimer = missionPaperScrollbar.value;
        Debug.Log("countDownTimer:" + countDownTimer);
    }
}
