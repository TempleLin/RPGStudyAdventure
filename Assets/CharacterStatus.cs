using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public int Health { get; set; } = 100;
    public int Agility { get; set; } = 1;
    public int AttackDmg { get; set; } = 5;
    public int Defense { get; set; } = 5;
}
