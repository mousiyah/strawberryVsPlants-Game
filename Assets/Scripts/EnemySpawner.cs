using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IGameObserver
{
    public GameObject enemyPrefab;
    public GameObject player;
    public float spawnInterval = 1;
    private bool canSpawnEnemies = true;
    private PlayerMovement playerMovement;
    private readonly List<GameObject> spawnedEnemies = new();

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        playerMovement = player.GetComponent<PlayerMovement>();

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (canSpawnEnemies)
        {
            if(playerMovement.IsGrounded())
            {

                Vector3 randomPosition = new(
                    player.transform.position.x + Random.Range(-5, 5),
                    player.transform.position.y,
                    player.transform.position.z + Random.Range(-5, 5)
                );

                GameObject enemyClone = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

                if (enemyClone.TryGetComponent<EnemyMovement>(out var enemyMovement))
                {
                    enemyMovement.SetPlayer(player.transform);
                }

                if (enemyClone.TryGetComponent<EnemyController>(out var enemyController))
                {
                    enemyController.SetPlayer(player.transform);
                }

                spawnedEnemies.Add(enemyClone);

                
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void OnPlayerFell()
    {
        canSpawnEnemies = false;
    }

    public void OnFreeze()
    {
        canSpawnEnemies = false;
    }

    public void OnUnFreeze()
    {
        canSpawnEnemies = true;
    }
}
