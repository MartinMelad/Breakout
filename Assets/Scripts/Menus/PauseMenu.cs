using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    
    public void HandleResumeButtonOnClickEvent()
    {
        // unpause game and destroy menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    
    public void HandleQuitButtonOnClickEvent()
    {

        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
    
}
