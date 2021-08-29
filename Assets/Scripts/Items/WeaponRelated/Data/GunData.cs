using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "Item/Weapon/Gun")]
public class GunData : WeaponData
{

    [Header("Ammo Settings")]
    public bool infiniteAmmo;
    public bool infiniteReload;
    [Min(0)] public int maxLoadedAmmo;
    [Min(0)] public int maxStoredAmmo;
    [Min(0)] public float reloadTime;
    [HideInInspector] public int currentLoadedAmmo;
    [HideInInspector] public int currentStoredAmmo;

    [Header("Bullet Spread Settings")]
    [Min(0)] public float spread;

    [Header("Prefabs")]
    public GameObject projectile;
    public GameObject muzzleFlash;

}