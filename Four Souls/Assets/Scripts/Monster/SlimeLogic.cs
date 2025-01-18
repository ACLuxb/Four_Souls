using UnityEngine;

public class SlimeLogic : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float speed;

    public bool monsterActiv;

    void Start()
    {
        player = GameObject.Find("Player");
        Idle();
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

    void Idle()
    {

    }
}
