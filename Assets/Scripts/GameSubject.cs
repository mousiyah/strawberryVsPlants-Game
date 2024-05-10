using UnityEngine;
using System.Collections.Generic;
public class GameSubject : MonoBehaviour
{
    private readonly List<IGameObserver> observers = new();

    public void AddObserver(IGameObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IGameObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyPlayerFell()
    {
        foreach (var observer in observers)
        {
            observer.OnPlayerFell();
        }
    }

    public void NotifyFreeze()
    {
        foreach (var observer in observers)
        {
            observer.OnFreeze();
        }
    }

    public void NotifyUnFreeze()
    {
        foreach (var observer in observers)
        {
            observer.OnUnFreeze();
        }
    }

    
}
