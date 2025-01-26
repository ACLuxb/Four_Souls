using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Rendering;

public class BossMovement : MonoBehaviour
{
    private float frequency = 3f;
    private float amplitude = 3f;

    private Vector3 sinusPosition;
    private GameObject player;

    private Vector3 previousPlayerPosition;
    private Vector3 targetPosition;

    private Vector3 endpos;

    private float elapsedTime;
    private float delay = 0.5f;
    private float followSpeed = 3;

    private void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(player.name);
        previousPlayerPosition = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= delay)
        {
            targetPosition = previousPlayerPosition;
            previousPlayerPosition = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, gameObject.transform.position.z);
            Debug.Log("position");
            elapsedTime = 0f;
        }
        
        sinusPosition += new Vector3(Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime, Mathf.Sin(Time.time * 0.1f) * 0.1f * Time.deltaTime, 0);

        endpos = targetPosition + sinusPosition;
        transform.position = Vector3.Lerp(transform.position, endpos, followSpeed * Time.deltaTime);
    }
}
