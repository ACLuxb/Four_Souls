using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public Transform bossBody;       // Referenz zum Bossk�rper
    public Vector3 offset;           // Lokaler Versatz der Arme relativ zum Boss
    public float delay;       // Verz�gerung in Sekunden
    public float followSpeed;   // Geschwindigkeit der geschmeidigen Bewegung

    private Vector3 previousBossPosition; // Speichert die Position des Bosses f�r die Verz�gerung
    private Vector3 targetLocalPosition;  // Zielposition f�r den Arm
    private float elapsedTime;            // Zeit f�r die Verz�gerung

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
