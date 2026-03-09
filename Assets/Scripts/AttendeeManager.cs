using TMPro;
using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    public static AttendeeManager instance;

    [SerializeField] float toastInterval;
    [SerializeField] TextMeshProUGUI toastTimerText;

    public int attendeesLeft = 0;

    DrinkNPC[] attendees;

    float toastTimer;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        attendees = FindObjectsByType<DrinkNPC>(FindObjectsSortMode.None);
        toastTimer = toastInterval;
    }

    public void AttendeeLeave()
    {
        attendeesLeft++;
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
                else
                {
                    attendee.hasDrink = false;
                }
            }
            toastTimer = toastInterval;
        }
    }
}
