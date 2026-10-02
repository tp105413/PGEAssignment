using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnBackToMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
