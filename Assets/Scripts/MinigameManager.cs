using UnityEngine;

public enum GameState { idle, inGame }
public enum GameType { none, drink, food, deliver, clean, chat}

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    [SerializeField] minigameExit drinkMinigame;
    [SerializeField] minigameExit cleanMinigame;
    [SerializeField] minigameExit shrimpMinigame;
    [SerializeField] minigameExit chatMinigame;

    [HideInInspector] public GameState state = GameState.idle;
    [HideInInspector] public GameType gametype = GameType.none;
    private NPCScript currNPC;

    private void Awake()
    {
        instance = this;
    }

    public void StartMinigame(NPCScript npc, GameType type)
    {
        if (state == GameState.inGame)
        {
            return;
        }
        state = GameState.inGame;
        gametype = type;
        currNPC = npc;
        if (type == GameType.drink)
        {
            Instantiate(drinkMinigame);
        }
        else if (type == GameType.deliver)
        {
            EndMinigame(true);
        }
        else if (type == GameType.clean)
        {
            Instantiate(cleanMinigame);
        }
        else if (type == GameType.food)
        {
            Instantiate(shrimpMinigame);
        }
        else if (type == GameType.chat)
        {
            Instantiate(chatMinigame);
        }
    }

    public void EndMinigame(bool success)
    {
        state = GameState.idle;
        if (currNPC != null)
        {
            currNPC.CompleteTask(gametype, success);
        } else
        {
            PlayerScript.instance.hasFood = true;
        }
    }

    public void EndMinigame(int level)
    {
        state = GameState.idle;
        if (currNPC != null)
        {
            currNPC.CompleteTask(gametype, level);
        }
    }
}
