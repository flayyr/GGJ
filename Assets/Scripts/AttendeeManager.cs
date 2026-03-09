using TMPro;
using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    public static AttendeeManager instance;

    [SerializeField] float toastInterval;
    [SerializeField] int numOfToasts;
    [SerializeField] float endingTimeLength;
    [SerializeField] TextMeshProUGUI toastTimerText;

    [HideInInspector]public int attendeesLeft = 0;

    DrinkNPC[] attendees;

    float toastTimer;
    int currToast = 0;

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
        if (toastTimerText != null)
        {
            if (currToast == numOfToasts)
            {
                if (toastTimer < 0)
                {
                    toastTimer = 0;
                }
                toastTimerText.text = "Time 'til Clock Out: " + Mathf.CeilToInt(toastTimer);
            } else
            if (currToast == numOfToasts - 1)
            {
                toastTimerText.text = "Final Toast: " + Mathf.CeilToInt(toastTimer);
            }
            else
            {
                toastTimerText.text = "Next Toast: " + Mathf.CeilToInt(toastTimer);
            }
        }
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
            currToast++;
            if (currToast == numOfToasts)
            {
                GameEnd.instance.finalTimerLength = endingTimeLength;
                GameEnd.instance.ending = true;
                toastInterval = endingTimeLength;
            }
        }
    }
}
