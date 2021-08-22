using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Weapon : MonoBehaviour
{

    public WeaponData data;

    private float timeToAttack { get; set; } = 0f;

    [HideInInspector] public bool shouldAttack = false;

    [Header("Prefabs")] public Transform attackPoint;
    
    
    protected void Awake()
    {
        data = Instantiate(data);

        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    public void Attack()
    {
        if (shouldAttack && Time.time >= timeToAttack)
        {
            switch (data.attackMode)
            {
                case AttackMode.Single:
                    SingleAttack();
                    shouldAttack = false;
                    break;

                case AttackMode.Burst:
                    StartCoroutine(BurstAttack(data.burstAmount, data.burstTimeBetweenShots));
                    shouldAttack = false;
                    break;

                case AttackMode.Continuous:
                    SingleAttack();
                    break;
            }

            timeToAttack = Time.time + 1 / data.attackRate;
        }
    }
    
    private IEnumerator BurstAttack(int burstTimes, float timeBetweenShots)
    {
        for (int i = 0; i < burstTimes; i++)
        {
            SingleAttack();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    protected abstract void SingleAttack();
    
}

public enum AttackMode { Single, Burst, Continuous }