using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed = 100f;
    public float lifeTime = 1;
    public int bounces = 0;
    public GameObject hitParticle;

    [HideInInspector]
    public float damage = 0f;
    private HashSet<GameObject> damaged = new HashSet<GameObject>();

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        // Rotate projectile towards movement direction
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        // Destroy projectile after certain time
        if (bounces <= 0)
        {
            Destroy(gameObject, lifeTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damaged.Contains(collision.gameObject)) return;
        
        /*
        // Inflict damage to character
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            character.TakeDamage(damage);
            Destroy(gameObject);
        }
        */

        if (bounces <= 0)
        {
            // Spawn hit particle in alignment with normal
            ContactPoint2D contact = collision.contacts[0];
            float angle = Mathf.Atan2(contact.normal.y, contact.normal.x) * Mathf.Rad2Deg - 90;
            if (hitParticle != null) SpawnParticle(hitParticle, contact.point, angle);
            Destroy(gameObject);
        }
        else
        {
            bounces--;
        }

        damaged.Add(collision.gameObject);
    }

    void SpawnParticle(GameObject hitParticle, Vector3 position, float angle)
    {
        Instantiate(hitParticle, position, Quaternion.Euler(0, 0, angle));
    }

}
