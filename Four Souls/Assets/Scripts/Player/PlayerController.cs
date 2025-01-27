using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    public Animator animator;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float FireDelay;

    void Update() //Inputs
    {
        MoveInputs();
        ShootInputs();
    }

    void FixedUpdate() //Physics
    {
        Move();
    }

    void MoveInputs() //gehen
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // bewegung x positiv rechts -> negativ links    sprite: run side
        float moveY = Input.GetAxisRaw("Vertical"); // bewegung y positiv up   sprite: run up / y negativ down   sprite: run down

        moveDirection = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("horizontal", moveX);
        animator.SetFloat("vertical", moveY);
        animator.SetFloat("Speed", moveDirection.magnitude);

    }

    void Move()
    {

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void ShootInputs() // schießen
    {
        float shootX = Input.GetAxisRaw("ShootHorizontal");
        float shootY = Input.GetAxisRaw("ShootVertical");


        if (shootX > 0 && Time.time > (lastFire + FireDelay)) // wenn x positiv dann schießt nach rechts -> währendessen sprite:shoot side oder shoot run side? (geflippt)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 180));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, 0, 100), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
        }
        if (shootX < 0 && Time.time > (lastFire + FireDelay)) // x negativ links -> wie oben nur geflippt
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, -100, 0), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
        }
        if (shootY > 0 && Time.time > (lastFire + FireDelay)) // y positiv 
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, 0, 100));
            lastFire = Time.time;
        }
        if (shootY < 0 && Time.time > (lastFire + FireDelay)) // y negativ
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, -100, 0));
            lastFire = Time.time;
        }
    }
}
