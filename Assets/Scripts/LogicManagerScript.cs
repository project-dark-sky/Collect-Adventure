using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Script represents the controller for the logic ui

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField]
    private int playerScore = 0;

    [SerializeField]
    private Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score:" + playerScore.ToString();
        Debug.Log(scoreText);
    }
}
