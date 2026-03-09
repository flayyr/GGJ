using UnityEngine;

public class DrinkNPC : NPCScript
{
    public bool hasDrink;

    bool canInteract;

    float sociability = 30;

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
                Debug.Log("2");
            }
            else
            {
                irritateTimer += 10;
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
