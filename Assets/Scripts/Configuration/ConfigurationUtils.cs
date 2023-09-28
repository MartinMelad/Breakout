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
        get { return DifficultyUtils.BallImpulseForce; } 
    }
    public static float BallLifeTime
    {
        get { return configurationData.BallLifeSeconds; } 
    }

    public static float MinimumSpawnTime
    {
        get { return DifficultyUtils.MinimumSpawnTime; }
    }
    public static float MaximumSpawnTime
    {
        get { return DifficultyUtils.MaximumSpawnTime; } 
    }

    public static int NumberOfBallPerGame
    {
        get { return configurationData.NumberOfBallParGame; }
    }
    
    public static int BonusBlock
    {
        get { return configurationData.BonusBlock; }
    }
    
    public static int EffectBlock
    {
        get { return configurationData.EffectBlock; }
    }
    
    public static float StandardBlockProbability
    {
        get { return configurationData.StandardBlockProbability; }
    }
    
    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability; }
    }
    
    public static float FreezerBlockProbability
    {
        get { return configurationData.FreezerBlockProbability; }
    }
    
    public static float SpeedupBlockProbability
    {
        get { return configurationData.SpeedupBlockProbability; }
    }
    
    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }
    
    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }
    
    public static float SpeedupEffectForce
    {
        get { return configurationData.SpeedupEffectForce; }
    }
    
    public static float EasyImpulseForce
    {
        get { return configurationData.EasyImpulseForce; }
    }
    
    public static float EasyMinSpawnSeconds
    {
        get { return configurationData.EasyMinSpawnSeconds; }
    }
    
    public static float EasyMaxSpawnSeconds
    {
        get { return configurationData.EasyMaxSpawnSeconds; }
    }
    
    public static float MediumImpulseForce
    {
        get { return configurationData.MediumImpulseForce; }
    }
    
    public static float MediumMinSpawnSeconds
    {
        get { return configurationData.MediumMinSpawnSeconds; }
    }
    
    public static float MediumMaxSpawnSeconds
    {
        get { return configurationData.MediumMaxSpawnSeconds; }
    }
    
    public static float HardImpulseForce
    {
        get { return configurationData.HardImpulseForce; }
    }
    
    public static float HardMinSpawnSeconds
    {
        get { return configurationData.HardMinSpawnSeconds; }
    }
    
    public static float HardMaxSpawnSeconds
    {
        get { return configurationData.HardMaxSpawnSeconds; }
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
