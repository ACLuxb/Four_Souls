using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] tbRooms;
    public GameObject[] lrRooms;

    public GameObject[] trRooms;
    public GameObject[] tlRooms;

    public GameObject[] brRooms;
    public GameObject[] blRooms;

    public GameObject[] bRooms;
    public GameObject[] tRooms;
    public GameObject[] rRooms;
    public GameObject[] lRooms;

    public List<GameObject> RoomsInFloor;

    public float waitTime;
    public bool spawnedBoss;
    public GameObject boss;

    public Sprite BossRoomSprite;

    private void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < RoomsInFloor.Count; i++)
            {
                if (i == RoomsInFloor.Count-1)
                {

                    RoomsInFloor[i].GetComponent<SpriteRenderer>().sprite = BossRoomSprite;
                    Instantiate(boss, RoomsInFloor[i].transform.position, Quaternion.identity);
                    //foreach() MonsterSpawner in room -> destroy

                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Load Prefabs")]
    private void LoadPrefabs()
    {

        LoadforeachFolder(bRooms, "Assets/Prefabs/Rooms/BottomRooms");
        LoadforeachFolder(tRooms, "Assets/Prefabs/Rooms/TopRooms");
        LoadforeachFolder(rRooms, "Assets/Prefabs/Rooms/RightRooms");
        LoadforeachFolder(lRooms, "Assets/Prefabs/Rooms/LeftRooms");
        LoadforeachFolder(brRooms, "Assets/Prefabs/Rooms/BottomRightRooms");
        LoadforeachFolder(blRooms, "Assets/Prefabs/Rooms/BottomLeftRooms");
        LoadforeachFolder(trRooms, "Assets/Prefabs/Rooms/TopRightRooms");
        LoadforeachFolder(tlRooms, "Assets/Prefabs/Rooms/TopLeftRooms");
        LoadforeachFolder(tbRooms, "Assets/Prefabs/Rooms/TopBottomRooms");
        LoadforeachFolder(lrRooms, "Assets/Prefabs/Rooms/LeftRightRooms");
        
    }
    private GameObject[] LoadforeachFolder(GameObject[] rooms, string path)
    {
        string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { path });

        rooms = new GameObject[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            rooms[i] = prefab;
        }

        Debug.Log($"Loaded {rooms.Length} prefabs from {path}.");
        return rooms;
    }
#endif
}