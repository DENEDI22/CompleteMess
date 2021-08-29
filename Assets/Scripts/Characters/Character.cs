using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(CharController))]
public class Character : MonoBehaviour
{

    public CharacterStats characterStats;
    private CharController characterController;
    private HealthBar healthBar;
    public event Action deathEvent;
    public UnityEvent onTakeDamage;
    private void Awake()
    {
        FindObjectOfType<Cinemachine.CinemachineTargetGroup>().AddMember(transform, 1, 1);
        healthBar = GetComponent<HealthBar>();
        characterStats = Instantiate(characterStats);
        characterController = gameObject.GetComponent<CharController>();
    }

    private void Start()
    {
        characterStats.characterController = characterController;
        healthBar.SetMaxHealth(characterStats.health);
    }

    public void Die()
    {
        deathEvent?.Invoke();
        Destroy(characterController);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerWeaponManagement>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<CinemachineTargetGroup>().RemoveMember(transform);
        transform.position = Vector3.down * 10;
    }

    public void TakeDamage(float damage)
    {
        characterStats.health -= damage;
        onTakeDamage.Invoke();
        healthBar.SetHealth(characterStats.health);
        if (characterStats.health <= 0)
        {
            Die();
        }
    }

}
