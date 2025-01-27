using NUnit.Framework;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RoomCloser : MonoBehaviour
{
    private bool currentRoomActive;

    private int enemyCounter;

    private RoomTemplates roomTemplates;

    public Sprite OpenDoor;
    public Sprite ClosedDoor;


    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomTemplates.RoomsInFloor.Add(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            currentRoomActive = true;
        if (other.CompareTag("Enemy"))
        {
            enemyCounter++;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            currentRoomActive = false;
        if (other.CompareTag("Enemy"))
        {
            enemyCounter--;
        }
    }

    private void FixedUpdate()
    {
        if (currentRoomActive == true)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.CompareTag("MonsterSpawn"))
                {
                    child.gameObject.SetActive(true);
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
                    child.GetComponent<SpriteRenderer>().sprite = OpenDoor;
                }
            }
        }
        else
        {

            foreach (UnityEngine.Transform child in transform)
            {
                if (child.CompareTag("Door"))
                {

                    child.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    child.GetComponent<SpriteRenderer>().sprite = ClosedDoor;
                }
            }
        }
    }
}
