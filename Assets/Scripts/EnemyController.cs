using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IGameObserver
{
    private bool canIncreaseScore = true;
    private bool shot = false;
    private Transform player;
    public Material shotMaterial;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }

    void Update()
    {
        if (transform.position.y < player.position.y-40)
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayerFell()
    {
        canIncreaseScore = false;
    }

    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!shot) {
            if (collision.gameObject.CompareTag("Shot"))
            {
                shot = true;
                ChangeMaterialToShot();
                if(canIncreaseScore)
                {
                    ScoreManager.Instance.IncreaseScore(1);
                }
                StartCoroutine(DestroyAfterDelay(2f));
            }
        }
    }

    public void ChangeMaterialToShot()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = shotMaterial;
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
