using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static float currentVelocity = 0f;

    public float cameraShakeVelocityStart = 8f;
    public float cameraShakeVelocityEnd = 12f;

    public float maxShakeAmount = 1f;

    private Vector3 originalCamPos;

    private static float cameraShakeEndTime = 0f;
    private static float cameraShakeAmount = 0f;

    private void Start()
    {
        originalCamPos = transform.position;
    }

    private void doShake()
    {
        transform.position = originalCamPos + Random.insideUnitSphere * (cameraShakeAmount);
    }

    public static void Shake(float length, float strength)
    {
        cameraShakeEndTime = Time.time + length;
        cameraShakeAmount = strength;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time <= cameraShakeEndTime)
        {
            this.doShake();
            return;
        }
        else
            transform.position = originalCamPos;

        var shakePercent = Mathf.InverseLerp(cameraShakeVelocityStart, cameraShakeVelocityEnd, currentVelocity);

        if(shakePercent <= 0f)
            return;

        transform.position = originalCamPos + Random.insideUnitSphere * (maxShakeAmount * shakePercent);
    }
}
