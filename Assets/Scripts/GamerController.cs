using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour
{
    //[SerializeField] private GameStartScreen gameStartScreen;
    //[SerializeField] private GamePauseScreen gamePauseScreen;
    [SerializeField] private GameOverScreen gameOverScreen;

    private void Start()
    {
        GameEvents.OnPlayerDied += ShowGameOverScreen;
    }

    private void ShowGameOverScreen(int score) {
        gameOverScreen.SetUp(score);
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerDied -= ShowGameOverScreen;
    }
}
