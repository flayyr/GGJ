using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] float gameLength;
    public static GameEnd instance;

    float timer = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > gameLength)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
