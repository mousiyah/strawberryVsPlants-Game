using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItemsManager : MonoBehaviour
{
    public static CollectedItemsManager Instance { get; private set; }

    public List<GameObject> collectedItems = new List<GameObject>();
    public Transform itemsPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DeleteFirstItem();
            RearrangeItems();
        }
    }

    public void AddItem(Sprite item)
    {
        float newYPosition = -130f * collectedItems.Count;

        GameObject newImageObject = new GameObject("CollectedItemImage", typeof(RectTransform), typeof(Image));
        newImageObject.transform.SetParent(itemsPanel);

        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 1f);
        rectTransform.anchoredPosition = new Vector2(60f, newYPosition);

        Image imageComponent = newImageObject.GetComponent<Image>();
        imageComponent.sprite = item;

        collectedItems.Add(newImageObject);
    }

    void DeleteFirstItem()
    {
        if (collectedItems.Count > 0)
        {
            GameObject firstItem = collectedItems[0];
            collectedItems.RemoveAt(0);
            Destroy(firstItem);
        }
    }

    void RearrangeItems()
    {
        float newYPosition = -130f * collectedItems.Count;

        foreach (GameObject item in collectedItems)
        {
            RectTransform rectTransform = item.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(60f, newYPosition);
            newYPosition += 130f;
        }
        Canvas.ForceUpdateCanvases();
    }
}
