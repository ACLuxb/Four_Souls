using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BossMovement : MonoBehaviour
{
    private float frequency = 3f;
    private float amplitude = 7f;

    private Vector3 sinusPosition;
    private GameObject player;

    private Vector3 previousPlayerPosition;
    private Vector3 targetPosition;
    private Vector3 spawnPoint;

    private Vector3 playerFollowPosition;

    private float elapsedTime;
    private float delay = 0.1f;
    private float followSpeed = 5;

    private void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(player.name);
        spawnPoint = transform.position;
        previousPlayerPosition = transform.position;
        
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= delay)
        {
            targetPosition = previousPlayerPosition;
            previousPlayerPosition = new Vector3(player.transform.position.x, spawnPoint.y, spawnPoint.z);
            Debug.Log("position");
            elapsedTime = 0f;
        }
        
        sinusPosition = new Vector3(Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime, Mathf.Sin(Time.time * 0.2f) * 1f * Time.deltaTime, 0);

        playerFollowPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.position = playerFollowPosition + sinusPosition;
    }
}
