using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour, IGameObserver
{
    public GameObject groundPrefab;
    public float spawnInterval = 0.5f;
    private bool canSpawnGround = true;
    public float minScale = 8f;
    public float maxScale = 17f;
    public float spawnDistanceBelowPlayer = 40f;
    public float deletionDistanceAbovePlayer = 40f;
    public List<GameObject> spawnedGrounds = new List<GameObject>();
    private GameObject player;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(canSpawnGround)
        {
            SpawnGround();
            DeleteUnusedGrounds();
        }
    }

    void SpawnGround()
    {
        Vector3 spawnPosition;

        if (spawnedGrounds.Count == 0)
        {
            spawnPosition =  new Vector3(0f, 0f, 0f);
            SpawnGround(spawnPosition);
        }
        else
        {
            GameObject lastSpawnedGround = spawnedGrounds[spawnedGrounds.Count - 1];
            if(lastSpawnedGround.transform.position.y > player.transform.position.y - 40)
            {
                Vector3 previousGroundPosition = spawnedGrounds[spawnedGrounds.Count - 1].transform.position;
                float offsetX = Random.Range(-10f, 10f);
                float offsetZ = Random.Range(-10f, 10f);
                spawnPosition = previousGroundPosition - new Vector3(offsetX, 10f, offsetZ);
                SpawnGround(spawnPosition);
            }
        }
    }

    void SpawnGround(Vector3 spawnPosition)
    {
        GameObject groundClone = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        spawnedGrounds.Add(groundClone);

        float randomScale = Random.Range(minScale, maxScale);
        groundClone.transform.localScale = new Vector3(randomScale, groundClone.transform.localScale.y, randomScale);
    }

    void DeleteUnusedGrounds()
    {
        if (spawnedGrounds.Count != 0)
        {
            GameObject firstSpawnedGround = spawnedGrounds[0];
            if(firstSpawnedGround != null)
            {
                if(firstSpawnedGround.transform.position.y > player.transform.position.y + 20)
                {
                    Destroy(spawnedGrounds[0]);
                    spawnedGrounds.RemoveAt(0);
                }
            }
        }
    }

    public void OnPlayerFell()
    {
        spawnedGrounds.Clear();
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
