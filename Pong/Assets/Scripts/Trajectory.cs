using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public BallController ball;
    CircleCollider2D ballCollider;
    Rigidbody2D ballRigidBody;

    public GameObject ballAtCollision;


    private void Start()
    {
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        bool drawBallAtCollision = false;
        Vector2 offsetHitPoint = new Vector2();

        RaycastHit2D[] circleCastHit2DArray = Physics2D.CircleCastAll(ballRigidBody.position, ballCollider.radius, ballRigidBody.velocity.normalized);

        foreach (RaycastHit2D circleCastHit2D in circleCastHit2DArray)
        {
            if (circleCastHit2D.collider != null && circleCastHit2D.collider.GetComponent<BallController>() == null)
            {
                Vector2 hitPoint = circleCastHit2D.point;
                Vector2 hitNormal = circleCastHit2D.normal;

                offsetHitPoint = hitPoint + hitNormal * ballCollider.radius;
                DottedLine.DottedLine.Instance.DrawDottedLine(ball.transform.position, offsetHitPoint);

                if (circleCastHit2D.collider.GetComponent<SideWall>() == null)
                {
                    Vector2 inVector = (offsetHitPoint - ball.TrajectoryOrigin).normalized;
                    Vector2 outVector = Vector2.Reflect(inVector, hitNormal);

                    float outDot = Vector2.Dot(outVector, hitNormal);
                    if (outDot > -1.0f && outDot < 1.0)
                    {
                        DottedLine.DottedLine.Instance.DrawDottedLine(offsetHitPoint, offsetHitPoint + outVector * 10.0f);
                        drawBallAtCollision = true;
                    }
                }

                break;
            }
        }
        if (drawBallAtCollision)
        {
            ballAtCollision.transform.position = offsetHitPoint;
            ballAtCollision.SetActive(true);
        }
        else
        {
            ballAtCollision.SetActive(false);
        }
    }

}
