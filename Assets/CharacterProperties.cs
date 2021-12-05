using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int agility;
    [SerializeField] private int attackDmg;
    [SerializeField] private int defense;

    public int Health
    {
        get => health;
        set => health = value;
    }

    public int Agility
    {
        get => agility;
        set => agility = value;
    }

    public int AttackDmg
    {
        get => attackDmg;
        set => attackDmg = value;
    }

    public int Defense
    {
        get => defense;
        set => defense = value;
    }
}
