using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    private GameStartedEvent gameStartedEvent = new GameStartedEvent();

    void Start()
    {
        EventManager.AddGameStartedEventInvoker(this);
    }

    public void StartEasyGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Easy);
    }
    public void StartMediumGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Medium);
    }
    public void StartHardGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Hard);
    }
    public void AddGameStartedEventListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }
    
}
