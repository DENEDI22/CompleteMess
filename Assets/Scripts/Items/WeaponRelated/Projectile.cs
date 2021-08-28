using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    private Rigidbody rb;

    public float speed = 100f;
    public float lifeTime = 1;
    public int bounces = 0;
    public GameObject hitParticle;

    [HideInInspector]
    public float damage = 0f;
    private HashSet<GameObject> damaged = new HashSet<GameObject>();

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        // Rotate projectile towards movement direction
        Vector3 headingDir = rb.velocity.normalized;

        if (headingDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(headingDir);
        }

        // Destroy projectile after certain time
        if (bounces <= 0)
        {
            Destroy(gameObject, lifeTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null || damaged.Contains(collision.gameObject)) return;

        // Inflict damage to character
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            character.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (bounces <= 0)
        {
            // Spawn hit particle in alignment with normal
            ContactPoint contact = collision.contacts[0];
            if (hitParticle != null) SpawnParticle(hitParticle, contact.point, contact.normal);
            Destroy(gameObject);
        }
        else
        {
            bounces--;
        }

        damaged.Add(collision.gameObject);
    }

    void SpawnParticle(GameObject hitParticle, Vector3 position, Vector3 direction)
    {
        Instantiate(hitParticle, position, Quaternion.FromToRotation(hitParticle.transform.forward, direction));
    }

}
