using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtility : PageUtility
{
    private AttackSelectionUtility _attackSelectionUtility;
    void Start()
    {
        base.utilityStart();
        _attackSelectionUtility = GetComponent<AttackSelectionUtility>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void getCalledStart()
    {
        _attackSelectionUtility.getCalledStop();
        _attackSelectionUtility.getCalledStop();
        _utilitiesSharedData.BackgroundSpriteRenderer.sprite = background;
    }

    public override void getCalledUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void getCalledStop()
    {
        throw new System.NotImplementedException();
    }
}
