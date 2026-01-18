using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlimeLogic : MonoBehaviour
{

    private GameObject player;

    [SerializeField] private float speed;

    bool monsterActiv = false;

    public Animator animator; //to assign an animation

    public AudioSource AudioScream;
    public AudioClip screamSFX;

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

            animator.SetFloat("Horizontal", direction.x); //parameter for the direction of the animation

            bool isMoving = direction.magnitude > 0.1f;

            if (isMoving)
            {
                if (!AudioScream.isPlaying)
                {
                    AudioScream.clip = screamSFX;
                    AudioScream.Play();
                }
            }
            else
            {
                if (AudioScream.isPlaying)
                {
                    AudioScream.Stop();
                }
            }

        }

    }

    IEnumerator SpawnDelay() 
    {
        yield return new WaitForSeconds(0.5f);
        monsterActiv = true;
    }
}
