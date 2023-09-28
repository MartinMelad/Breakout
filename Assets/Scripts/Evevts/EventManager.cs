using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Filed

    private static List<Ball> ballDiedInvokers = new List<Ball>();
    private static List<UnityAction> ballDiedListener = new List<UnityAction>();
    
    private static List<Ball> ballLostInvokers = new List<Ball>();
    private static List<UnityAction> ballLostListener = new List<UnityAction>();
    
    private static List<StandardBlock> addPointsInvokers = new List<StandardBlock>();
    private static List<UnityAction<int>> addPointsListener = new List<UnityAction<int>>();
    
    private static List<EffectBlock> freezerEffectActivatedInvoker = new List<EffectBlock>();
    private static List<UnityAction<float>> freezerEffectActivatedListener = new List<UnityAction<float>>();
    
    private static List<EffectBlock> speedupEffectActivatedInvoker = new List<EffectBlock>();
    private static List<UnityAction<float,float>> speedupEffectActivatedListener = new List<UnityAction<float, float>>();
    
    private static List<DifficultyMenu> gameStartedEventInvoker = new List<DifficultyMenu>();
    private static List<UnityAction<Difficulty>> gameStartedEventistener = new List<UnityAction<Difficulty>>();
    
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners =
        new List<UnityAction>();

    // block destroyed support
    static List<StandardBlock> blockDestroyedInvokers = new List<StandardBlock>();
    static List<UnityAction> blockDestroyedListeners =
        new List<UnityAction>();
    

    #endregion

    #region Ball Died 

    public static void AddBallDiesInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListener )
        {
            invoker.AddBallDiedListener(listener);
        }
    }
    
    public static void AddBallDiesListener(UnityAction listener)
    {
        ballDiedListener.Add(listener);
        foreach (Ball invoker in ballDiedInvokers )
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }

    #endregion
    
    #region Ball Lost

    public static void AddBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Add(invoker);
        foreach (UnityAction listener in ballLostListener )
        {
            invoker.AddBallLostListener(listener);
        }
    }
    
    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListener.Add(listener);
        foreach (Ball invoker in ballLostInvokers )
        {
            invoker.AddBallLostListener(listener);
        }
    }

    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }

    #endregion

    #region Add Points

    public static void AddAddPointsInvoker(StandardBlock invoker)
    {
        addPointsInvokers.Add(invoker);
        foreach (UnityAction<int> listener in addPointsListener )
        {
            invoker.AddAddPointsListener(listener);
        }
    }
    
    public static void AddAddPointsListener(UnityAction<int> listener)
    {
        addPointsListener.Add(listener);
        foreach (StandardBlock invoker in addPointsInvokers )
        {
            invoker.AddAddPointsListener(listener);
        }
    }

    public static void RemoveAddPointsInvoker(StandardBlock invoker)
    {
        addPointsInvokers.Remove(invoker);
    }

    #endregion

    #region Freezer Effect Activated

    public static void AddFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        freezerEffectActivatedInvoker.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectActivatedListener )
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }
    
    public static void AddFreezerEffectActivatedListener(UnityAction<float> listener)
    {
        freezerEffectActivatedListener.Add(listener);
        foreach (EffectBlock invoker in freezerEffectActivatedInvoker )
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }

    public static void RemoveFreezerEffectActivatedInvoker(EffectBlock invoker)
    {
        freezerEffectActivatedInvoker.Remove(invoker);
    }
    
    #endregion

    #region Speedup Activated

    public static void AddSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        speedupEffectActivatedInvoker.Add(invoker);
        foreach (UnityAction<float,float> listener in speedupEffectActivatedListener )
        {
            invoker.AddSpeedupEffectActivatedListener(listener);
        }
    }
    
    public static void AddSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedListener.Add(listener);
        foreach (EffectBlock invoker in speedupEffectActivatedInvoker )
        {
            invoker.AddSpeedupEffectActivatedListener(listener);
        }
    }

    public static void RemoveSpeedupEffectActivatedInvoker(EffectBlock invoker)
    {
        speedupEffectActivatedInvoker.Remove(invoker);
    }

    #endregion

    #region Game Started Event
    
    public static void AddGameStartedEventInvoker(DifficultyMenu invoker)
    {
        gameStartedEventInvoker.Add(invoker);
        foreach (UnityAction<Difficulty> listener in gameStartedEventistener )
        {
            invoker.AddGameStartedEventListener(listener);
        }
    }
    
    public static void AddGameStartedEventListener(UnityAction<Difficulty> listener)
    {
        gameStartedEventistener.Add(listener);
        foreach (DifficultyMenu invoker in gameStartedEventInvoker)
        {
            invoker.AddGameStartedEventListener(listener);
        }
    }

    public static void RemoveGameStartedEventInvoker(DifficultyMenu invoker)
    {
        gameStartedEventInvoker.Remove(invoker);
    }

    #endregion
    
    #region Last ball lost support

    /// <summary>
    /// Adds the given script as a last ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a last ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    #endregion

    #region Block destroyed support

    /// <summary>
    /// Adds the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBlockDestroyedInvoker(StandardBlock invoker)
    {
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a block destroyed listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (StandardBlock invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBlockDestroyedInvoker(StandardBlock invoker)
    {
        // remove invoker from list
        blockDestroyedInvokers.Remove(invoker);
    }

    #endregion

}
