using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoardUtility : PageUtility
{
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

    // Start is called before the first frame update
    void Start()
    {
        base.utilityStart();
        
        startInputMissionBtn = startInputMissionBtnObject.GetComponent<Button>();
        startInputMissionBtn.onClick.AddListener(startInputMissionBtnOnClick);
        startInputMissionBtnObject.SetActive(false);

        startInputMissionBtnText = startInputMissionBtn.GetComponentInChildren<Text>();
        startInputMissionBtnText.text = "加入新任務";
        missionPaperObject.SetActive(false);
        
        missionPaperConfirmBtn.onClick.AddListener(missionPaperConfirmOnClick);
    }

    private void Update()
    {
        // if (startCount)
        // {
            // Debug.Log("Test");
        // }
        if (countDownTimer != 0)
        {
            countDownTimer -= (Time.deltaTime / 3600f / 24f > 0) ? Time.deltaTime / 3600f / 24f : countDownTimer;
            _missionSettingController.CountDownValueShow = countDownTimer * 24f;
            Debug.Log("countDownTimer:" + countDownTimer);
        }
        else
        {
            _missionSettingController.StartCountingDown = false;
        }
    }

    public override void getCalledStart()
    {
        startInputMissionBtnObject.SetActive(true);
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        startInputMissionBtnObject.SetActive(false);
        missionPaperObject.SetActive(false);
    }

    private void startInputMissionBtnOnClick()
    {
        missionPaperObject.SetActive(true);
        missionPaperConfirmBtn.gameObject.SetActive(true);
        startInputMissionBtnObject.SetActive(false);
        shortcutObject.SetActive(false);
    }

    private void missionPaperConfirmOnClick()
    {
        missionPaperConfirmBtn.gameObject.SetActive(false);
        startInputMissionBtnObject.SetActive(true);
        missionPaperScrollbar.interactable = false;
        startInputMissionBtnText.text = "重置新任務";
        shortcutObject.SetActive(true);
        _missionSettingController.StartCountingDown = true;
        countDownTimer = missionPaperScrollbar.value;
        Debug.Log("countDownTimer:" + countDownTimer);
        // startCounting = true;
        // StartCoroutine(userInputTimer(scro))
    }
    

}
