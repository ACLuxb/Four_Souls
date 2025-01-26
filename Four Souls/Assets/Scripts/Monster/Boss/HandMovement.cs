using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public Transform bossBody;       // Referenz zum Bosskörper
    public Vector3 offset;           // Lokaler Versatz der Arme relativ zum Boss
    public float delay;       // Verzögerung in Sekunden
    public float followSpeed;   // Geschwindigkeit der geschmeidigen Bewegung

    private Vector3 previousBossPosition; // Speichert die Position des Bosses für die Verzögerung
    private Vector3 targetLocalPosition;  // Zielposition für den Arm
    private float elapsedTime;            // Zeit für die Verzögerung

    void Start()
    {
        previousBossPosition = bossBody.position;
        targetLocalPosition = transform.localPosition + offset;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= delay)
        {
            targetLocalPosition = bossBody.InverseTransformPoint(previousBossPosition) + offset;
            previousBossPosition = bossBody.position;

            elapsedTime = 0f;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPosition, followSpeed * Time.deltaTime);
    }
}
