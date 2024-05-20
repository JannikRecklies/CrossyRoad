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
        Debug.Log("nksfnsdnfskndf");
    }

    public void QuitGame()
    {
        Debug.Log("lksfnsfnsldf");
        Application.Quit();
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
        Debug.Log("lksfnsfnsldf");
    }
    
}
