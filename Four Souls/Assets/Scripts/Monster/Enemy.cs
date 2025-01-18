using UnityEngine;

public class Enemy : Entity
{
    public Enemy (float health, float movementSpeed, float attackDamage) : base (health, movementSpeed, attackDamage) { }

    private Rigidbody2D rb;
    private void Start()
    {
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
