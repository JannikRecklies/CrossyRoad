using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text points;
    // Start is called before the first frame update
    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Restart() {
        SceneManager.LoadScene("MainScene");
    }
}
