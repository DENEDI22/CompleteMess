using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : Projectile
{

    private LaserBeam beam;

    [Header("Laser Settings")]
    [SerializeField]
    private LaserBeamSettings settings;


    private void Start()
    {
        beam = new LaserBeam(gameObject, gameObject.transform.position, gameObject.transform.forward, settings);
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        beam.UpdateLaser();
    }

}
