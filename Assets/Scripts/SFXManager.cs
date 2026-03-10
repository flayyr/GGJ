using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] public AudioClip[] collisions;
    [SerializeField] public AudioClip[] dash;
    [SerializeField] public AudioClip[] footsteps;
    [SerializeField] public AudioClip[] grabShrimp;
    [SerializeField] public AudioClip[] placeShrimp;
    [SerializeField] public AudioClip[] placeShrimpSuccess;
    [SerializeField] public AudioClip[] iceClink;
    [SerializeField] public AudioClip[] menuPress;
    [SerializeField] public AudioClip[] menuSelect;
    [SerializeField] public AudioClip[] talk;
    [SerializeField] public AudioClip[] angry;
    [SerializeField] public AudioClip[] leave;
    [SerializeField] public AudioClip[] winGame;
    [SerializeField] public AudioClip[] loseGame;


    [SerializeField] public AudioClip wiping;
    [SerializeField] AudioSource wipingSource;
    [SerializeField] float wipeVolume;

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

    bool playingWipe = false;
    TableWiping wipeScript;
    public void PlayWipingSound(TableWiping wipingScript)
    {
        wipingSource.clip = wiping;
        wipingSource.Play();
        playingWipe = true;
        wipeScript = wipingScript;
    }
    public void StopWipe()
    {
        playingWipe = false;
        wipingSource.Stop();
    }
    private void Update()
    {
        if (playingWipe)
        {
            wipingSource.volume = wipeScript.wipeVelocity * wipeVolume;
        }
    }
}
