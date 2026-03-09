using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    [SerializeField] float toastInterval;

    DrinkNPC[] attendees;

    float toastTimer;

    private void Start()
    {
        attendees = FindObjectsByType<DrinkNPC>(FindObjectsSortMode.None);
        toastTimer = toastInterval;
    }

    private void Update()
    {
        toastTimer-=Time.deltaTime;
        if (toastTimer <= 0)
        {
            foreach (DrinkNPC attendee in attendees)
            {
                if (!attendee.hasDrink)
                {
                    Debug.Log("you lost, not enough people have drinks!");
                }
            }
        }
    }
}
