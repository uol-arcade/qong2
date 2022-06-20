using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntro : MonoBehaviour
{
    private float camSize = -1f;

    public AnimationCurve lerpCurve;
    public float lerpTime;

    private float startTime = -1f;

    public static bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        camSize = GetComponent<Camera>().orthographicSize;    
    }

    // Update is called once per frame
    void Update()
    {
        //Check if transition is complete
        if(Time.time > (startTime + lerpTime))
        {
            complete = true;
            return;
        }

        //Get percent
        var percent = Mathf.InverseLerp(startTime, startTime + lerpTime, Time.time);
        
        //Sample at this percent on curve
        var mappedPercent = lerpCurve.Evaluate(percent);

        //Lerp size
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(0f, camSize, mappedPercent);
        
    }
}
