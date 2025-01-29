using System;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;
    //  2
    // 3 4
    //  1
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private RoomCloser roomCloser;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    rand = UnityEngine.Random.Range(1, 5); //bottomRooms
                    switch (rand)
                    {
                        case 1:
                            RandomRoom(templates.bRooms);
                            break;
                        case 2:
                            RandomRoom(templates.brRooms);
                            break;
                        case 3:
                            RandomRoom(templates.blRooms);
                            break;
                        case 4:
                            RandomRoom(templates.tbRooms);
                            break;
                    }
                    break;
                case 2:
                    rand = UnityEngine.Random.Range(1, 5); //topRooms
                    switch (rand)
                    {
                        case 1:
                            RandomRoom(templates.tRooms);
                            break;
                        case 2:
                            RandomRoom(templates.trRooms);
                            break;
                        case 3:
                            RandomRoom(templates.tlRooms);
                            break;
                        case 4:
                            RandomRoom(templates.tbRooms);
                            break;
                    }
                    break;
                case 3:
                    rand = UnityEngine.Random.Range(1, 5); //leftRooms
                    switch (rand)
                    {
                        case 1:
                            RandomRoom(templates.lRooms);
                            break;
                        case 2:
                            RandomRoom(templates.tlRooms);
                            break;
                        case 3:
                            RandomRoom(templates.blRooms);
                            break;
                        case 4:
                            RandomRoom(templates.lrRooms);
                            break;
                    }
                    break;
                case 4:
                    rand = UnityEngine.Random.Range(1, 5); //rightRooms
                    switch (rand)
                    {
                        case 1:
                            RandomRoom(templates.rRooms);
                            break;
                        case 2:
                            RandomRoom(templates.trRooms);
                            break;
                        case 3:
                            RandomRoom(templates.brRooms);
                            break;
                        case 4:
                            RandomRoom(templates.lrRooms);
                            break;
                    }
                    break;
            }
            spawned = true;
        }
    }

    void RandomRoom(GameObject[] rooms)
    {
        rand = UnityEngine.Random.Range(0, rooms.Length);
        Instantiate(rooms[rand], transform.position, rooms[rand].transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        {
            /*
            roomCloser = other.GetComponent<RoomCloser>();
            int[] roomopenings = roomCloser.Openings;
            foreach (int i in roomopenings)
            {
                if ((openingDirection == 1 && i == 2) || (openingDirection == 2 && i == 1) || (openingDirection == 3 && i == 4) || (openingDirection == 4 && i == 3))
                    Destroy(gameObject);
                else
                {
                    if
                }

            }
            */
            Destroy(gameObject);
        }
        if (other.CompareTag("Spawnpoint"))
        {
            if (spawned == false)
            {
                int otherOpening = other.GetComponent<RoomSpawner>().openingDirection;
                
                {
                    if ((openingDirection == 1 && otherOpening == 2))
                    {
                        rand = UnityEngine.Random.Range(0, templates.tbRooms.Length);
                        Instantiate(templates.tbRooms[rand], transform.position, templates.tbRooms[rand].transform.rotation);
                    }
                    else if ((openingDirection == 1 && otherOpening == 3))
                    {
                        rand = UnityEngine.Random.Range(0, templates.blRooms.Length);
                        Instantiate(templates.blRooms[rand], transform.position, templates.blRooms[rand].transform.rotation);
                    }
                    else if ((openingDirection == 1 && otherOpening == 4))
                    {
                        rand = UnityEngine.Random.Range(0, templates.brRooms.Length);
                        Instantiate(templates.brRooms[rand], transform.position, templates.brRooms[rand].transform.rotation);
                    }
                    else if ((openingDirection == 2 && otherOpening == 3))
                    {
                        rand = UnityEngine.Random.Range(0, templates.tlRooms.Length);
                        Instantiate(templates.tlRooms[rand], transform.position, templates.tlRooms[rand].transform.rotation);
                    }
                    else if ((openingDirection == 2 && otherOpening == 4))
                    {
                        rand = UnityEngine.Random.Range(0, templates.trRooms.Length);
                        Instantiate(templates.trRooms[rand], transform.position, templates.trRooms[rand].transform.rotation);
                    }
                    else if ((openingDirection == 3 && otherOpening == 4))
                    {
                        rand = UnityEngine.Random.Range(0, templates.lrRooms.Length);
                        Instantiate(templates.lrRooms[rand], transform.position, templates.lrRooms[rand].transform.rotation);
                    }
                }

            }
        }
        spawned = true;
    }
}