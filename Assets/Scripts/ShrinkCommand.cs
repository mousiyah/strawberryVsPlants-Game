using UnityEngine;

public class ShrinkCommand : ICommand
{
    private Transform transform;
    private float shrinkRate;

    public ShrinkCommand(Transform transform, float shrinkRate)
    {
        this.transform = transform;
        this.shrinkRate = shrinkRate;
    }

    public void Execute()
    {
        Vector3 newScale = transform.localScale * shrinkRate;
        transform.localScale = newScale;
    }
}
