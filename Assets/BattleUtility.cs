using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtility : PageUtility
{
    private AttackSelectionUtility _attackSelectionUtility;
    private bool startFight = false;
    [SerializeField] private float fightSpeed = .7f;
    private float fightWaitCounter = 0f;
    private CharacterProperties mainCharProperties;
    private CharacterProperties enemyProperties;
    private SpriteRenderer mainCharSpriteRenderer;
    private SpriteRenderer enemySpriteRenderer;
    private int nextGetAttacked = 0;
    
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
            Debug.Log("FightWaitCounter + Time.deltaTime: " + fightWaitCounter + Time.deltaTime);
            Debug.Log("FightSpeed: " + fightSpeed);
            if (fightWaitCounter + Time.deltaTime < (float)fightSpeed)
            {
                fightWaitCounter += Time.deltaTime;
            }
            else
            {
                switch (nextGetAttacked)
                {
                    case 0:
                        mainCharSpriteRenderer.color = Color.red;
                        enemySpriteRenderer.color = Color.white;
                        break;
                    case 1:
                        mainCharSpriteRenderer.color = Color.white;
                        enemySpriteRenderer.color = Color.red;
                        break;
                }

                nextGetAttacked = (nextGetAttacked + 1) % 2;
                Debug.Log(fightWaitCounter);
                fightWaitCounter = 0f;
            }
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
        mainCharProperties = _utilitiesSharedData.MainCharObject.GetComponent<CharacterProperties>();
        enemyProperties = _utilitiesSharedData.EnemyMonsterObject.GetComponent<CharacterProperties>();
        mainCharSpriteRenderer = _utilitiesSharedData.MainCharObject.GetComponent<SpriteRenderer>();
        enemySpriteRenderer = _utilitiesSharedData.EnemyMonsterObject.GetComponent<SpriteRenderer>();
    }

    public override void getCalledUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void getCalledStop()
    {
        
    }
}
