using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button)), RequireComponent(typeof(EventTrigger))]
public class ShortcutButtons : MonoBehaviour, EventTriggerSettings.TriggerOnHover {
    private static GameObject backgroundObject = null;
    private static SpriteRenderer backgroundSprite = null;
    private static PageUtility[] pageUtilities;
    private static PageUtility currentPage;
    private RectTransform _rectTransform;
    private EventTrigger _eventTrigger;
    private static AudioSource _audioSource = null;
    private static bool startOfGame = false;
    public EventTrigger EventTrigger {
        get => _eventTrigger;
        set => _eventTrigger = value;
    }

    void Start() {
        if (backgroundObject == null) {
            backgroundObject = GameObject.Find("Background");
            backgroundSprite = backgroundObject.GetComponent<SpriteRenderer>();
            pageUtilities = GameObject.Find("EachPageUtilities").GetComponents<PageUtility>();
            currentPage = pageUtilities[0];
            backgroundSprite.sprite = currentPage.Background;
        }
        if (_audioSource == null) {
            _audioSource = transform.GetComponentInParent<AudioSource>();
        }

        _rectTransform = GetComponent<RectTransform>();
        setEventTrigger();
    }

    //Event trigger function
    public void onHoverEntry(BaseEventData baseEventData) {
        var tempLocalScale = _rectTransform.localScale;
        _rectTransform.localScale = new Vector3(tempLocalScale.x + .3f, tempLocalScale.y + .3f, tempLocalScale.z);
    }

    //Event trigger function
    public void onExitHoverEntry(BaseEventData baseEventData) {
        var tempLocalScale = _rectTransform.localScale;
        _rectTransform.localScale = new Vector3(tempLocalScale.x - .3f, tempLocalScale.y - .3f, tempLocalScale.z);
    }

    public void switchToMainhall() {
        switch_start_stop_Page(0);
        _audioSource.Play();
    }
    public void switchToMissionBoard() {
        switch_start_stop_Page(1);
        _audioSource.Play();
    }
    public void switchToAttackSelectionPage() {
        switch_start_stop_Page(2);
        _audioSource.Play();
    }
    public void switchToShop() {
        switch_start_stop_Page(3);
        _audioSource.Play();
    }

    public void switchToCharStatus() {
        switch_start_stop_Page(4);
        _audioSource.Play();
    }


    private void switch_start_stop_Page(int index) {
        if (currentPage != pageUtilities[index]) {
            backgroundSprite.sprite = pageUtilities[index].Background;
            currentPage.getCalledStop();
            pageUtilities[index].getCalledStart();
            currentPage = pageUtilities[index];
        }
    }


    private void setEventTrigger() {
        _eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTriggerSettings.setEventTriggerHoveringScale(this);
    }
}
