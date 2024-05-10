using UnityEngine;

public class ClockController : ItemController, IGameObserver
{
    public float freezeTime = 3;
    public override void OnCollisionWithPlayer()
    {
        Debug.Log("Clock");
        player.GetComponent<PlayerController>().ActivateClock();
    }
}

