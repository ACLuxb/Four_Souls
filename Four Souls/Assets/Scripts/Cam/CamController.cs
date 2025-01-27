using UnityEngine;

public class CamController : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed;

    private Vector3 targetPos, newPos;

    public Vector3 minPos, maxPos;

    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            targetPos = player.position;

            Vector3 camBoundaryPos = new Vector3(
                Mathf.Clamp(targetPos.x, minPos.x, maxPos.x),
                Mathf.Clamp(targetPos.y, minPos.y, maxPos.y),
                Mathf.Clamp(targetPos.z, minPos.z, maxPos.z));

            newPos = Vector3.Lerp(transform.position, camBoundaryPos, smoothSpeed);
            transform.position = newPos;
        }
    }

    public void LoadGameData()
    {
        GameData data = SaveSystem.LoadGame();
        try
        {
            targetPos.x = data.cameraPosition[0];
            targetPos.y = data.cameraPosition[1];
            targetPos.z = data.cameraPosition[2];

            minPos.x = data.cameraMinPosition[0];
            minPos.y = data.cameraMinPosition[1];
            minPos.z = data.cameraMinPosition[2];

            maxPos.x = data.cameraMaxPosition[0];
            maxPos.y = data.cameraMaxPosition[1];
            maxPos.z = data.cameraMaxPosition[2];
        }
        catch { }
    }
}
