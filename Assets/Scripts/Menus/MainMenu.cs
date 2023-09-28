using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandelQuiteButton()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
    }

    public void HandelHelpButton()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }
    
    public void GoToDifficultyMenu()
    { 
        AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Difficulty);
    }
    
}
