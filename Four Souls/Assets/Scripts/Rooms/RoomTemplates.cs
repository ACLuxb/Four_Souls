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

#if UNITY_EDITOR
    [ContextMenu("Load Prefabs")]
    private void LoadPrefabs()
    {

        LoadforeachFolder(ref bRooms, "Assets/Prefabs/Rooms/BottomRooms");
        LoadforeachFolder(ref tRooms, "Assets/Prefabs/Rooms/TopRooms");
        LoadforeachFolder(ref rRooms, "Assets/Prefabs/Rooms/RightRooms");
        LoadforeachFolder(ref lRooms, "Assets/Prefabs/Rooms/LeftRooms");
        LoadforeachFolder(ref brRooms, "Assets/Prefabs/Rooms/BottomRightRooms");
        LoadforeachFolder(ref blRooms, "Assets/Prefabs/Rooms/BottomLeftRooms");
        LoadforeachFolder(ref trRooms, "Assets/Prefabs/Rooms/TopRightRooms");
        LoadforeachFolder(ref tlRooms, "Assets/Prefabs/Rooms/TopLeftRooms");
        LoadforeachFolder(ref tbRooms, "Assets/Prefabs/Rooms/TopBottomRooms");
        LoadforeachFolder(ref lrRooms, "Assets/Prefabs/Rooms/LeftRightRooms");
        
    }
    private void LoadforeachFolder(ref GameObject[] rooms, string path)
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
    }
#endif
}