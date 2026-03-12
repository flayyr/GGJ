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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName( "EndScene")|| SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HowToPlay"))
        {
            Destroy(SFXManager.instance.gameObject);
            Destroy(MusicManager.instance.gameObject);
        }
        SceneManager.LoadScene(sceneToGoTo);
        if(SFXManager.instance!= null)
            SFXManager.instance.PlaySound(SFXManager.instance.menuSelect);
        
    }

    public void QuitGame()
    {
        SFXManager.instance.PlaySound(SFXManager.instance.menuSelect);
        Application.Quit();
    }

}
