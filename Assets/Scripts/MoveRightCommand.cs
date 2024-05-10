using UnityEngine;
public class MoveRightCommand : ICommand
{
    private readonly Rigidbody rb;
    private readonly float moveForce;

    public MoveRightCommand(Rigidbody rb, float moveForce)
    {
        this.rb = rb;
        this.moveForce = moveForce;
    }

    public void Execute()
    {
        rb.AddForce(moveForce * Time.deltaTime * Vector3.right, ForceMode.VelocityChange);
    }
}