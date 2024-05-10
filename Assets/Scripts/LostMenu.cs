using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour, IGameObserver
{

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        
        gameObject.SetActive(false);
    }

    public void OnPlayerFell()
    {
        gameObject.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
