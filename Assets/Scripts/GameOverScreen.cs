using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text points;

    private void Start()
    {
        gameObject.SetActive(false);
        GameEvents.OnPlayerDied += ShowGameOverScreen;
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerDied -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen(int score)
    {
        gameObject.SetActive(true);
        Debug.Log(score);
        //points.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
