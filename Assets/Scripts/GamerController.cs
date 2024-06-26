using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour
{
    //[SerializeField] private GameStartScreen gameStartScreen;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameOverScreen gameOverScreen;

    private bool gameRunning = false;

    private void Start()
    {
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
        StartCoroutine(WaitAndShowGameOverScreen(score));
    }

    private IEnumerator WaitAndShowGameOverScreen(int score)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.5f);

        gameOverScreen.SetUp(score);
    }


    private void OnDestroy()
    {
        GameEvents.OnPlayerDied -= ShowGameOverScreen;
    }
}
