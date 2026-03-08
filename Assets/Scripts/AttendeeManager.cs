using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    [SerializeField] float toastInterval;

    NPCScript[] attendees;

    float toastTimer;

    private void Start()
    {
        attendees = FindObjectsByType<NPCScript>(FindObjectsSortMode.None);
        toastTimer = toastInterval;
    }

    private void Update()
    {
        toastTimer-=Time.deltaTime;
        if (toastTimer <= 0)
        {
            foreach (NPCScript attendee in attendees)
            {
                if (!attendee.hasDrink)
                {
                    Debug.Log("you lost, not enough people have drinks!");
                }
            }
        }
    }
}
