using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;

public class Boss
{
    // BOSS STATS
    [SerializeField] public int level;
    [SerializeField] public int bossNumber;
    [SerializeField] public string name;
    [SerializeField] public int health;
    [SerializeField] public int damage;

    public static GameObject _boss;

    public Boss(int Level, int BossNumber, string Name, int Health, int Damage)
    {
        level = Level;
        bossNumber = BossNumber;
        name = Name;
        health = Health;
        damage = Damage;
    }


}
