using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    GameSession gameSession;

    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = gameSession.CurrentScore.ToString();
    }

    public void AddToScore()
    {
        gameSession.CurrentScore += gameSession.PointsPerBlock;
        DisplayScore();
    }
}
