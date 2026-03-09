using UnityEngine;

public enum TableState { clean, eating, dirty }
public class TableScript : MonoBehaviour
{
    [SerializeField] Sprite cleanSprite;
    [SerializeField] Sprite eatingSprite;
    [SerializeField] Sprite dirtySprite;

    TableNPC attendee;
    bool canInteract;
    float eatingTimer;
    SpriteRenderer spriteRenderer;

    public TableState state = TableState.clean;

    public void SetUp(TableNPC attendee)
    {
        this.attendee = attendee;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            if (PlayerScript.instance.hasFood && state==TableState.clean)
            {
                MinigameManager.instance.StartMinigame(attendee, GameType.deliver);
                state = TableState.eating;
                PlayerScript.instance.hasFood = false;
                spriteRenderer.sprite = eatingSprite;
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
                spriteRenderer.sprite = dirtySprite;
                eatingTimer = 0;
            }
        }
    }

    public void Clean()
    {
        state = TableState.clean;
        spriteRenderer.sprite = cleanSprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && MinigameManager.instance.state == GameState.idle)
        {
            canInteract = true;
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
