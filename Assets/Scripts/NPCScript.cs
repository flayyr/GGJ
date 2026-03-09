using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] bool moneyMan;
    [SerializeField] public PointerScript pointer;
    [SerializeField] public float irritationThreshold;

    SpriteRenderer spriteRenderer;

    protected float irritateTimer = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IncreaseIrritation(float amount)
    {
        irritateTimer += amount;
        spriteRenderer.color = new Color(1f, 1f - (irritateTimer / irritationThreshold), 1f - (irritateTimer / irritationThreshold), 1f);
        if (irritateTimer >= irritationThreshold)
        {
            Leave();
        }
        if (moneyMan)
        {
            AttendeeManager.instance.attendeesLeft += 100;
            GameEnd.instance.EndGame();
            Debug.Log("die by moneyman");
        }
    }

    protected virtual void Leave()
    {
        AttendeeManager.instance.AttendeeLeave();
        Destroy(gameObject);
        Debug.Log("Too irritated, attendee leaving");
    }

    public virtual void CompleteTask(GameType type, bool success)
    {
        
    }

    public virtual void CompleteTask(GameType type, int level)
    {

    }
}
