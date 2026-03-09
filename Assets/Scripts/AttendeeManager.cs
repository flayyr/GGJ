using TMPro;
using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    [SerializeField] float toastInterval;
    [SerializeField] TextMeshProUGUI toastTimerText;

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
        if(toastTimerText!=null)
            toastTimerText.text = "Next Toast: "+Mathf.CeilToInt(toastTimer);
        if (toastTimer <= 0)
        {
            foreach (DrinkNPC attendee in attendees)
            {
                if(attendee==null) continue;

                if (!attendee.hasDrink)
                {
                    attendee.IncreaseIrritation(10);
                }
            }
        }
    }
}
