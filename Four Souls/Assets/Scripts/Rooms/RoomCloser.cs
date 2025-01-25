using NUnit.Framework;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RoomCloser : MonoBehaviour
{
    private bool currentRoomActive;

    private int enemyCounter;

    private RoomTemplates roomTemplates;

    public Sprite ClosedDoor;

    //public int[] Openings;

    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomTemplates.RoomsInFloor.Add(this.gameObject);
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
                    child.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    child.GetComponent<SpriteRenderer>().sprite = ClosedDoor;
                }
            }
        }
    }
}
