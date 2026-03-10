using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;

    [SerializeField] AudioClip[] musics;

    int speedLevel = 0;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musics[speedLevel];
    }

    private void Update()
    {
        int newLevel = 0;

        if (AttendeeManager.instance.irritatedCount>0)
        {
            newLevel++;
        }

        if (AttendeeManager.instance.closeToToast)
        {
            newLevel++;
        }

        if (newLevel != speedLevel)
        {
            float newProgress = ((musicSource.time / musics[speedLevel].length)%1f) * musics[newLevel].length;
            //newProgress = musicSource.time;
            speedLevel = newLevel;
            musicSource.clip = musics[newLevel];
            musicSource.time = newProgress;
            musicSource.Play();
            musicSource.time = newProgress;

        }
        
    }

    //if anyone is irritated > 20
    //60 seconds before every toast


}
