using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "Item/Weapon/Gun")]
public class GunData : WeaponData
{

    [Header("Ammo Settings")]
    public bool infiniteAmmo;
    public bool infiniteReload;
    [Min(1)] public int maxLoadedAmmo;
    [Min(1)] public int maxStoredAmmo;
    [Min(0)] public float reloadTime;
    [HideInInspector] public int currentLoadedAmmo;
    [HideInInspector] public int currentStoredAmmo;

    [Header("Prefabs")]
    public GameObject projectile;
    public GameObject muzzleFlash;

}