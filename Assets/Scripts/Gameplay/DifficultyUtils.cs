using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DifficultyUtils 
{
    #region Fields
    
    static Difficulty difficulty;
    
    #endregion
    
    #region Properties
    
    public static float BallImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardImpulseForce;
                default:
                    return ConfigurationUtils.EasyImpulseForce;
            }
        }
    }
    
    public static float MinimumSpawnTime
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawnSeconds;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawnSeconds;
                default:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
            }
        }
    }
    
    public static float MaximumSpawnTime
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawnSeconds;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardImpulseForce;
                default:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
            }
        }
    }
    
    #endregion
    
    #region Methods
    
    public static void Initialize()
    {
        EventManager.AddGameStartedEventListener(HandleGameStartedEvent);
    }
    
    static void HandleGameStartedEvent(Difficulty difficultye)
    {
        difficulty = difficultye;
        SceneManager.LoadScene("GamePlay");
        
    }
    
    #endregion
    

}
