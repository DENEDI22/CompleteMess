using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharController : MonoBehaviour
{

    Rigidbody rb;

    [Header("Movement")]
    public float speed = 10f;

    Animator animator;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //animator = graphics.GetComponent<Animator>();
    }

    private void Update()
    {
        //if (animator != null) animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void Move(Vector3 direction, float amount)
    {
        rb.velocity = direction * amount;
    }

}