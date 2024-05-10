using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; }

    public bool soundEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableSound()
    {
        soundEnabled = true;
        AudioListener.volume = 1f;
    }

    public void DisableSound()
    {
        soundEnabled = false;
        AudioListener.volume = 0f;
    }

    public void ToggleSound()
    {
        if (soundEnabled)
        {
            DisableSound();
        }
        else
        {
            EnableSound();
        }
    }
}
