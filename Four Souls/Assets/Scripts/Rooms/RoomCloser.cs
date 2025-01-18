using NUnit.Framework;
using UnityEngine;

public class RoomCloser : MonoBehaviour
{
    private float enemyCounter;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            enemyCounter++;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            enemyCounter--;
    }

    private void Update()
    {
        if (enemyCounter == 0)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Door"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        
    }
}
