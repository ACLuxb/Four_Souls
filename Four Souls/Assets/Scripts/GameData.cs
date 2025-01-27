using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float health;
    public float[] playerPosition;
    public float[] cameraPosition;
    public float[] cameraMinPosition;
    public float[] cameraMaxPosition;
    //public List<GameObject> DungeonLayout;

    public GameData (Player player, CamController camera)
    {
        health = player.health;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        cameraPosition = new float[3];
        cameraPosition[0] = camera.transform.position.x;
        cameraPosition[1] = camera.transform.position.y;
        cameraPosition[2] = camera.transform.position.z;

        cameraMinPosition = new float[3];
        cameraMinPosition[0] = camera.minPos.x;
        cameraMinPosition[1] = camera.minPos.y;
        cameraMinPosition[2] = camera.minPos.z;

        cameraMaxPosition = new float[3];
        cameraMaxPosition[0] = camera.maxPos.x;
        cameraMaxPosition[1] = camera.maxPos.y;
        cameraMaxPosition[2] = camera.maxPos.z;

        //DungeonLayout = template.RoomsInFloor;
    }
}
