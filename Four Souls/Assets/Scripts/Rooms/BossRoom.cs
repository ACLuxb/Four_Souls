using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;

    private Vector3 spawnPosition;

    private bool bossSpawned;

    void Start()
    {
        boss = Resources.Load<GameObject>("Boss");

        foreach (Transform child in transform)
        {
            if (child.CompareTag("MonsterSpawn"))
            {
                Destroy(child.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player.CrystalCollection.Count == 4)
            {
                
                player.transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
                spawnPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

                Instantiate(boss, spawnPosition, transform.rotation);

                player.CrystalCollection.Clear();
            }
            
        }
    }
}
