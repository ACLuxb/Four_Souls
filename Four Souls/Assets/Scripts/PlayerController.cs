using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

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

    void MoveInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;    
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void ShootInputs()
    {
        float shootX = Input.GetAxisRaw("ShootHorizontal");
        float shootY = Input.GetAxisRaw("ShootVertical");

        if (shootX > 0 && Time.time > (lastFire + FireDelay))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, 0, 100), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
        }
        if (shootX < 0 && Time.time > (lastFire + FireDelay))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, -100, 0), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
        }
        if (shootY > 0 && Time.time > (lastFire + FireDelay))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, 0, 100));
            lastFire = Time.time;
        }
        if (shootY < 0 && Time.time > (lastFire + FireDelay))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, -100, 0));
            lastFire = Time.time;
        }
    }


    /*
    void OnTriggerEnter(Collider Door)
    {
        Debug.Log("teleporting");
        {
            transform.localPosition = new Vector2(0,0);
        }
    }
    */
}
