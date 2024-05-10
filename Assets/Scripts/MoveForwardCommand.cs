using UnityEngine;
public class MoveForwardCommand : ICommand
{
    private readonly Rigidbody rb;
    private readonly float moveForce;

    public MoveForwardCommand(Rigidbody rb, float moveForce)
    {
        this.rb = rb;
        this.moveForce = moveForce;
    }

    public void Execute()
    {
        rb.AddForce(moveForce * Time.deltaTime * Vector3.forward, ForceMode.VelocityChange);
    }
}