using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public float airTime;

    public int damage = 5;

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
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            enemy.GetKnockback(this.gameObject, strength);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall") == true || other.gameObject.CompareTag("Door") == true)
            Destroy(gameObject);
    }
}
