using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider healthBar;
    private GameSubject gameSubject;
    private bool hasFell = false;

    void Start()
    {
        gameSubject = GetComponent<GameSubject>();
    }

    void Update()
    {
        if (healthBar.value <=0)
        {
            gameSubject.NotifyPlayerFell();
            hasFell = true;
        }
    }

    public void ActivateClock()
    {
        StartCoroutine(FreezeAndUnfreeze());
    }
    
    IEnumerator FreezeAndUnfreeze()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.NotifyFreeze();

        yield return new WaitForSeconds(10);

        gameSubject.NotifyUnFreeze();
    }
}
