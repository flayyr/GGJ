using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] public PointerScript pointer;
    [SerializeField] public float irritationThreshold;

    protected float irritateTimer = 0;

    public virtual void CompleteTask(GameType type, bool success)
    {
        
    }

    public virtual void CompleteTask(GameType type, int level)
    {

    }
}
