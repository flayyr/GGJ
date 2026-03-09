using UnityEngine;

public class DrinkNPC : NPCScript
{
    [SerializeField] float baseSociability;

    public bool hasDrink;

    bool canInteract;

    float sociability;

    private void Awake()
    {
        sociability = baseSociability+Random.Range(0f,10f);
        pointer.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract && MinigameManager.instance.state == GameState.idle)
        {
            MinigameManager.instance.StartMinigame(this, GameType.drink);
        }

        sociability -= Time.deltaTime;

        if (sociability <= 0)
        {
            pointer.Show(1);
        }else if (!hasDrink)
        {
            pointer.Show(0);
        }
        else
        {
            pointer.Hide();
        }
    }

    public override void CompleteTask(GameType type, bool success)
    {
        if (type == GameType.drink)
        {
            if (success)
            {
                hasDrink = true;
                canInteract = false;
            }
            else
            {
                IncreaseIrritation(10);
            }
        }
    }

    public override void CompleteTask(GameType type, int level)
    {
        if (type == GameType.chat)
        {
            if (level==0)
            {
                IncreaseIrritation(10);
                sociability = baseSociability;
            }
            else if(level==1)
            {
                sociability = baseSociability * 0.8f;
            } else
            {
                sociability = baseSociability * 2f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (sociability<0)
            {
                MinigameManager.instance.StartMinigame(this, GameType.chat);
                canInteract = false;
            } else if (!hasDrink)
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = false;
        }
    }
}
