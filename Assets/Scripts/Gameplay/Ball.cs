using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    #region Filed

    private Timer beforStart;
    private Timer die;
    private Timer speedupTimer;
    private Rigidbody2D rb2d;
    private BallDiedEvent ballDiedEvent = new BallDiedEvent();
    private BallLostEvent ballLostEvent = new BallLostEvent();
    float speedupFactor;
    
    #endregion

    #region Unity Methodes
    
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        beforStart = gameObject.AddComponent<Timer>();
        beforStart.Duration = 1;
        beforStart.Run();
        beforStart.AddTimerFinishedListener(HandelFinishedTimerBeforeStart);

        die = gameObject.AddComponent<Timer>();
        die.Duration = ConfigurationUtils.BallLifeTime;
        die.Run();
        die.AddTimerFinishedListener(HandelFinishedTimerDied);
        
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);
        EventManager.AddSpeedupEffectActivatedListener(HandleSpeedupEffectActivatedEvent);

        EventManager.AddBallDiesInvoker(this);
        EventManager.AddBallLostInvoker(this);

    }
    

    private void OnBecameInvisible()
    {
        if (!die.Finished)
        {
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                AudioManager.Play(AudioClipName.BallLost);
                ballLostEvent.Invoke();
            }
            DestroyBall();
        }
       
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") ||
            coll.gameObject.CompareTag("Block") ||
            coll.gameObject.CompareTag("Paddle"))
        {
            AudioManager.Play(AudioClipName.BallCollision);
        }
    }
    
    #endregion

    #region Public Methodes
    
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }
    
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }
    
    #endregion

    #region Private Methodes

    void StartMoving()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.SpeedupEffectSecondsLeft,
                EffectUtils.SpeedupFactor);
            force *= speedupFactor;
        }
        rb2d.AddForce(force);
    }

    void HandelFinishedTimerDied()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }
    void HandelFinishedTimerBeforeStart()
    {
        StartMoving();
        beforStart.Stop();
    }
    
    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        // speed up ball and run or add time to timer
        if (!speedupTimer.Running)
        {
            StartSpeedupEffect(duration, speedupFactor);
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }
    
    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }
    
    void HandleSpeedupTimerFinished()
    {
        speedupTimer.Stop();
        rb2d.velocity *= 1 / speedupFactor;
        AudioManager.Play(AudioClipName.SpeedupEffectDeactivated);
    }
    
    void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        Destroy(gameObject);
    }
    
    #endregion

}
