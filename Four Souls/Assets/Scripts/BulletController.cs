using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public float airTime;

    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(airTime);
        Destroy(gameObject);
    }
}
