using UnityEngine;

public enum TableState { clean, eating, dirty }
public class TableScript : MonoBehaviour
{
    NPCScript attendee;
    bool canInteract;
    float eatingTimer;

    public TableState state = TableState.clean;

    public void SetUp(NPCScript attendee)
    {
        this.attendee = attendee;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            if (PlayerScript.instance.hasFood)
            {
                MinigameManager.instance.StartMinigame(attendee, GameType.deliver);
                state = TableState.eating;
                PlayerScript.instance.hasFood = false;
            }
            else if (state == TableState.dirty)
            {
                MinigameManager.instance.StartMinigame(attendee, GameType.clean);
            }
        }

        if (state == TableState.eating)
        {
            eatingTimer += Time.deltaTime;
            if (eatingTimer > attendee.timeToEat)
            {
                state = TableState.dirty;
            }
        }
    }

    public void Clean()
    {
        state = TableState.clean;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && MinigameManager.instance.state == GameState.idle)
        {
            canInteract = true;
        }
    }
}
