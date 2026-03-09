using UnityEngine;

public class CocktailBar : MonoBehaviour
{
    private bool canInteract;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            MinigameManager.instance.StartMinigame(null, GameType.food);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && MinigameManager.instance.state == GameState.idle && !PlayerScript.instance.hasFood)
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
