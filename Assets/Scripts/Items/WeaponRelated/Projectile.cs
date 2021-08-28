using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{

    public float lifeTime = 1;
    public int bounces = 0;
    public GameObject hitParticle;

    [HideInInspector]
    public float damage = 0f;
    //private HashSet<GameObject> damaged = new HashSet<GameObject>();


    protected void SpawnParticle(GameObject hitParticle, Vector3 position, Vector3 direction)
    {
        Instantiate(hitParticle, position, Quaternion.FromToRotation(hitParticle.transform.forward, direction));
    }

}
