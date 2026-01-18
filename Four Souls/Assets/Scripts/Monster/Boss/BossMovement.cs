using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BossMovement : MonoBehaviour
{
    private float frequency = 4f;
    private float amplitude = 10f;

    private Vector3 sinusPosition;
    private GameObject player;

    private Vector3 previousPlayerPosition;
    private Vector3 targetPosition;
    private Vector3 spawnPoint;

    private Vector3 playerFollowPosition;

    private float elapsedTime;
    private float delay = 0.15f;
    private float followSpeed = 7;

    private void Start()
    {
        player = GameObject.Find("Player");

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
            elapsedTime = 0f;
        }
        
        sinusPosition = new Vector3(Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime, Mathf.Sin(Time.time * 0.2f) * 1f * Time.deltaTime, 0);

        playerFollowPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.position = playerFollowPosition + sinusPosition;


    }
}
