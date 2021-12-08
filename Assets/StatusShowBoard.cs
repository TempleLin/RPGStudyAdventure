using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusShowBoard : MonoBehaviour
{
    [SerializeField] private CharacterProperties mainCharProperties;
    private Text text;
    private string[] statusTextsOrigin;
    private string[] statusTexts;
    void Start()
    {
        text = GetComponent<Text>();
        statusTextsOrigin = text.text.Split('\n');
        statusTexts = new string[statusTextsOrigin.Length];
        System.Array.Copy(statusTextsOrigin, statusTexts, statusTexts.Length);
        statusTexts[0] += mainCharProperties.AttackDmg.ToString();
        statusTexts[1] += mainCharProperties.Health.ToString();
        statusTexts[2] += mainCharProperties.Defense.ToString();
        statusTexts[3] += mainCharProperties.Agility.ToString();
        text.text = "";
        foreach(string s in statusTexts) {
            text.text += s + "\n";
        }
    }

    void Update()
    {
        
    }
}
