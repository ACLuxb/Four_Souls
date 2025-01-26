using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;

    private Vector3 spawnPosition;

    private bool bossSpawned;

    void Start()
    {
        player = GameObject.Find("Player");

        foreach (Transform child in transform)
        {
            if (child.CompareTag("MonsterSpawn"))
            {
                Destroy(child);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bossSpawned == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
                spawnPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                Instantiate(boss, spawnPosition, transform.rotation);

            }
            bossSpawned = true;
        }

    }
}
