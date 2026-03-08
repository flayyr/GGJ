using UnityEngine;

public enum GameState { idle, inGame }
public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public GameState state = GameState.idle;
    private NPCScript currNPC;

    private void Awake()
    {
        instance = this;
    }

    public void StartMinigame(NPCScript npc)
    {
        state = GameState.inGame;
        currNPC = npc;
    }

    public void EndMinigame()
    {
        state = GameState.idle;
        currNPC.CompleteTask();
    }
}
