using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Filed

    private static ConfigurationData configurationData;
    
    #endregion
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; } 
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; } 
    }
    public static float BallLifeTime
    {
        get { return configurationData.BallLifeSeconds; } 
    }

    public static float MinimumSpawnTime
    {
        get { return configurationData.MinSpawnSeconds; }
    }
    public static float MaximumSpawnTime
    {
        get { return configurationData.MaxSpawnSeconds; } 
    }

    public static int NumberOfBallPerGame
    {
        get { return configurationData.NumberOfBallParGame; }
    }

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
