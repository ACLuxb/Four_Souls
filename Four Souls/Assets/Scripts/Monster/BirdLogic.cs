using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class BirdLogic : MonoBehaviour
{
    private GameObject player;

    public GameObject projectile;

    bool monsterActiv = false;

    public float fireRate = 1f; 
    public float bulletSpeed = 5f;
    private float fireCooldown = 0f;

    private float rand;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnDelay());
    }

    void Update()
    {
        if (monsterActiv == true)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            fireCooldown -= Time.deltaTime;

            if (fireCooldown <= 0f)
            {
                Shoot(direction);
                fireCooldown = fireRate;
                rand = Random.Range(0.6f, 1.4f);
                fireRate = rand;
            }

        }
    }
    void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        monsterActiv = true;
    }
}



