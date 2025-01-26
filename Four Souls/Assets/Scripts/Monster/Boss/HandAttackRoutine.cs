using System.Collections;
using UnityEditor;
using UnityEngine;

public class HandAttackRoutine : MonoBehaviour
{
    private float rand;
    float timer;
    public Sprite attackSprite;
    public Sprite neutralSprite;
    public GameObject FireballPrefab;
    public Player player;

    private bool phase1;
    void Start()
    {
        AttackPattern();
    }

    void AttackPattern()
    {
        while (phase1 == true)
        {
            rand = Random.Range(4, 7);
            timer += Time.deltaTime;
            if (timer >= rand)
            {
                Attack();
                timer = 0;
            }
        }
    }

    void Attack()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        Invoke("Shoot", 1f);

    }
    void Shoot()
    {
        Vector2 direction = player.transform.position - transform.position;
        GameObject Fireball = Instantiate(FireballPrefab, transform.position, transform.rotation);
        Fireball.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -10);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = neutralSprite;
    }
}
