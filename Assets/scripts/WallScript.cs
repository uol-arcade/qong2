using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Vector3 originalPosition;
    private float hitTime = -5000;

    public float lerpTime;
    public float offsetDist;
    public Vector3 offsetDir;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    public void Update()
    {
        if(Time.time <= (hitTime + lerpTime))
        {
            var percent = Mathf.InverseLerp(hitTime, hitTime + lerpTime, Time.time);
            var offsetPosition = originalPosition + offsetDir.normalized * offsetDist;

            transform.position = Vector3.Lerp(offsetPosition, originalPosition, percent);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        hitTime = Time.time;
    }
}
