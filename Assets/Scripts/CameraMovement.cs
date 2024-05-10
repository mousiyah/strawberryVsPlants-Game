using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour, IGameObserver
{
    public Transform player;
    public Vector3 offset = new Vector3(-13.78f, 12.6f, -13.3f);

    private bool canMove = true;

    void LateUpdate()
    {
        if (canMove)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }

    public void OnPlayerFell()
    {
        canMove = false;
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
