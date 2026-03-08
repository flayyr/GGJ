using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] float taskCoolDown;
    [SerializeField] PointerScript pointer;

    bool hasTask;
    float timer = 0;

    private void Awake()
    {
        pointer.Hide();
    }

    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > taskCoolDown)
        {
            hasTask = true;
            pointer.Show();
        }
    }

    public void CompleteTask()
    {
        hasTask= false;
        timer = 0;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Space) && hasTask && collision.tag == "Player")
        {
            Debug.Log("start minigame");
            CompleteTask();
        }
    }
}
