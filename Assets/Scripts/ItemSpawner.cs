using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IGameObserver
{
    public List<GameObject> itemPrefabs;
    public GameObject player;
    public float spawnInterval = 1;
    private bool canSpawnItems = true;
    private PlayerMovement playerMovement;
    private readonly List<GameObject> spawnedItems = new();

    private float yAxisUpperBound = 0;
    private float yAxisLowerBound = 0;
    float yAxisPrevious;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        
        playerMovement = player.GetComponent<PlayerMovement>();

        yAxisPrevious = player.transform.position.y-10;
        StartCoroutine(SpawnItems());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnItems()
    {
        while (canSpawnItems)
        {
            yAxisLowerBound = player.transform.position.y-40;
            yAxisUpperBound = player.transform.position.y-10;

            if(yAxisPrevious > yAxisLowerBound)
            {
                float yAxisNew = UnityEngine.Random.Range(yAxisLowerBound, yAxisUpperBound);
                Vector3 randomPosition = new(
                    player.transform.position.x + UnityEngine.Random.Range(-5, 5),
                    yAxisNew,
                    player.transform.position.z + UnityEngine.Random.Range(-5, 5)
                );

                System.Random random = new System.Random();
                int randomIndex = random.Next(itemPrefabs.Count);

                if(itemPrefabs[randomIndex] != null)
                {
                    GameObject itemClone = Instantiate(itemPrefabs[randomIndex], randomPosition, Quaternion.identity);
                    spawnedItems.Add(itemClone);
                }
                yAxisPrevious = yAxisNew;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void OnPlayerFell()
    {
        canSpawnItems = false;
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
