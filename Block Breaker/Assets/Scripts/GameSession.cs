using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 10;
    public int PointsPerBlock
    {
        get { return pointsPerBlock; }
    }
    [SerializeField] bool autoplay;

    // State
    [SerializeField] int currentScore = 0;
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return autoplay;
    }
}
