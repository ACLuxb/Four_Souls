using System.Collections;
using UnityEditor;
using UnityEngine;

public class HandAttackRoutine : MonoBehaviour
{
    private float rand = 3;
    private float timer;
    public Sprite attackSprite;
    public Sprite neutralSprite;
    public GameObject FireballPrefab;

    private bool phase2 = false;

    void Start()
    {

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= rand)
        {
            timer = 0;
            Shoot();
            rand = Random.Range(1f, 3f);
        }

        Enemy enemy = GetComponentInParent<Enemy>();
        if (enemy.health < enemy.maxhealth/2)
        {
            phase2 = true;
        }

    }
    void Shoot()
    {
        GameObject Fireball = Instantiate(FireballPrefab, transform.position, Quaternion.Euler(0, 0, -90));
        Fireball.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -6);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = neutralSprite;

        if (phase2)
        {
            GameObject Fireball2 = Instantiate(FireballPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            Fireball2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, -6);
            GameObject Fireball3 = Instantiate(FireballPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            Fireball3.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-2, -6);
        }
    }
}
