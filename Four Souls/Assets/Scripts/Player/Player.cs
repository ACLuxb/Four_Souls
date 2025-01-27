using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int health = 10;

    private bool immunityFrames = false;

    public static event Action OnPlayerDeath;  //event for Player death as reference for the game over screen

    public Image HealthBar;             //referencing the health bar image
    public float healthamount = 100f;   //getting a fill amount of the health bar depending on current health in percent

    public void TakeDamage(int damage)
    {
        if (immunityFrames == false)
        {
            this.health -= damage;
            HealthBar.fillAmount = health / 100f; //telling the healthbar the fillamount

            if (health <= 0)
            {
                Destroy(gameObject);
                OnPlayerDeath!.Invoke(); //event starts of player is dead
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
