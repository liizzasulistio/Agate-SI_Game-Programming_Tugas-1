using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerControl player1;
    public PlayerControl player2;

    private Rigidbody2D player1RigidBody;
    private Rigidbody2D player2RigidBody;

    public BallControl ball;
    private Rigidbody2D ballRigidBody;
    private CircleCollider2D ballCollider;

    public int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        player1RigidBody = player1.GetComponent<Rigidbody2D>();
        player2RigidBody = player2.GetComponent<Rigidbody2D>();
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2.Score);

        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            player1.ResetScore();
            player2.ResetScore();

            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if(player1.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 2000, 1000), "PLAYER ONE WINS");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if(player2.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
