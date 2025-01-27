using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField] public float airTime;

    public int damage = 2;

    public int strength = 4;
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(airTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall") == true || other.gameObject.CompareTag("Door") == true)
            Destroy(gameObject);
    }
}
