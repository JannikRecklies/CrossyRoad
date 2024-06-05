using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void SetUp(int score) {
        // Play the game over sound
        FindAnyObjectByType<AudioManager>().Play("GameOver");

        // Show the game over screen and update the score text
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
    
}
