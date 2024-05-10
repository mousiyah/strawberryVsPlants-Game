using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class oldRecordText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int highScore;
    

    void Start()
    {
        updateScore();
    }

    public void updateScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            highScore = 0;
        }
        text.text = highScore.ToString();
    }
}