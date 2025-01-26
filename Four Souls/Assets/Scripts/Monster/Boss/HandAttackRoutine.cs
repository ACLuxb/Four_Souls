using System.Collections;
using UnityEngine;

public class HandAttackRoutine : MonoBehaviour
{
    private float rand = 3f;
    public Sprite attackSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(rand);
        rand = Random.Range(2, 6);

        //sprite ändern
        //initiate -> direction
        //sprite zurück

    }
}
