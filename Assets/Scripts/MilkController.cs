using UnityEditor;
using UnityEngine;

public class MilkController : ItemController
{
    public float growthRate = 1.2f;
    private ICommand growCommand;
    public override void OnCollisionWithPlayer()
    {
        growCommand = new GrowCommand(player.transform, growthRate);
        growCommand.Execute();
        Debug.Log("Milk");
    }
}
