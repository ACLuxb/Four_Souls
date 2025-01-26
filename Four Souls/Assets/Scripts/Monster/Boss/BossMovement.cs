using System.Runtime.Versioning;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float frequency = 3f;
    public float amplitude = 3f;

    private Vector3 sinusPosition;
    private GameObject player;

    private Vector3 previousPlayerPosition;
    private Vector3 targetPosition;  

    private float elapsedTime;
    private float delay = 1;
    private float followSpeed = 3;

    private void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(player.name);
        previousPlayerPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= delay)
        {
            targetPosition = previousPlayerPosition;
            previousPlayerPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Debug.Log("position");
            elapsedTime = 0f;
        }
        
        sinusPosition += new Vector3(Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime, 0, 0);
        transform.position = Vector3.Lerp(transform.position, targetPosition + sinusPosition, followSpeed * Time.deltaTime);
    }
}
