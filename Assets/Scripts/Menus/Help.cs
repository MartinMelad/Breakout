using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 0;
    }
    
    public void HandelBackButton()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
