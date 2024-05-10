using UnityEngine;

public class GrowCommand : ICommand
{
    private Transform transform;
    private float growthRate;

    public GrowCommand(Transform transform, float growthRate)
    {
        this.transform = transform;
        this.growthRate = growthRate;
    }

    public void Execute()
    {
        Vector3 newScale = transform.localScale * growthRate;
        transform.localScale = newScale;
    }
}
