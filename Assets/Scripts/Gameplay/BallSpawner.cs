using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPerfab;
    
    private Timer spawnTimer;
    
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration =
            Random.Range(ConfigurationUtils.MinimumSpawnTime, ConfigurationUtils.MaximumSpawnTime + 1);
        spawnTimer.Run();
        SpawnBall();
        
        GameObject tempBall = Instantiate<GameObject>(ballPerfab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
        
        EventManager.AddBallDiesListener(SpawnBall);
        EventManager.AddBallLostListener(SpawnBall);
        spawnTimer.AddTimerFinishedListener(HandelSpawnTimerFinished);
    }

    // Update is called once per frame
    void Update()
    {
        // if (spawnTimer.Finished)
        // {
        //     SpawnBall();
        //     spawnTimer.Duration =
        //         Random.Range(ConfigurationUtils.MinimumSpawnTime, ConfigurationUtils.MaximumSpawnTime + 1);
        //     spawnTimer.Run();
        // }
        
        if (retrySpawn)
        {
            SpawnBall();
        }
    }


    void HandelSpawnTimerFinished()
    {
        SpawnBall();
        spawnTimer.Duration =
            Random.Range(ConfigurationUtils.MinimumSpawnTime, ConfigurationUtils.MaximumSpawnTime + 1);
        spawnTimer.Run();
    }
    void SpawnBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(ballPerfab);
            AudioManager.Play(AudioClipName.BallSpawn);
            
        }
        else
        {
            retrySpawn = true;
        }
    }
}
