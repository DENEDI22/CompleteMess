using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMeleeWeaponData", menuName = "Item/Weapon/MeleeWeapon")]
public class MeleeData : WeaponData
{

    [Header("Attack Settings")] public float attackRange;

}
