using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; //to be able to call this script from anywhere
    [SerializeField] private AudioSource SoundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip (AudioClip soundeffect, Transform spawntransform, float volume)
    {
    //spawn in Game object
        AudioSource audioSource = Instantiate(SoundFXObject, spawntransform.position, Quaternion.identity);

    //assign a clip
        audioSource.clip = soundeffect;

    //assign volume
        audioSource.volume = volume;

    //play sound
        audioSource.Play();

    //get length of the sound clip
        float cliplength = audioSource.clip.length;

    //destroy the clip after its done playing
        Destroy(audioSource.gameObject, cliplength);

    }
}
