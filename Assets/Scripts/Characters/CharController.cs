using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharController : MonoBehaviour
{

    Rigidbody rb;

    [Header("Movement")]
    public float speed = 10f;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float amount)
    {
        rb.velocity = direction * amount;
    }

}