using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraShake : MonoBehaviour
{

    public static CameraShake Instance { get; private set; }


    CinemachineVirtualCamera vCam;
    float shakeTimer;
    float shakeTimerTotal;
    float startIntensity;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin perlinNoise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlinNoise.m_AmplitudeGain = Mathf.Lerp(startIntensity, 0f, 1f - (shakeTimer / shakeTimerTotal));
        }
    }

    public void ShakeCamera(float intensity, float duration)
    {
        CinemachineBasicMultiChannelPerlin perlinNoise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlinNoise.m_AmplitudeGain = intensity;
        startIntensity = intensity;
        shakeTimerTotal = duration;
        shakeTimer = duration;
    }

}
