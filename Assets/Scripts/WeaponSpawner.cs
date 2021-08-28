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
            if (transform.childCount == 0)
            {
                Instantiate(allWeapons[Random.Range(0, allWeapons.Length)], transform);
            }
            yield return new WaitForSeconds(weaponSpawnCoolDown);
        }
        yield break;
    }

    private void Start()
    {
        StartCoroutine(SpawnWeapon());
    }
}