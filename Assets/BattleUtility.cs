using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtility : PageUtility
{
    private AttackSelectionUtility _attackSelectionUtility;
    private bool startFight = false;
    void Start()
    {
        base.utilityStart();
        _attackSelectionUtility = GetComponent<AttackSelectionUtility>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startFight)
        {
            
        }
    }

    public override void getCalledStart()
    {
        _attackSelectionUtility.getCalledStop();
        _utilitiesSharedData.BackgroundSpriteRenderer.sprite = background;
        _utilitiesSharedData.EnemyMonsterObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(true);
        _utilitiesSharedData.ShortcutObject.SetActive(false);
        startFight = true;
    }

    public override void getCalledUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void getCalledStop()
    {
        
    }
}
