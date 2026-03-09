using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] public PointerScript pointer;
    [SerializeField] public float irritationThreshold;

    protected float irritateTimer = 0;

    public void IncreaseIrritation(float amount)
    {
        irritateTimer += amount;
        if (irritateTimer > irritationThreshold)
        {
            Destroy(gameObject);
            Debug.Log("Too irritated, attendee leaving");
        }
    }

    public virtual void CompleteTask(GameType type, bool success)
    {
        
    }

    public virtual void CompleteTask(GameType type, int level)
    {

    }
}
