using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour, IGameObserver
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI oldRecordText;
    public TextMeshProUGUI newRecordTitle;
    public TextMeshProUGUI newScoreText;
    

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            highScore = 0;
        }

        newRecordTitle.enabled = false;
        oldRecordText.text = highScore.ToString();
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void OnPlayerFell()
    {
        newScoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            newRecordTitle.enabled = true;
        }
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
