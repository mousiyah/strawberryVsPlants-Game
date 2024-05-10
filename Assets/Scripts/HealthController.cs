using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBar;
    public float healthDecreasePerSecond = 0.1f;
    public float healthIncreasePerSecond = 0.1f;
    public GameObject player;
    private PlayerMovement playerMovement;
    private float health = 1.0f;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CheckGroundStatus();
        UpdateHealthBar();
    }

    private void CheckGroundStatus()
    {
        if (playerMovement != null)
        {
            if (playerMovement.IsGrounded())
            {
                IncreaseHealth();
            }
            else
            {
                DecreaseHealth();
            }
        }
    }

    private void DecreaseHealth()
    {
        health -= healthDecreasePerSecond * Time.deltaTime;
        health = Mathf.Clamp(health, 0f, 1f);
    }

    private void IncreaseHealth()
    {
        health += healthIncreasePerSecond * Time.deltaTime;
        health = Mathf.Clamp(health, 0f, 1f);
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }
}
