using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 10;

    private bool immunityFrames = false;

    public void TakeDamage(int damage)
    {
        if (immunityFrames == false)
        {
            this.health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            immunityFrames = true;
            Invoke("EndImmunity", 0.5f);
        }
    }
    void EndImmunity()
    {
        immunityFrames = false;
    }
}
