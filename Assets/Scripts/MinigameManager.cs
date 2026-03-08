using UnityEngine;

public enum GameState { idle, inGame }
public enum GameType { none, drink, food}

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    [SerializeField] minigameExit drinkMinigame;

    [HideInInspector] public GameState state = GameState.idle;
    [HideInInspector] public GameType gametype = GameType.none;
    private NPCScript currNPC;

    private void Awake()
    {
        instance = this;
    }

    public void StartMinigame(NPCScript npc, GameType type)
    {
        state = GameState.inGame;
        gametype = type;
        currNPC = npc;
        if (type == GameType.drink)
        {
            minigameExit minigame = Instantiate(drinkMinigame);
            minigame.SetPositionToCamera();
        }
    }

    public void EndMinigame(bool success)
    {
        state = GameState.idle;
        currNPC.CompleteTask(gametype);
    }
}
