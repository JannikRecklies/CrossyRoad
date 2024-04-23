using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas startCanvas; // Reference to the canvas containing the start screen UI

    public void GoToScene(string sceneName)
    {
        startCanvas.enabled = false;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Application has started.");

    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
