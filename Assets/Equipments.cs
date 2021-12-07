using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    WEAPON,
    OUTFIT,
    ACCESSORIES
}

[System.Serializable]
public class Equipment : MonoBehaviour {
    public string name;
    public int attackUpgrade;
    public int healthUpgrade;
    public int defenseUpgrade;
    public int agilityUpgrade;
    public Sprite sprite;
    public Equipment(string name, int attackUpgrade, int healthUpgrade, int defenseUpgrade, int agilityUpgrade, Sprite sprite) {
        this.name = name;
        this.attackUpgrade = attackUpgrade;
        this.healthUpgrade = healthUpgrade;
        this.defenseUpgrade = defenseUpgrade;
        this.agilityUpgrade = agilityUpgrade;
        this.sprite = sprite;
    }
}

public class Equipments : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites;

    public Dictionary<EquipmentType, List<Equipment>> equipmentsTypesInGame;
    public Dictionary<EquipmentType, List<Equipment>> EquipmentsTypesInGame => equipmentsTypesInGame;
    private void Start() {
        equipmentsTypesInGame = new Dictionary<EquipmentType, List<Equipment>> {
            { EquipmentType.WEAPON, new List<Equipment>{
                new Equipment("Manuvegear", 4, 0, 0, 2, sprites[0]),
            } },
            { EquipmentType.OUTFIT, new List<Equipment>() },
            { EquipmentType.ACCESSORIES, new List<Equipment>() }
        };
    }
}
