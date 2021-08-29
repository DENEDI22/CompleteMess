using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform m_camera;

    private void Update()
    {
        try
        {
            transform.LookAt(Camera.current.transform);
        }
        catch (Exception e)
        {

        }
    }
}
