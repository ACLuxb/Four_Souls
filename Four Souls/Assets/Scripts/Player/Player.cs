using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class Player : MonoBehaviour
{
    public float health;
    private float maxHealth = 10;

    private bool immunityFrames = false;

    public static event Action OnPlayerDeath;  //event for Player death as reference for the game over screen

    public Image HealthBar;             //referencing the health bar image
    public float healthamount = 100f;   //getting a fill amount of the health bar depending on current health in percent

    public List<GameObject> CrystalCollection;

    private void Start()
    {

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

                string path = Application.persistentDataPath + "/player.save";
                /*
                try
                {
                    File.Delete(path); // Deletes the file
                    Debug.Log($"File deleted: {path}");
                }
                catch
                {
                    Debug.LogError($"File not found: {path}");
                }
                */
                OnPlayerDeath!.Invoke(); //event starts of player is dead
            }
            immunityFrames = true;
            Invoke("EndImmunity", 0.5f);
        }
    }

    private void Update()
    {
        
    }
    void EndImmunity()
    {
        immunityFrames = false;
    }

    public void LoadGameData()
    {
        try
        {
            GameData data = SaveSystem.LoadGame();

            health = data.health;

            Vector3 position;
            position.x = data.playerPosition[0];
            position.y = data.playerPosition[1];
            position.z = data.playerPosition[2];
            transform.position = position;
        }
        catch (Exception)
        {
            health = maxHealth;
        }
    }
}
