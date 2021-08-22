using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharController))]
public class Character : MonoBehaviour
{

    public CharacterStats characterStats;
    private CharController characterController;

    public int fallBoundary = -20;

    public event Action deathEvent;


    private void Awake()
    {
        characterStats = Instantiate(characterStats);
        characterController = gameObject.GetComponent<CharController>();
    }

    private void Start()
    {
        characterStats.characterController = characterController;
    }

    private void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            TakeDamage(float.MaxValue);
        }
    }

    public void Die()
    {
        deathEvent?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        characterStats.health -= damage;

        if (characterStats.health <= 0)
        {
            Die();
        }
    }

}
