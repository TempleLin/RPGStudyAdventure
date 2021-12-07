using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackSelectionUtility : PageUtility {
    [SerializeField] private Camera camera;
    [SerializeField]
    private List<MonsterSelectionWidget> monsterSelectionWidgets;
    public List<MonsterSelectionWidget> MonsterSelectionWidgets => monsterSelectionWidgets;
    private BattleUtility _battleUtility;

    private bool instantiatedHoveringEventTrigger = false;
    void Start() {
        _battleUtility = GetComponent<BattleUtility>();
        base.utilityStart();
        monsterSelectionWidgets.ForEach(selections => {
            selections.gameObject.SetActive(false);
            selections.MonsterObject.SetActive(false);
        });
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        monsterSelectionWidgets.ForEach(selections => {
            selections.checkOnHover(hit);
            if (selections.checkOnClick())
            {
                _utilitiesSharedData.EnemyMonsterObject = selections.MonsterObject;
                _battleUtility.getCalledStart();
            }
        });
    }

    public override void getCalledStart() {
        monsterSelectionWidgets.ForEach(selections => {
            selections.gameObject.SetActive(true);
            if (!instantiatedHoveringEventTrigger) {
                selections.gameObject.AddComponent<EventTrigger>();
            }
        });

        instantiatedHoveringEventTrigger = true;
    }

    public override void getCalledUpdate() {
    }

    public override void getCalledStop() {
        monsterSelectionWidgets.ForEach(selections => selections.gameObject.SetActive(false));
    }
}
