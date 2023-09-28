using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int numberOfBallParGame = 5; 
    int bonusBlock = 2;
    int effectBlock = 5;
    float standardBlockProbability = 0.7f;
    float bonusBlockProbability = 0.2f;
    float freezerBlockProbability = 0.05f;
    float speedupBlockProbability = 0.05f; 
    float freezerEffectDuration = 2.0f;
    float speedupEffectDuration = 2.0f;
    float speedupEffectForce = 2.0f; 
    float easyImpulseForce = 300f;
    float easyMinSpawnSeconds = 5f;
    float easyMaxSpawnSeconds = 10f;
    float mediumImpulseForce = 300f;
    float mediumMinSpawnSeconds = 5f;
    float mediumMaxSpawnSeconds = 10f;
    float hardImpulseForce = 300f;
    float hardMinSpawnSeconds = 5f;
    float hardMaxSpawnSeconds = 10f;
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    public int NumberOfBallParGame
    {
        get { return numberOfBallParGame; }
    }
    
    public int BonusBlock
    {
        get { return bonusBlock; }
    }
    public int EffectBlock
    {
        get { return effectBlock; }
    }
    
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }
    
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }
    
    public float FreezerBlockProbability
    {
        get { return freezerBlockProbability; }
    }
    
    public float SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }
    
    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }
    
    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }
    
    public float SpeedupEffectForce
    {
        get { return speedupEffectForce; }
    }
    
    public float EasyImpulseForce
    {
        get { return easyImpulseForce; }
    }
    
    public float EasyMinSpawnSeconds
    {
        get { return easyMinSpawnSeconds; }
    }
    
    public float EasyMaxSpawnSeconds
    {
        get { return easyMaxSpawnSeconds; }
    }
    
    public float MediumImpulseForce
    {
        get { return mediumImpulseForce; }
    }
    
    public float MediumMinSpawnSeconds
    {
        get { return mediumMinSpawnSeconds; }
    }
    
    public float MediumMaxSpawnSeconds
    {
        get { return mediumMaxSpawnSeconds; }
    }
    
    public float HardImpulseForce
    {
        get { return hardImpulseForce; }
    }
    
    public float HardMinSpawnSeconds
    {
        get { return hardMinSpawnSeconds; }
    }
    
    public float HardMaxSpawnSeconds
    {
        get { return hardMaxSpawnSeconds; }
    }
    
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, "ConfigurationData.csv"));

            string names = input.ReadLine();
            string values = input.ReadLine();

            GetValuse(values);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.Log(e);
            throw;
        }
        finally
        {
            if (input != null)
                input.Close();
        }

    }

    #endregion

    #region privet Methodes

    private void GetValuse(string csvValuse)
    {
        string[] values = csvValuse.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        numberOfBallParGame = int.Parse(values[5]);
        bonusBlock = int.Parse(values[6]);
        effectBlock = int.Parse(values[7]);
        standardBlockProbability = float.Parse(values[8]) / 100;
        bonusBlockProbability = float.Parse(values[9]) / 100;
        freezerBlockProbability = float.Parse(values[10]) / 100;
        speedupBlockProbability = float.Parse(values[11]) / 100;
        freezerEffectDuration = float.Parse(values[12]);
        speedupEffectDuration = float.Parse(values[13]);
        speedupEffectForce = float.Parse(values[14]);
        easyImpulseForce = float.Parse(values[15]);
        easyMinSpawnSeconds = float.Parse(values[16]);
        easyMaxSpawnSeconds = float.Parse(values[17]);
        mediumImpulseForce = float.Parse(values[18]);
        mediumMinSpawnSeconds = float.Parse(values[19]);
        mediumMaxSpawnSeconds = float.Parse(values[20]);
        hardImpulseForce = float.Parse(values[21]);
        hardMinSpawnSeconds = float.Parse(values[22]);
        hardMaxSpawnSeconds = float.Parse(values[23]);
    }

    #endregion
}
