using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] PointerScript pointer;
    [SerializeField] TableScript table;
    [SerializeField] float irritationThreshold;
    [SerializeField] public float timeToEat;

    public bool hasDrink;

    bool interactInput;
    float irritateTimer = 0;

    float etiquette = 100;
    float munchies = 100;

    private void Awake()
    {
        pointer.Hide();
        table.SetUp(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactInput = true;
        }

        if (table.state == TableState.dirty)
        {
            etiquette -= Time.deltaTime;
        } else
        {
            etiquette += Time.deltaTime;
        }
        munchies -= Time.deltaTime;

        if(munchies<=0 || etiquette <= 0)
        {
            irritateTimer += Time.deltaTime;
            if(irritateTimer > irritationThreshold)
            {
                Debug.Log("Too irritated, attendee leaving");
            }
        }
    }

    public void CompleteTask(GameType type)
    {
        if (type == GameType.drink)
        {
            hasDrink = true;
        }
        else if (type == GameType.deliver)
        {
            munchies += 50;
        }
        else if (type == GameType.clean)
        {
            table.Clean();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactInput && collision.tag == "Player" && MinigameManager.instance.state == GameState.idle&& !hasDrink)
        {
            MinigameManager.instance.StartMinigame(this, GameType.drink);
        }
    }

    private void FixedUpdate()
    {
        if (interactInput)
        {
            Invoke("Uninteract", 0);
        }
    }
    private void Uninteract()
    {
        interactInput=false;
    }
}
