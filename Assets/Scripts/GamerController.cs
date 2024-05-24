using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalization.Scripts;

public class GamerController : MonoBehaviour
{
    //[SerializeField] private GameStartScreen gameStartScreen;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameOverScreen gameOverScreen;

    private bool gameRunning = false;

    private void Start()
    {
        LocalizationManager.Read(); // Load localization data
        gameRunning = true;
        GameEvents.OnPlayerDied += ShowGameOverScreen;
    }

    private void Update() {
        if (gameRunning && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))) {
            pauseMenu.PauseGame();
        }
    }

    private void ShowGameOverScreen(int score) {
        gameRunning = false;
        gameOverScreen.SetUp(score);
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerDied -= ShowGameOverScreen;
    }
}
