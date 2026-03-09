using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] PointerScript pointer;
    [SerializeField] public bool standing;
    [SerializeField] TableScript table;
    [SerializeField] float irritationThreshold;
    [SerializeField] public float timeToEat;

    public bool hasDrink;

    bool canInteract;
    float irritateTimer = 0;

    float etiquette = 100;
    float munchies = 100;

    private void Awake()
    {
        pointer.Hide();
        if(!standing)
            table.SetUp(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            MinigameManager.instance.StartMinigame(this, GameType.drink);
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
        }else
        {
            irritateTimer -= Time.deltaTime * 0.5f;
            if (irritateTimer < 0)
            {
                irritateTimer = 0;
            }
        }
    }

    public void CompleteTask(GameType type, bool success)
    {
        if (type == GameType.drink)
        {
            if (success)
            {
                hasDrink = true;
            } else
            {
                irritateTimer += 10;
            }
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
        if (standing && collision.tag == "Player" && MinigameManager.instance.state == GameState.idle&& !hasDrink)
        {
            canInteract = true;
        }
    }
}
