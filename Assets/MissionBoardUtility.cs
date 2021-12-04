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

    private Button startInputMissionBtn;

    private Text startInputMissionBtnText;

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
        startInputMissionBtnObject.SetActive(false);
        shortcutObject.SetActive(false);
    }

    private void missionPaperConfirmOnClick()
    {
        missionPaperObject.SetActive(false);
        startInputMissionBtnObject.SetActive(true);
        startInputMissionBtnText.text = "重置新任務";
        shortcutObject.SetActive(true);
    }
}
