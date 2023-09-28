using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    
    void Start()
    {
        // add listener to event manager
        EventManager.AddLastBallLostListener(HandleLastBallLost);
        EventManager.AddBlockDestroyedListener(HandleBlockDestroyed);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            AudioManager.Play(AudioClipName.MenuButtonClick);
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
    
    void HandleLastBallLost()
    {
        AudioManager.Play(AudioClipName.GameLost);
        EndGame();
    }
    
    void HandleBlockDestroyed()
    {
        // check for 1 because the last block still exists in the scene
        // when it invokes the event
        if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            EndGame();
        }
    }
    
    void EndGame()
    {
        // instantiate prefab and set score
        GameObject gameOverMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
        GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
        GameObject hud = GameObject.FindGameObjectWithTag("HUD");
        HUD hudScript = hud.GetComponent<HUD>(); 
        gameOverMessageScript.SetScore(hudScript.Score);
    }
}
