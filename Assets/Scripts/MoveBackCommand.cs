using UnityEngine;
public class MoveBackCommand : ICommand
{
    private readonly Rigidbody rb;
    private readonly float moveForce;

    public MoveBackCommand(Rigidbody rb, float moveForce)
    {
        this.rb = rb;
        this.moveForce = moveForce;
    }

    public void Execute()
    {
        rb.AddForce(moveForce * Time.deltaTime * Vector3.back, ForceMode.VelocityChange);
    }
}