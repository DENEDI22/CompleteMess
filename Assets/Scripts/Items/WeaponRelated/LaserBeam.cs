using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{

    private Vector3 position;
    private Vector3 direction;
    private LaserBeamSettings settings;

    private GameObject parent;
    public LineRenderer laser;
    private List<Vector3> laserIndicies = new List<Vector3>();


    public LaserBeam(GameObject parent, Vector3 position, Vector3 direction, LaserBeamSettings settings)
    {
        this.parent = parent;
        this.position = position;
        this.direction = direction;
        this.settings = settings;

        this.laser = (LineRenderer)parent.AddComponent(typeof(LineRenderer));
        this.laser.startWidth = settings.startWidth;
        this.laser.endWidth = settings.endWidth;
        this.laser.material = settings.material;
        this.laser.colorGradient = settings.colorGradient;
    }

    public void UpdateLaser()
    {
        laserIndicies = new List<Vector3>();

        position = parent.transform.position;
        direction = parent.transform.forward;

        CastRay(position, direction, settings.length, laser);
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
        if (hitInfo.collider.CompareTag("Obstacle"))
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, settings.length, laser);
        }
        else
        {
            laserIndicies.Add(hitInfo.point);
            UpdatePoints();
        }
    }

}

[System.Serializable]
public struct LaserBeamSettings
{
    public float length;
    public float startWidth;
    public float endWidth;
    public Material material;
    public Gradient colorGradient;
}