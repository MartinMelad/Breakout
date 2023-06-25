using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    #region Filed

    private Timer beforStart;
    private Timer die;

    private Rigidbody2D rb2d;
    
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

        die = gameObject.AddComponent<Timer>();
        die.Duration = ConfigurationUtils.BallLifeTime;
        die.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (beforStart.Finished)
        {
            StartMoving();
            beforStart.Stop();
        }

        if (die.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        if (!die.Finished)
        {
            float halfColliderHeight =
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                HUD.LoseBall();
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
            }
            Destroy(gameObject);
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
    
    #endregion

    #region Private Methodes

    void StartMoving()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        rb2d.AddForce(force);
    }
    
    #endregion

}
