using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] float taskCoolDown;
    [SerializeField] PointerScript pointer;

    public bool hasDrink;

    bool interactInput;
    float timer = 0;

    float etiquette, munchies, sociability = 100;

    private void Awake()
    {
        pointer.Hide();
    }

    private void Update()
    {
        //timer+=Time.deltaTime;
        //if (timer > taskCoolDown)
        //{
        //    hasTask = true;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactInput = true;
        }

        etiquette-= Time.deltaTime;
        munchies -= Time.deltaTime;
        sociability -= Time.deltaTime;
    }

    public void CompleteTask(GameType type)
    {
        timer = 0;
        if (type == GameType.drink)
        {
            hasDrink = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(interactInput && collision.tag == "Player" && MinigameManager.instance.state == GameState.idle && !hasDrink)
        {
            Debug.Log("started");
            MinigameManager.instance.StartMinigame(this, GameType.drink);
        }

        interactInput = false;
    }
}
