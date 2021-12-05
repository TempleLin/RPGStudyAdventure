using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackSelectionUtility : PageUtility
{
    [SerializeField]
    private List<MonsterSelectionWidget> monsterSelectionWidgets;
    public List<MonsterSelectionWidget> MonsterSelectionWidgets => monsterSelectionWidgets;

    private bool instantiatedHoveringEventTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        base.utilityStart();
        monsterSelectionWidgets.ForEach(selections =>
        {
            selections.gameObject.SetActive(false);
            selections.MonsterObject.SetActive(false);
        });
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
        monsterSelectionWidgets.ForEach(selections =>
        {
            selections.gameObject.SetActive(true);
            if (!instantiatedHoveringEventTrigger)
            {
                selections.gameObject.AddComponent<EventTrigger>();
            }
        });

        instantiatedHoveringEventTrigger = true;
    }

    public override void getCalledUpdate()
    {
    }

    public override void getCalledStop()
    {
        monsterSelectionWidgets.ForEach(selections => selections.gameObject.SetActive(false));
    }
}
