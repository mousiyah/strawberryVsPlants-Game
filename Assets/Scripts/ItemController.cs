using UnityEngine;

public abstract class ItemController : MonoBehaviour, IGameObserver
{
    protected bool isCollectable = true;
    protected bool collected = false;
    protected GameObject player;
    protected Sprite itemSprite;

    public static bool isFirstCollected = false;

    public abstract void OnCollisionWithPlayer();

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
        itemSprite = gameObject.GetComponent<ItemSpriteController>().itemSprite;

        player = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        DestoyOnOutOfBounds();
    }

    private void DestoyOnOutOfBounds()
    {
        if (transform.position.y > player.transform.position.y + 500)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collected && collision.gameObject.CompareTag("Player"))
        {
            collected = true;
            if (isCollectable)
            {
                CollectedItemsManager.Instance.AddItem(itemSprite);
                GameEventManager.Instance.QueueEvent(() => {
                    OnCollisionWithPlayer();;
                }); 
                isFirstCollected = true;
            }
            Destroy(gameObject);
        }
    }

    public virtual void OnPlayerFell()
    {
        isCollectable = false;
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
