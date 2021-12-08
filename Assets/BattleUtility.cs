using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtility : PageUtility {
    private AttackSelectionUtility _attackSelectionUtility;
    private bool startFight = false;
    [SerializeField] private float fightSpeed = .4f;
    private float fightWaitCounter = 0f;
    private CharacterProperties mainCharProperties;
    private CharacterProperties enemyProperties;
    private SpriteRenderer mainCharSpriteRenderer;
    private SpriteRenderer enemySpriteRenderer;
    private int nextGetAttacked = 0;
    
    void Start() {
        base.utilityStart();
        _attackSelectionUtility = GetComponent<AttackSelectionUtility>();
    }

    void Update() {
        if (startFight) {
            if (fightWaitCounter + Time.deltaTime < (float)fightSpeed) {
                fightWaitCounter += Time.deltaTime;
            } else {
                switch (nextGetAttacked) {
                    case 0:
                        mainCharSpriteRenderer.color = Color.red;
                        enemySpriteRenderer.color = Color.white;

                        float randomDodgeChance = Random.Range(1f, 1000f);
                        if (randomDodgeChance <= mainCharProperties.Agility) {
                            characterDodgeAttack(mainCharProperties);
                        }
                        else {
                            mainCharProperties.Health -= ((enemyProperties.AttackDmg - mainCharProperties.Defense > 0)?
                                enemyProperties.AttackDmg - mainCharProperties.Defense : 1);
                            Debug.Log("MainCharHealth: " + mainCharProperties.Health);
                            if (mainCharProperties.Health <= 0) {
                                mainCharProperties.resetProperties();
                                getCalledStop();
                            }
                        }
                        break;
                    case 1:
                        mainCharSpriteRenderer.color = Color.white;
                        enemySpriteRenderer.color = Color.red;
                        break;
                }

                nextGetAttacked = (nextGetAttacked + 1) % 2;
                fightWaitCounter = 0f;
            }
        }
    }

    public override void getCalledStart() {
        MusicsList.singleton.AudioSource.clip = MusicsList.singleton.Musics[1];
        MusicsList.singleton.AudioSource.Play();

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

    public override void getCalledUpdate() {
        
    }

    public override void getCalledStop() {
        MusicsList.singleton.AudioSource.clip = MusicsList.singleton.Musics[0];
        MusicsList.singleton.AudioSource.Play();

        _utilitiesSharedData.BackgroundSpriteRenderer.sprite = _attackSelectionUtility.Background;
        _utilitiesSharedData.EnemyMonsterObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        _utilitiesSharedData.ShortcutObject.SetActive(true);
        startFight = false;

        mainCharSpriteRenderer.color = Color.white;
        enemySpriteRenderer.color = Color.white;

        _attackSelectionUtility.getCalledStart();
    }

    private void characterDodgeAttack(CharacterProperties characterProperties) {
        Debug.Log(characterProperties.gameObject.name + " dodged!");
    }
}
