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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            MinigameManager.instance.StartMinigame(this, GameType.drink);
        }

        sociability -= Time.deltaTime;
    }

    public override void CompleteTask(GameType type, bool success)
    {
        if (type == GameType.drink)
        {
            if (success)
            {
                hasDrink = true;
            }
            else
            {
                irritateTimer += 10;
            }
        }
    }

    public override void CompleteTask(GameType type, int level)
    {
        if (type == GameType.chat)
        {
            if (level==0)
            {
                irritateTimer += 10;
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
        if (collision.tag == "Player" && MinigameManager.instance.state == GameState.idle)
        {
            if (sociability<0)
            {
                MinigameManager.instance.StartMinigame(this, GameType.chat);
            }
            if (!hasDrink)
            {
                canInteract = true;
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
