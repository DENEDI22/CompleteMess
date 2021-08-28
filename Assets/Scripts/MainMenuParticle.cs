using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuParticle : MonoBehaviour
{

    [SerializeField]
    private float velocity = 100f;
    [SerializeField]
    private float lifeTime = 5f;


    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    private void FixedUpdate()
    {
        transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * velocity * Time.fixedDeltaTime);
    }

}
