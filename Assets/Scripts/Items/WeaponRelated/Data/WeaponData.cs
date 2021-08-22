using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ItemData
{

    [HideInInspector] public WeaponType weaponType;

    [Header("Attack Settings")] [Min(0)] public float damage = 0;
    public AttackMode attackMode;
    [Min(0f)] public float attackRate = 1f;
    [Min(2)] public int burstAmount = 2;
    [Min(0)] public float burstTimeBetweenShots = 0.1f;

    private void Awake()
    {
        itemType = ItemType.Weapon;
    }

}

public enum WeaponType
{
    Gun,
    MeleeWeapon,
    Throwable
}
