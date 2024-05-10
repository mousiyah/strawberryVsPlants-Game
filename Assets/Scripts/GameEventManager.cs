using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class GameEventManager : MonoBehaviour, IGameObserver
{
    public static GameEventManager Instance { get; private set; }

    private Queue<Action> eventQueue = new Queue<Action>();

    private bool canInvokeEvent = true;

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
        }
    }

    public void QueueEvent(Action _event)
    {
        if (_event != null)
        {
            eventQueue.Enqueue(_event);
        }
    }

    public void InvokeNextEvent()
    {
        if (eventQueue.Count > 0 && canInvokeEvent)
        {
            eventQueue.Peek().Invoke();
            eventQueue.Dequeue();
        } else {
            Debug.Log(" ");
        }
    
    }

    public void OnPlayerFell()
    {
        eventQueue.Clear();
    }

    public void OnFreeze()
    {
        //canInvokeEvent = false;
    }

    public void OnUnFreeze()
    {
        
    }
    
}
