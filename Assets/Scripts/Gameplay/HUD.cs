using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ballsLeftTextGameObject;
    
    const string BallsLeftPrefix = "Balls Left: ";
    static int ballsLeft = 0;
    static Text ballsLeftText;
    
    [SerializeField] private GameObject scoreTextGameObject;
    private const string scorePrefix = "Score: ";
    private static int score = 0;
    private static Text scoreText;
    
    LastBallLostEvent lastBallLostEvent = new LastBallLostEvent();
    
    #region Properties

    /// <summary>
    /// Gets the score
    /// </summary>
    public int Score
    {
        get { return score; }
    }

    #endregion
    
    void Start()
    {
        ballsLeft = ConfigurationUtils.NumberOfBallPerGame;
        ballsLeftText = ballsLeftTextGameObject.GetComponent<Text>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();

        scoreText = scoreTextGameObject.GetComponent<Text>();
        scoreText.text = scorePrefix + score.ToString();
        
        EventManager.AddBallLostListener(LoseBall);
        EventManager.AddAddPointsListener(AddScore);
        
        EventManager.AddLastBallLostInvoker(this);

    }
    
    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostEvent.AddListener(listener);
    }

    void LoseBall()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
        if (ballsLeft == 0)
        {
            lastBallLostEvent.Invoke();
        }
    }
    void AddScore(int points)
    {
        score += points ;
        scoreText.text = scorePrefix + score.ToString();
    }
}
