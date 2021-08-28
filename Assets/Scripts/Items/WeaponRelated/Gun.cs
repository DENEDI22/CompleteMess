using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    [HideInInspector] public GunData gunData;

    private bool isReloading;


    private new void Awake()
    {
        base.Awake();

        data.weaponType = WeaponType.Gun;

        if (data is GunData)
        {
            gunData = (GunData)data;
        }
    }

    private void Start()
    {
        // Spawn gun with full ammo
        gunData.currentLoadedAmmo = gunData.maxLoadedAmmo;
        gunData.currentStoredAmmo = gunData.maxStoredAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    protected override void SingleAttack()
    {
        if (gunData.currentLoadedAmmo > 0 && !isReloading)
        {
            //AudioManager.instance.Play(gunData.sounds);

            // Bullet Spread
            Vector3 deviation = Random.insideUnitCircle.normalized * gunData.spread;
            Vector3 bulletDirection = attackPoint.transform.eulerAngles + deviation;

            SpawnProjectile(gunData.projectile, attackPoint.position, bulletDirection);
            SpawnMuzzleFlash(gunData.muzzleFlash, attackPoint.position, attackPoint.transform.eulerAngles);

            CameraShake.Instance.ShakeCamera(data.intensity, data.duration);

            if (!gunData.infiniteAmmo) gunData.currentLoadedAmmo--;
        }
        else
        {
            //AudioManager.instance.Play("Empty");
        }
    }

    private void SpawnProjectile(GameObject projectile, Vector3 position, Vector3 direction)
    {
        GameObject p = Instantiate(projectile, position, Quaternion.Euler(direction));
        p.GetComponent<Projectile>().damage = gunData.damage;
    }

    private void SpawnMuzzleFlash(GameObject muzzleFlash, Vector3 position, Vector3 rotation)
    {
        GameObject instance = Instantiate(muzzleFlash, position, Quaternion.Euler(rotation), attackPoint);
        float size = Random.Range(0.6f, 1f);
        instance.transform.localScale *= size;
        Destroy(instance, 0.025f); // Destroy after 0.025 seconds
    }

    public void Reload()
    {
        if (gunData.currentLoadedAmmo < gunData.maxLoadedAmmo && gunData.currentStoredAmmo > 0)
        {
            StartCoroutine(ReloadIE());
        }
    }

    private IEnumerator ReloadIE()
    {
        isReloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        if (gunData.infiniteReload)
        {
            gunData.currentLoadedAmmo = gunData.maxLoadedAmmo;
        }
        else
        {
            // Only use available ammo
            int neededAmmo = gunData.maxLoadedAmmo - gunData.currentLoadedAmmo;
            int availableAmmo = gunData.currentStoredAmmo - neededAmmo <= 0 ? gunData.currentStoredAmmo : neededAmmo;
            gunData.currentLoadedAmmo += availableAmmo;
            gunData.currentStoredAmmo -= availableAmmo;
        }

        isReloading = false;
    }
}
