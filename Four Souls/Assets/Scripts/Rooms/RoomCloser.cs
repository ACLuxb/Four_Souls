using NUnit.Framework;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RoomCloser : MonoBehaviour
{
    private bool currentRoomActive;

    private int enemyCounter;

    private RoomTemplates roomTemplates;

    private void Start()
    {
        roomTemplates.RoomsInFloor.Add(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            currentRoomActive = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            currentRoomActive = false;
        if (other.gameObject.CompareTag("Enemy"))
            enemyCounter--;
    }

    private void Update()
    {
        if (currentRoomActive)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.CompareTag("MonsterSpawn"))
                {
                    child.gameObject.SetActive(true);
                    enemyCounter++;
                }
            }
            OpenDoors();
        }
    }
    private void OpenDoors()
    {
        if (enemyCounter == 0)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.CompareTag("Door"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
