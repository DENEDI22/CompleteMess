using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] allWeapons;
    [SerializeField] private float weaponSpawnCoolDown;

    private IEnumerator SpawnWeapon()
    {
        while (true)
        {
            Instantiate(allWeapons[Random.Range(0, allWeapons.Length)], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(weaponSpawnCoolDown);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnWeapon());
    }
}