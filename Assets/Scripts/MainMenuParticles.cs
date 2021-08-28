using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuParticles : MonoBehaviour
{

    [SerializeField]
    GameObject particle;
    [SerializeField]
    private Vector2 spawnDistance;
    [SerializeField]
    private float spawnRate;

    private void Awake()
    {
        spawnRate = 1 / spawnRate;
    }

    private void Start()
    {
        StartCoroutine(SpawnParticles(particle, spawnDistance, spawnRate));
    }

    private IEnumerator SpawnParticles(GameObject particle, Vector2 spawnDistance, float spawnRate)
    {
        while (true)
        {
            Vector2 spawnPosition = Random.insideUnitCircle * spawnDistance;

            Instantiate(particle, transform.position + new Vector3(spawnPosition.x, spawnPosition.y, 0), transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }
    }

}
