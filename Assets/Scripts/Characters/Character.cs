using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharController))]
public class Character : MonoBehaviour
{

    public CharacterStats characterStats;
    private CharController characterController;

    public event Action deathEvent;
    public UnityEvent onTakeDamage;
    private void Awake()
    {
        FindObjectOfType<Cinemachine.CinemachineTargetGroup>().AddMember(transform, 1, 1);

        characterStats = Instantiate(characterStats);
        characterController = gameObject.GetComponent<CharController>();
    }

    private void Start()
    {
        characterStats.characterController = characterController;
    }

    public void Die()
    {
        deathEvent?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        characterStats.health -= damage;
        onTakeDamage.Invoke();

        if (characterStats.health <= 0)
        {
            Die();
        }
    }

}
