using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    private int moving;
    private int moveSpeed = 4;
    private float offset = 40;
    private float yOffsetUp;
    private float yOffsetDown;

    public string sceneToGoTo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moving = Mathf.RoundToInt(transform.position.y);
        yOffsetUp = transform.position.y + offset;
        yOffsetDown = transform.position.y - offset;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moving);

        if(moving >= yOffsetUp)
        {
            moving -= moveSpeed;
        }
        else if(moving <= yOffsetDown)
        {
            moving += moveSpeed;
        }
            Vector2.Lerp(new Vector2(transform.position.x, yOffsetUp), new Vector2(transform.position.x, yOffsetDown), moving * Time.deltaTime);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToGoTo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
