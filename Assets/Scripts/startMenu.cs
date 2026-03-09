using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    [SerializeField] float bobAmount;
    [SerializeField] float bobFrequency;
    float startY;
    float timer = 0;

    public string sceneToGoTo;

    private void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position =new Vector3(transform.position.x, startY + bobAmount * Mathf.Sin(bobFrequency* timer), transform.position.z);
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
