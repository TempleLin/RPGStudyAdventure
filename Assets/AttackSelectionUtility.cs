using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackSelectionUtility : PageUtility
{
    // private EventTrigger _eventTrigger;
    // public EventTrigger @EventTrigger => _eventTrigger;

    [SerializeField]
    private List<MonsterSelectionWidget> monsterSelectionWidgets;

    public List<MonsterSelectionWidget> MonsterSelectionWidgets => monsterSelectionWidgets;

    private bool instantiatedHoveringEventTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        // _eventTrigger = GetComponent<EventTrigger>();
        // HoveringEventTrigger.setEventTriggerHoveringScale(this);
    }

    // Update is called once per frame
    void Update()
    {
        monsterSelectionWidgets.ForEach(selections =>
        {
            selections.checkOnHover();
            selections.checkOnClick();
        });
    }

    public override void getCalledStart()
    {
        foreach (var selections in monsterSelectionWidgets)
        {
            selections.gameObject.SetActive(true);
            if (!instantiatedHoveringEventTrigger)
            {
                selections.gameObject.AddComponent<EventTrigger>();
                // HoveringEventTrigger.setEventTriggerHoveringScale(this);
            }
        }

        instantiatedHoveringEventTrigger = true;
        // monsterSelectionButtons.ForEach(selections => selections.SetActive(true));
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        monsterSelectionWidgets.ForEach(selections => selections.gameObject.SetActive(false));
    }
}
