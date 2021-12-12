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

    public int moneyCount;
    void Start()
    {
        moneyCountTxtFile = Resources.Load<TextAsset>("Currency/MoneyCount");
        updateMoneyCount();
    }

    public void updateMoneyCount() {
        moneyCountTxtFile.text.Trim();
        moneyCountText.text = moneyCountTxtFile.text;
        moneyCount = int.Parse(moneyCountText.text);
    }
}
