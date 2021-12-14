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
    private SpriteRenderer mainCharEquipWeaponSpriteRenderer;
    private SpriteRenderer mainCharEquipOutfitSpriteRenderer;
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
                        mainCharEquipWeaponSpriteRenderer.color = Color.red;
                        mainCharEquipOutfitSpriteRenderer.color = Color.red;
                        enemySpriteRenderer.color = Color.white;
                        launchAttack(enemyProperties, mainCharProperties);
                        break;
                    case 1:
                        mainCharSpriteRenderer.color = Color.white;
                        mainCharEquipWeaponSpriteRenderer.color = Color.white;
                        mainCharEquipOutfitSpriteRenderer.color = Color.white;
                        enemySpriteRenderer.color = Color.red;
                        launchAttack(mainCharProperties, enemyProperties);
                        break;
                }

                nextGetAttacked = (nextGetAttacked + 1) % 2;
                fightWaitCounter = 0f;
            }
        }
    }

    public override void getCalledStart() {
        Musics.singleton.AudioSource.clip = Musics.singleton._Musics[1];
        Musics.singleton.AudioSource.Play();

        _attackSelectionUtility.getCalledStop();
        _utilitiesSharedData.BackgroundSpriteRenderer.sprite = background;
        _utilitiesSharedData.EnemyMonsterObject.SetActive(true);
        _utilitiesSharedData.MainCharObject.SetActive(true);
        _utilitiesSharedData.ShortcutObject.SetActive(false);
        startFight = true;
        mainCharProperties = _utilitiesSharedData.MainCharObject.GetComponent<CharacterProperties>();
        enemyProperties = _utilitiesSharedData.EnemyMonsterObject.GetComponent<CharacterProperties>();
        mainCharSpriteRenderer = _utilitiesSharedData.MainCharObject.GetComponent<SpriteRenderer>();
        mainCharEquipWeaponSpriteRenderer = _utilitiesSharedData.MainCharObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        mainCharEquipOutfitSpriteRenderer = _utilitiesSharedData.MainCharObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        enemySpriteRenderer = _utilitiesSharedData.EnemyMonsterObject.GetComponent<SpriteRenderer>();

        mainCharSpriteRenderer.flipX = true;
        mainCharEquipWeaponSpriteRenderer.flipX = true;
        mainCharEquipOutfitSpriteRenderer.flipX = true;
    }

    public override void getCalledUpdate() {
        
    }

    public override void getCalledStop() {
        Musics.singleton.AudioSource.clip = Musics.singleton._Musics[0];
        Musics.singleton.AudioSource.Play();

        _utilitiesSharedData.BackgroundSpriteRenderer.sprite = _attackSelectionUtility.Background;
        _utilitiesSharedData.EnemyMonsterObject.SetActive(false);
        _utilitiesSharedData.MainCharObject.SetActive(false);
        _utilitiesSharedData.ShortcutObject.SetActive(true);
        startFight = false;

        mainCharSpriteRenderer.color = Color.white;
        mainCharEquipWeaponSpriteRenderer.color = Color.white;
        mainCharEquipOutfitSpriteRenderer.color = Color.white;
        enemySpriteRenderer.color = Color.white;

        _attackSelectionUtility.getCalledStart();
        mainCharSpriteRenderer.flipX = false;
        mainCharEquipWeaponSpriteRenderer.flipX = false;
        mainCharEquipOutfitSpriteRenderer.flipX = false;
    }

    private void launchAttack(CharacterProperties attacker, CharacterProperties defender) {
        float randomDodgeChance = Random.Range(1f, 1000f);
        if (randomDodgeChance <= defender.Agility) {
            characterDodgeAttack(defender);
        } else {
            defender.Health -= ((attacker.AttackDmg - defender.Defense > 0) ?
                attacker.AttackDmg - defender.Defense : 1);
            Debug.Log("DefenderHealth: " + defender.Health);
            if (defender.Health <= 0) {
                defender.resetProperties();
                getCalledStop();
            }
        }
    }

    private void characterDodgeAttack(CharacterProperties characterProperties) {
        Debug.Log(characterProperties.gameObject.name + " dodged!");
    }
}
