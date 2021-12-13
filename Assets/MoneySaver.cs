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

    private int moneyCount;
    public int MoneyCount => moneyCount;
    void Start()
    {
        moneyCountTxtFile = Resources.Load<TextAsset>("Currency/MoneyCount");
        initializeReadMoneyCount();
    }

    public void editMoneyCount(int quantity) {
        moneyCount += quantity;
        moneyCountText.text = moneyCount.ToString();
    }

    public void initializeReadMoneyCount() {
        moneyCountTxtFile.text.Trim();
        moneyCountText.text = moneyCountTxtFile.text;
        moneyCount = int.Parse(moneyCountText.text);
    }
}
