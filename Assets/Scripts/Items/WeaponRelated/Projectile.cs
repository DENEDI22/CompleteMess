using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{

    public float lifeTime = 1f;
    public int bounces = 0;
    public GameObject hitParticle;

    [HideInInspector]
    public float damage = 0f;


    protected void SpawnParticle(GameObject hitParticle, Vector3 position, Vector3 direction)
    {
        Instantiate(hitParticle, position, Quaternion.FromToRotation(hitParticle.transform.forward, direction));
    }

}
