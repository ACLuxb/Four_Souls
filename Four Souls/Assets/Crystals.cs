using TMPro;
using UnityEngine;
using System.Collections;

public class Crystals : MonoBehaviour
{
    public AudioClip blingSFX;

    public AudioSource speaker;

    private void Start()
    {
        speaker = GameObject.Find("Collect Sound").GetComponent<AudioSource>();
    }
    private void PlayBlingAndDisable()
    {
        speaker.PlayOneShot(blingSFX);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            // Crystal zur Liste hinzufügen
            player.CrystalCollection.Add(this.gameObject);
            Debug.Log("Count +1");

            // Coroutine starten, damit der Sound gespielt wird bevor das GameObject deaktiviert wird
            PlayBlingAndDisable();
        }
    }
}
