using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StandardBlock : MonoBehaviour
{
    #region Filed

    private int numberOfCollision = 2;
    private int point = 3;

    #endregion

    #region Unity Mthodes

    void Start()
    {
        int randomSprite = Random.Range(21, 23);
        if (randomSprite == 22)
        {
            numberOfCollision = 1;
            point = 1;
        }
        string path = "Sprites/" + Convert.ToString(randomSprite) + "-Breakout-Tiles";
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            numberOfCollision--;
            if (numberOfCollision <= 0)
            {
                HUD.AddScore(point);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/22-Breakout-Tiles");
            }
        }

    }

    #endregion

}
