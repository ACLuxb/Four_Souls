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

    private bool isDead = false;

    public AudioSource AudioShoot;
    public AudioSource AudioWalk;
    public AudioClip shootSFX;
    public AudioClip walkingSFX;

    void Update() //Inputs
    {
        if (isDead) return;

        MoveInputs();
        ShootInputs();

        bool isMoving = moveDirection.magnitude > 0.1f && !isDead;

        if (isMoving)
        {
            if (!AudioWalk.isPlaying)
            {
                AudioWalk.clip = walkingSFX;
                AudioWalk.Play();
            }
        }
        else
        {
            if (AudioWalk.isPlaying)
            {
                AudioWalk.Stop();
            }
        }

    }

    void FixedUpdate() //Physics
    {
        if (isDead) return;

        Move();

        bool isMoving = moveDirection.magnitude > 0.1f && !isDead;

        if (isMoving)
        {
            if (!AudioWalk.isPlaying)
            {
                AudioWalk.clip = walkingSFX;
                AudioWalk.Play();
            }
        }
        else
        {
            if (AudioWalk.isPlaying)
            {
                AudioWalk.Stop();
            }
        }

    }

    void MoveInputs() //gehen
    {
        if (isDead) return;
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
        if (isDead) return;
        float shootX = Input.GetAxisRaw("ShootHorizontal");
        float shootY = Input.GetAxisRaw("ShootVertical");


        if (shootX > 0 && Time.time > (lastFire + FireDelay)) // wenn x positiv dann schießt nach rechts -> währendessen sprite:shoot side oder shoot run side? (geflippt)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 180));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, 0, 100), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
            AudioShoot.PlayOneShot(shootSFX);


        }
        if (shootX < 0 && Time.time > (lastFire + FireDelay)) // x negativ links -> wie oben nur geflippt
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootX * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.x, -100, 0), 0.5f * rb.linearVelocity.y);
            lastFire = Time.time;
            AudioShoot.PlayOneShot(shootSFX);

        }
        if (shootY > 0 && Time.time > (lastFire + FireDelay)) // y positiv 
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, 0, 100));
            lastFire = Time.time;
            AudioShoot.PlayOneShot(shootSFX);

        }
        if (shootY < 0 && Time.time > (lastFire + FireDelay)) // y negativ
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.5f * rb.linearVelocity.x, shootY * bulletSpeed + Mathf.Clamp(0.4f * rb.linearVelocity.y, -100, 0));
            lastFire = Time.time;
            AudioShoot.PlayOneShot(shootSFX);

        }
    }

    private void OnEnable()
    {
        Player.OnPlayerDeath += Die; //subscribing to the event that triggers when player got murked
        
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= Die;
    }


    public void Die()
    {
        isDead = true;

        animator.SetBool("IsDead", true);
        animator.SetFloat("Speed", 0);
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);

        moveDirection = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;

        Debug.Log("PLAYER DIED");

    }




}
