using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour, IGameObserver
{
    public Rigidbody rb;
    public float moveForce = 10f;
    public static bool isMoved = false;
    private ICommand moveForwardCommand;
    private ICommand moveBackCommand;
    private ICommand moveLeftCommand;
    private ICommand moveRightCommand;
    private bool canMove = true;
    private bool isGrounded = false;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        BindMovementCommands();
    }

    public void BindMovementCommands()
    {
        moveForwardCommand = new MoveForwardCommand(rb, moveForce);
        moveBackCommand = new MoveBackCommand(rb, moveForce);
        moveLeftCommand = new MoveLeftCommand(rb, moveForce);
        moveRightCommand = new MoveRightCommand(rb, moveForce);
    }

    public void MoveForward()
    {
        if (canMove)
        {
            moveForwardCommand.Execute();
            isMoved = true;
        }
    }

    public void MoveBack()
    {
        if (canMove)
        {
            moveBackCommand.Execute();
            isMoved = true;
        }
    }

    public void MoveLeft()
    {
        if (canMove)
        {
            moveLeftCommand.Execute();
            isMoved = true;
        }
    }

    public void MoveRight()
    {
        if (canMove)
        {
            moveRightCommand.Execute();
            isMoved = true;
        }
    }


    public void OnPlayerFell()
    {
        canMove = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
