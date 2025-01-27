using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private float health;
    private float maxHealth = 10;

    private bool immunityFrames = false;

    public static event Action OnPlayerDeath;  //event for Player death as reference for the game over screen

    public Image HealthBar;             //referencing the health bar image
    public float healthamount = 100f;   //getting a fill amount of the health bar depending on current health in percent

    public List<GameObject> CrystalCollection;

    private void Start()
    {
        this.health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (immunityFrames == false)
        {
            this.health -= damage;
            HealthBar.fillAmount = (health / 100) / (maxHealth / 100); //telling the healthbar the fillamount

            if (health <= 0)
            {
                GetComponent<PlayerMovement>().enabled = false;
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
