using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectionUtility : PageUtility
{
    [SerializeField]
    private List<GameObject> monsterSelectionButtons;

    public List<GameObject> MonsterSelectionButtons => monsterSelectionButtons;
    // Start is called before the first frame update
    void Start()
    {
        
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
