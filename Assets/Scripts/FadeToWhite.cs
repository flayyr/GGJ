using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FadeState { idle, fadeOut, fadeIn }
public class FadeToWhite : MonoBehaviour
{
    public static FadeToWhite instance;

    [SerializeField] float fadeDuration;
    [SerializeField] GameObject deleteWhenFading;
    [SerializeField] Image image;

    FadeState state = FadeState.idle;

    float timer = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(transform.parent);
        instance = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(state == FadeState.fadeOut)
        {
            timer += Time.deltaTime;
            image.color = new Color(1, 1, 1, timer / fadeDuration);
            if (timer > fadeDuration)
            {
                Destroy(deleteWhenFading);
                SceneManager.LoadScene("EndScene");
            }
        }
        else if (state == FadeState.fadeIn)
        {
            timer -= Time.deltaTime;
            image.color = new Color(1, 1, 1, timer / fadeDuration);
            if (timer < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void FadeOut()
    {
        gameObject.SetActive(true);
        state = FadeState.fadeOut;
        timer = 0;
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        state = FadeState.fadeIn;
        timer = fadeDuration;
    }
}
