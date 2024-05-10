using UnityEngine;

public class EnemyMovement : MonoBehaviour, IGameObserver
{
    private Transform player;
    public float moveSpeed = 4f;
    private bool canMove = true;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }

    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            transform.position += moveSpeed * Time.deltaTime * directionToPlayer;
        }
    }

    public void OnPlayerFell()
    {
        canMove = false;
    }

    public void OnFreeze()
    {
        canMove = false;
    }

    public void OnUnFreeze()
    {
        canMove = true;
    }
}
