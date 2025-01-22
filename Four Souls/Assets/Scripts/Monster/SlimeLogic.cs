using System.Collections;
using UnityEngine;

public class SlimeLogic : MonoBehaviour
{

    private GameObject player;

    [SerializeField] private float speed;

    bool monsterActiv = false;

    

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterActiv == true)
        {
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator SpawnDelay() 
    {
        yield return new WaitForSeconds(0.5f);
        monsterActiv = true;
    }
}
