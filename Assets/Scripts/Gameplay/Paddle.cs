using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Filed

    private Rigidbody2D rb2d;

    private float halfColliderWidth;
    
    const float BounceAngleHalfRange = 70 * Mathf.Deg2Rad;

    private bool isFrozen = false;

    private Timer freezeTimer;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth =  (GetComponent<BoxCollider2D>().size.x/2)*rb2d.transform.localScale.x;
        
        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(HandleFreezeTimerFinishedEvent);
        EventManager.AddFreezerEffectActivatedListener(HandelFreezeActivated);
    }
    
    
    private void FixedUpdate()
    {
        if (!isFrozen)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float x = CalculateClampedX(rb2d.position.x + horizontalInput *
                ConfigurationUtils.PaddleMoveUnitsPerSecond *
                Time.fixedDeltaTime);
            rb2d.MovePosition(new Vector2(x, transform.position.y));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") &&
            TopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                                               coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                                         halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            //Debug.Log(normalizedBallOffset + "   " + BounceAngleHalfRange + "  " + (angleOffset * Mathf.Rad2Deg));
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }


    #endregion

    #region Private Methods

    private float CalculateClampedX(float x)
    {
        if (x + halfColliderWidth >= ScreenUtils.ScreenRight)
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        
        if (x - halfColliderWidth <= ScreenUtils.ScreenLeft)
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        
        return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>

    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        coll.GetContacts(contacts);
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandelFreezeActivated(float duration)
    {
        isFrozen = true;
        if (!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }
    
    void HandleFreezeTimerFinishedEvent()
    {
        isFrozen = false;
        freezeTimer.Stop();
        AudioManager.Play(AudioClipName.FreezerEffectDeactivated);
    }


    #endregion
    
} 
