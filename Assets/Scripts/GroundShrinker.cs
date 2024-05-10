using UnityEngine;

public class GroundShrinker : MonoBehaviour, IGameObserver
{
    public float shrinkSpeed = 1f;
    public float minSize = 0.1f;
    private GameObject player;

    private bool canShrink = false;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(canShrink){
            Shrink();
        }
    }

    private void Shrink()
    {
        Vector3 currentScale = transform.localScale;
        float newScale = Mathf.Max(currentScale.x - shrinkSpeed * Time.deltaTime * 10, minSize);
        transform.localScale = new Vector3(newScale, currentScale.y, newScale);

        if (newScale <= minSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            canShrink = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            canShrink = false;
        }
    }

    public void OnPlayerFell()
    {
        canShrink = false;
    }

    public void OnFreeze()
    {
        canShrink = false;
    }

    public void OnUnFreeze()
    {
        
    }
}
