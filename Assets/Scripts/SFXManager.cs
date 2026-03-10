using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] public AudioClip[] collisions;
    [SerializeField] public AudioClip[] dash;
    [SerializeField] public AudioClip[] footsteps;
    [SerializeField] public AudioClip[] grabShrimp;
    [SerializeField] public AudioClip[] placeShrimp;
    [SerializeField] public AudioClip[] iceClink;
    [SerializeField] public AudioClip[] menuPress;
    [SerializeField] public AudioClip[] menuSelect;
    [SerializeField] public AudioClip[] talk;
    [SerializeField] public AudioClip[] angry;
    [SerializeField] public AudioClip[] leave;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlaySound(AudioClip[] clips)
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        source.pitch = Random.Range(0.95f, 1.05f);
        source.PlayOneShot(clip);
    }
}
