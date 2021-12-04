using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoardUtility : PageUtility
{
    [SerializeField] private GameObject shortcutObject;

    [SerializeField] private GameObject startInputMissionBtnObject;
    [SerializeField] private GameObject missionPaperObject;

    private Button startInputMissionBtn;

    private Text startInputMissionBtnText;

    // Start is called before the first frame update
    void Start()
    {
        startInputMissionBtn = startInputMissionBtnObject.GetComponent<Button>();
        startInputMissionBtn.onClick.AddListener(startInputMissionBtnOnclick);

        startInputMissionBtnText = startInputMissionBtn.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        startInputMissionBtnObject.SetActive(true);
        missionPaperObject.SetActive(false);
    }

    private void startInputMissionBtnOnclick()
    {
        missionPaperObject.SetActive(true);
        startInputMissionBtnObject.SetActive(false);
        shortcutObject.SetActive(false);
    }
}
