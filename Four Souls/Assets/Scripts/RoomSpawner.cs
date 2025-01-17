using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;
    //  2
    // 3 4
    //  1
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Spawnpoint"))
        {
            if (spawned == false)
            {
                int otherOpening = other.GetComponent<RoomSpawner>().openingDirection;

                if ((openingDirection == 1 && otherOpening == 2))
                {
                    rand = Random.Range(0, templates.tbRooms.Length);
                    Instantiate(templates.tbRooms[rand], transform.position, templates.tbRooms[rand].transform.rotation);
                }
                else if ((openingDirection == 1 && otherOpening == 3))
                {
                    rand = Random.Range(0, templates.blRooms.Length);
                    Instantiate(templates.blRooms[rand], transform.position, templates.blRooms[rand].transform.rotation);
                }
                else if ((openingDirection == 1 && otherOpening == 4))
                {
                    rand = Random.Range(0, templates.brRooms.Length);
                    Instantiate(templates.brRooms[rand], transform.position, templates.brRooms[rand].transform.rotation);
                }
                else if ((openingDirection == 2 && otherOpening == 3))
                {
                    rand = Random.Range(0, templates.tlRooms.Length);
                    Instantiate(templates.tlRooms[rand], transform.position, templates.tlRooms[rand].transform.rotation);
                }
                else if ((openingDirection == 2 && otherOpening == 4))
                {
                    rand = Random.Range(0, templates.trRooms.Length);
                    Instantiate(templates.trRooms[rand], transform.position, templates.trRooms[rand].transform.rotation);
                }
                else if ((openingDirection == 3 && otherOpening == 4))
                {
                    rand = Random.Range(0, templates.lrRooms.Length);
                    Instantiate(templates.lrRooms[rand], transform.position, templates.lrRooms[rand].transform.rotation);
                }
            }
        }
        spawned = true;
    }
}