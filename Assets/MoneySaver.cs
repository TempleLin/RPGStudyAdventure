using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySaver : MonoBehaviour
{
    [SerializeField]
    private Text moneyCountText;
    [SerializeField]
    private TextAsset moneyCountTxtFile;

    void Start()
    {
        moneyCountTxtFile = Resources.Load<TextAsset>("Currency/MoneyCount");
        updateMoneyCount();
    }

    public void updateMoneyCount() {
        Debug.Log("MoneyCountTxtFile: " + moneyCountTxtFile.text);
        moneyCountText.text = moneyCountTxtFile.text;
    }
}
