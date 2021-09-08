using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Player's control
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private RigidBody2D rigidBody2D;
    private int score; 

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<RigidBody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get current racket's speed
        Vector2 velocity = rigidBody2D.velocity;

        // If player press upButton, give positive speed to the top
        if(Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if(Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        // If player didn't press any button
        else
        {
            velocity.y = 0.0f;
        }
        rigidBody2D.velocity = velocity;
        Vector3 position = transform.position;
 
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
 
        transform.position = position;
    }

    public void IncrementScore()
    {
        score++;
    }
    

    public void ResetScore()
    {
        score = 0;
    }
 

    public int Score
    {
        get { return score; }
    }
}
