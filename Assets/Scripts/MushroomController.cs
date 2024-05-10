using UnityEditor;
using UnityEngine;

public class MushroomController : ItemController
{
    public float shrinkRate = 0.8f;
    private ICommand shrinkCommand;
    public override void OnCollisionWithPlayer()
    {
        shrinkCommand = new ShrinkCommand(player.transform, shrinkRate);
        shrinkCommand.Execute();
        Debug.Log("Mushroom");
    }
}
