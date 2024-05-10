using UnityEngine;
public class MoveLeftCommand : ICommand
{
    private readonly Rigidbody rb;
    private readonly float moveForce;

    public MoveLeftCommand(Rigidbody rb, float moveForce)
    {
        this.rb = rb;
        this.moveForce = moveForce;
    }

    public void Execute()
    {
        rb.AddForce(moveForce * Time.deltaTime * Vector3.left, ForceMode.VelocityChange);
    }
}