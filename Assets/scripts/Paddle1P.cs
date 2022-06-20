using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1P : MonoBehaviour
{
    public float minY;
    public float maxY;

    public KeyCode keycodeUp = KeyCode.UpArrow;
    public KeyCode keycodeDown = KeyCode.DownArrow;

    public float paddleMoveSpeed = 2f;

    public void OnDrawGizmos()
    {
        var p = transform.position;

        var pMin = new Vector3(p.x, minY, p.z);
        var pMax = new Vector3(p.x, maxY, p.z);

        Gizmos.DrawLine(pMin, pMax);
    }

    private void movePaddle(Vector3 direction)
    {
        var pos = transform.position;
        var projectedTranslation = pos + (direction * Time.deltaTime * paddleMoveSpeed);
        var projectedPos = projectedTranslation + (direction * (transform.localScale.y / 2));

        if(projectedPos.y <= minY || projectedPos.y >= maxY)
            return;

        transform.Translate(direction * Time.deltaTime * paddleMoveSpeed);
    }

    public void Update()
    {
        if(Input.GetKey(keycodeUp))
            this.movePaddle(Vector3.up);

        else if(Input.GetKey(keycodeDown))
            this.movePaddle(Vector3.down);
    }
}
