using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health { get; set; }

    private float movementSpeed { get; set; }

    private float attackDamage { get; set; }

    public Entity (float health, float movementSpeed, float attackDamage)
    {
        this.health = 10;
        this.movementSpeed = movementSpeed;
        this.attackDamage = attackDamage;
    }
}
