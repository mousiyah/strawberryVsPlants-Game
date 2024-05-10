using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour, IGameObserver
{
    public GameObject shotPrefab;
    public float shotSpeed = 100f;
    public AudioClip shotSound;
    public float shotCooldown = 0f;
    private float lastShotTime;
    private Boolean canShoot = true;
    public static bool isShooted = false;

    void Start()
    {
        GameSubject gameSubject = FindObjectOfType<GameSubject>();
        gameSubject.AddObserver(this);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);

            Rigidbody shotRigidbody = shot.GetComponent<Rigidbody>();

            shotRigidbody.velocity = 2f * shotSpeed * transform.forward;

            if (shotSound != null)
            {
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
            }

            lastShotTime = Time.time;

            isShooted = true;
        }
    }

    public void OnPlayerFell()
    {
        canShoot = false;
    }

    public void OnFreeze()
    {
        
    }

    public void OnUnFreeze()
    {
        
    }
}
