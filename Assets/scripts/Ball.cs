using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 1f;
    public float speedMultiplier = 1.05f;

    public float maxSpeed = 22f;

    public Transform upperWall;
    public Transform bottomWall;
    public Transform rightWall;
    
    public Transform paddle;
    public Transform paddle2;

    public float minPaddleScale = 0.5f;
    public AnimationCurve paddleScaleCurve;

    private float paddleScale = 0f;

    public GameObject wallHitObj;

    public TMPro.TMP_Text scoreText;

    public AudioSource source;
    public AudioClip clipBallHitWall;
    public AudioClip clipBallHitPaddle;

    // Start is called before the first frame update
    void Start()
    {
        paddleScale = paddle.transform.localScale.y;
    }

    private Vector3 getStartVelocity()
    {
        var returnVelocity = Vector3.up;

        var dotThreshold = 0.45f;

        while(Mathf.Abs(Vector3.Dot(returnVelocity, Vector3.up)) <= dotThreshold || Mathf.Abs(Vector3.Dot(returnVelocity, Vector3.right)) <= dotThreshold)
            returnVelocity = Random.insideUnitCircle.normalized;

        return returnVelocity * startSpeed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;
        var other = coll.transform;

        if(other == upperWall || other == bottomWall)
            currentVelocity.y = -currentVelocity.y;

        else if(other == rightWall || other == paddle || other == paddle2)
            currentVelocity.x = -currentVelocity.x;

        if(other != paddle && other != paddle2)
            source.PlayOneShot(clipBallHitWall);

        else
            source.PlayOneShot(clipBallHitPaddle);


        currentVelocity += Random.insideUnitCircle * 0.001f;
        currentVelocity *= speedMultiplier;

        if(currentVelocity.magnitude >= maxSpeed)
            currentVelocity = (currentVelocity.normalized * maxSpeed);

        var scale = paddle.transform.localScale;
        var scale2 = scale;

        if(paddle2 != null)
            scale2 = paddle2.transform.localScale;
            
        // scale.y = Mathf.Lerp(paddleScale, minPaddleScale, paddleScaleCurve.Evaluate(currentVelocity.magnitude / maxSpeed));

        if(other == paddle)
            scale.y *= paddleScaleCurve.Evaluate(currentVelocity.magnitude / maxSpeed);

        if(other == paddle2)
            scale2.y *= paddleScaleCurve.Evaluate(currentVelocity.magnitude / maxSpeed);


        scale.y = Mathf.Clamp(scale.y, minPaddleScale, Mathf.Infinity);
        scale2.y = Mathf.Clamp(scale2.y, minPaddleScale, Mathf.Infinity);
        paddle.localScale = scale;

        if(paddle2 != null)
            paddle2.localScale = scale2;
        

        var obj = GameObject.Instantiate(wallHitObj, transform.position, Quaternion.identity);

        if (other == upperWall) obj.transform.rotation = Quaternion.Euler(Vector3.forward * 180f);
        else if (other == bottomWall) obj.transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
        else if (other == paddle) obj.transform.rotation = Quaternion.Euler(Vector3.forward * -90f);
        else if (other == rightWall || other == paddle2) obj.transform.rotation = Quaternion.Euler(Vector3.forward * 90f);

        GameObject.Destroy(obj, 0.2f);

        CameraShaker.currentVelocity = currentVelocity.magnitude;

        CameraShaker.Shake(0.05f, 0.02f);

        GetComponent<Rigidbody2D>().velocity = currentVelocity;
    }

    public bool isGameOver()
    {
        if(transform.position.x < paddle.transform.position.x)
            return true;

        else if(paddle2 != null && transform.position.x > paddle2.transform.position.x)
            return true;

        return false;
    }

    private float getScore()
    {
        var vel = GetComponent<Rigidbody2D>().velocity.magnitude - startSpeed;

        var timeScore = Mathf.Floor(Time.time * 10);

        return Mathf.Floor(vel * 1000) + timeScore;
    }

    public void endGame()
    {
        EndScreen.endScore = (int)getScore();
        EndScreen.playMode = (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "singlePlayer") ? (EndScreen.PlayMode.Singleplayer) : (EndScreen.PlayMode.Multiplayer);
        StartIntro.complete = false;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("endGameScene");
    }

    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if(!started && StartIntro.complete)
        {
            started = true;

            var startVel = getStartVelocity();
            startVel.x = Mathf.Abs(startVel.x);

            GetComponent<Rigidbody2D>().velocity = startVel;
        }

        if(!started)
            return;

        scoreText.text = $"{this.getScore():N0}";

        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = Vector3.zero;

            var startVel = getStartVelocity();
            startVel.x = Mathf.Abs(startVel.x);

            GetComponent<Rigidbody2D>().velocity = startVel;
        }

        if(isGameOver())
            endGame();
    }
}
