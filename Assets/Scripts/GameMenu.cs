using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
        SceneManager.LoadScene("Menu");
    }

    public void ResetTutorial()
    {
        if (PlayerPrefs.HasKey("TutorialShown"))
        {
            PlayerPrefs.DeleteKey("TutorialShown");
        }
        SceneManager.LoadScene("Menu");
    }
}
