using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void SetUp(int score) {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        //Application.Quit();
        gameObject.SetActive(false);
        SceneManager.LoadScene("StartScreen");
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
    
}
