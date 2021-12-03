using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button)), RequireComponent(typeof(EventTrigger))]
public class ShortcutButtons : MonoBehaviour
{
    private static GameObject backgroundObject = null;
    private static Background backgroundScript = null;
    private static SpriteRenderer backgroundSprite = null;

    // private static RectTransform backgroundRect = null;
    // Start is called before the first frame update
    void Start()
    {
        if (backgroundSprite == null)
        {
            backgroundObject = GameObject.Find("Background");
            backgroundScript = backgroundObject.GetComponent<Background>();
            backgroundSprite = backgroundObject.GetComponent<SpriteRenderer>();
            // backgroundRect = backgroundObject.GetComponent<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchToMainhall()
    {
        // backgroundSprite.sprite =
        //     Sprite.Create(backgroundScript.backgrounds[0], backgroundRect.rect,
        //         backgroundRect.pivot); //backgroundScript.backgrounds[0];
        backgroundSprite.sprite = backgroundScript.backgrounds[0];
    }

    public void switchToShop()
    {
        // backgroundSprite.sprite =
        //     Sprite.Create(backgroundScript.backgrounds[1], backgroundRect.rect,
        //         backgroundRect.pivot);
        backgroundSprite.sprite = backgroundScript.backgrounds[1];
    }

    public void switchToAttackSelectionPage()
    {
        backgroundSprite.sprite = backgroundScript.backgrounds[2];
    }

    public void switchToMissionBoard()
    {
        backgroundSprite.sprite = backgroundScript.backgrounds[3];
    }
}
