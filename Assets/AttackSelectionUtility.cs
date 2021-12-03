using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class AttackSelectionUtility : PageUtility
{
    private EventTrigger _eventTrigger;
    [SerializeField]
    private List<GameObject> monsterSelectionButtons;

    public List<GameObject> MonsterSelectionButtons => monsterSelectionButtons;
    // Start is called before the first frame update
    void Start()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        
        // EventTrigger.Entry onHoverEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerEnter};
        // onHoverEntry.callback.AddListener(onHover);
        // _eventTrigger.triggers.Add(onHoverEntry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void getCalledStart()
    {
        monsterSelectionButtons.ForEach(selections => selections.SetActive(true));
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        monsterSelectionButtons.ForEach(selections => selections.SetActive(false));
    }
}
