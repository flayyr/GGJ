using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [HideInInspector]public float finalTimerLength;
    [HideInInspector]public static GameEnd instance;

    float timer = 0;
    public bool ending = false;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (ending)
        {
            timer += Time.deltaTime;
            if (timer > finalTimerLength)
            {
                EndGame();
                ending = false;
            }
        }
    }

    public void EndGame()
    {
        MinigameManager.instance.EndMinigame(true);
        FadeToWhite.instance.FadeOut();
    }
}
