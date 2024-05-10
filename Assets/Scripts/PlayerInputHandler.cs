using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public bool invoking = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            invoking = true;
            GameEventManager.Instance.InvokeNextEvent();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            invoking = false;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerMovement.MoveForward();
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerMovement.MoveBack();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerShooting.Shoot();
        }
    }
}

