using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] float taskCoolDown;
    [SerializeField] PointerScript pointer;

    public bool hasDrink;

    bool hasTask;
    float timer = 0;

    float etiquette, munchies, sociability = 100;

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
        }

        etiquette-= Time.deltaTime;
        munchies -= Time.deltaTime;
        sociability -= Time.deltaTime;
    }

    public void CompleteTask()
    {
        hasTask= false;
        timer = 0;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Space) && hasTask && collision.tag == "Player" && MinigameManager.instance.state == GameState.idle)
        {
            MinigameManager.instance.StartMinigame(this);
        }
    }
}
