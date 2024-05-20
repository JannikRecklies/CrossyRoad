using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void SetUp() {
        Debug.Log("Start");
        gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Debug.Log("njksnfsd");
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("Hund");
        Application.Quit();
    }
}
