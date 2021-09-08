using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;
    public float constSpeed = 10f;

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);
        if(randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

  
    private void FixedUpdate()
    {
        if(rigidBody2D.velocity.magnitude != constSpeed)
        {

            rigidBody2D.velocity = rigidBody2D.velocity.normalized * constSpeed;
        }
    }
}
