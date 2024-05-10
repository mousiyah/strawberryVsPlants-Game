using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Image soundButtonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    public void Start()
    {
        if (SoundController.Instance.soundEnabled)
        {
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOffSprite;
        }
    }

    public void SoundButtonToggle()
    {
        SoundController.Instance.ToggleSound();

        if (SoundController.Instance.soundEnabled)
        {
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOffSprite;
        }
    }
}