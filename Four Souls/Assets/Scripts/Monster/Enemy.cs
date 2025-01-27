using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxhealth = 10;
    
    private int collisionDamage = 2;

    private Rigidbody2D rb;
    private void Start()
    {
        this.health = maxhealth;
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        this.health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(collisionDamage);
        }
    }

    public void GetKnockback(GameObject sender, int strength)
    {
        Vector2 direction = sender.GetComponent<Rigidbody2D>().linearVelocity.normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
