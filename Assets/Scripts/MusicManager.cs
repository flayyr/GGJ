using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip[] musics;
    [SerializeField] AudioSource mainSource;
    [SerializeField] AudioSource altSource;
    [SerializeField] float musicCrossFadeDuration = 5;

    int speedLevel = 0;
    bool fading = false;
    float fadeTimer = 0;

    private void Awake()
    {
        instance = this;
        mainSource.clip = musics[speedLevel];
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        int newLevel = 0;

        if (AttendeeManager.instance == null)
        {
            return;
        }

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
            float newProgress = ((mainSource.time / musics[speedLevel].length)%1f) * musics[newLevel].length;
            //newProgress = musicSource.time;
            speedLevel = newLevel;

            AudioSource temp = mainSource;
            mainSource = altSource;
            altSource = temp;


            mainSource.clip = musics[newLevel];
            mainSource.volume = 0;
            mainSource.time = newProgress;
            mainSource.Play();
            mainSource.time = newProgress;

            fading = true;

        }

        if (fading)
        {
            fadeTimer += Time.deltaTime;

            mainSource.volume = fadeTimer / musicCrossFadeDuration;
            altSource.volume = 1f - mainSource.volume;

            if (fadeTimer >= musicCrossFadeDuration)
            {
                mainSource.volume = 1;
                altSource.volume = 0;
                fadeTimer = 0;
                fading = false;
            }
        }
        
    }

    //if anyone is irritated > 20
    //60 seconds before every toast


}
