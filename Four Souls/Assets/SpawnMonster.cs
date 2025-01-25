using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    private int rand;

    private EnemyTable enemyTable;
    void Start()
    {
        enemyTable = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTable>();
        rand = Random.Range(0, enemyTable.CommonEnemies.Length);
        Instantiate(enemyTable.CommonEnemies[rand], transform.position, enemyTable.CommonEnemies[rand].transform.rotation);
        Destroy(gameObject);
    }
}
