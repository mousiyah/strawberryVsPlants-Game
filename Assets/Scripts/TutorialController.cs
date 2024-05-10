using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public List<GameObject> tutorialPanels;
    GameSubject gameSubject;
    private int currentTutorialIndex = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialShown"))
        {
            PlayerMovement.isMoved = false;
            PlayerShooting.isShooted = false;
            gameObject.SetActive(true);
            ShowCurrentTutorial();
        }
        else
        {
            gameObject.SetActive(false);
        }

        gameSubject = FindObjectOfType<GameSubject>();
        
    }

    void Update()
    {
        if (currentTutorialIndex == 0 && PlayerMovement.isMoved)
        {
            //gameSubject.NotifyUnFreeze();
            ShowNextTutorial();
        }
        if (currentTutorialIndex == 1 && PlayerShooting.isShooted)
        {
            //gameSubject.NotifyUnFreeze();
            ShowNextTutorial();
        }
        if (currentTutorialIndex == 2 && Input.GetKeyDown(KeyCode.X))
        {
            //gameSubject.NotifyUnFreeze();
            ShowNextTutorial();
        }
    }

    void ShowCurrentTutorial()
    {
        for (int i = 0; i < tutorialPanels.Count; i++)
        {
            gameSubject = FindObjectOfType<GameSubject>();
            //gameSubject.NotifyFreeze();
            tutorialPanels[i].SetActive(i == currentTutorialIndex);
        }
    }

    void ShowNextTutorial()
    {
        currentTutorialIndex++;

        if (currentTutorialIndex < tutorialPanels.Count)
        {
            ShowCurrentTutorial();
        }
        else
        {
            PlayerPrefs.SetInt("TutorialShown", 1);
            gameObject.SetActive(false);
        }
    }
}
