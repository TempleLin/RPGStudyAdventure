using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button)), RequireComponent(typeof(EventTrigger))]
public class ShortcutButtons : MonoBehaviour
{
    private static GameObject backgroundObject = null;
    private static SpriteRenderer backgroundSprite = null;
    private static PageUtility[] pageUtilities;

    // private static RectTransform backgroundRect = null;
    // Start is called before the first frame update
    void Start()
    {
        if (backgroundObject == null)
        {
            backgroundObject = GameObject.Find("Background");
            backgroundSprite = backgroundObject.GetComponent<SpriteRenderer>();
            pageUtilities = GameObject.Find("EachPageUtilities").GetComponents<PageUtility>();
        }
    }

    void Update()
    {
        
    }

    public void switchToMainhall()
    {
        backgroundSprite.sprite = pageUtilities[0].Background;
    }
    public void switchToMissionBoard()
    {
        backgroundSprite.sprite = pageUtilities[1].Background;
    }
    public void switchToAttackSelectionPage()
    {
        backgroundSprite.sprite = pageUtilities[2].Background;
    }
    public void switchToShop()
    {
        backgroundSprite.sprite = pageUtilities[3].Background;
    }

    public void switchToCharStatus()
    {
        backgroundSprite.sprite = pageUtilities[4].Background;
    }



}
