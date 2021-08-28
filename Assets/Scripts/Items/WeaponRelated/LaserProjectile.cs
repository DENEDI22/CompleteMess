using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : Projectile
{

    [Header("Laser Settings")]
    public float length;
    public float startWidth;
    public float endWidth;
    public Material material;
    public Gradient colorGradient;

    private int currentBounces = 0;
    [HideInInspector]
    public float damageRate;
    private float timeToAttack = 0;

    private LineRenderer laser;
    private List<Vector3> laserIndicies = new List<Vector3>();


    private void Awake()
    {
        laser = (LineRenderer)gameObject.AddComponent(typeof(LineRenderer));
        laser.startWidth = startWidth;
        laser.endWidth = endWidth;
        laser.material = material;
        laser.colorGradient = colorGradient;
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        UpdateLaser();
    }

    public void UpdateLaser()
    {
        laserIndicies = new List<Vector3>();
        currentBounces = 0;

        CastRay(transform.position, transform.forward, length, laser);
    }

    private void UpdatePoints()
    {
        laser.positionCount = laserIndicies.Count;
        laser.SetPositions(laserIndicies.ToArray());
    }

    private void CastRay(Vector3 position, Vector3 direction, float length, LineRenderer laser)
    {
        laserIndicies.Add(position);

        Ray ray = new Ray(position, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, length))
        {
            CheckHit(hit, direction, laser);
        }
        else
        {
            laserIndicies.Add(ray.GetPoint(length));
            UpdatePoints();
        }
    }

    private void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.CompareTag("Obstacle") && currentBounces < bounces)
        {
            currentBounces++;
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, length, laser);
        }
        else
        {
            Character hitCharacter = hitInfo.collider.GetComponent<Character>();

            if (hitCharacter != null)
            {
                if (Time.time >= timeToAttack)
                {
                    hitCharacter.TakeDamage(damage);

                    timeToAttack = Time.time + 1 / damageRate;
                }
            }

            laserIndicies.Add(hitInfo.point);
            UpdatePoints();
        }
    }

}
