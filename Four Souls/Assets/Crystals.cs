using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crystals : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            this.gameObject.SetActive(false);
            player.CrystalCollection.Add(this.gameObject);
        }
    }
}
