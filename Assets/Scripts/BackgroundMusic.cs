using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance { get; private set; }
    public AudioClip backgroundClip;

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

    void Start()
    {
        // Check if the AudioSource already exists
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If not, add a new AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
