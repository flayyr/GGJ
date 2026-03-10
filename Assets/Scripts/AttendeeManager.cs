using TMPro;
using UnityEngine;

public class AttendeeManager : MonoBehaviour
{
    public static AttendeeManager instance;

    [SerializeField] float[] toastIntervals;
    [SerializeField] float endingTimeLength;
    [SerializeField] TextMeshProUGUI toastTimerText;
    [SerializeField] ParticleSystem toastParticle;

    [HideInInspector]public int attendeesLeft = 0;

    public int irritatedCount;
    public bool closeToToast;

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
        toastTimer = toastIntervals[currToast];
    }

    public void AttendeeLeave()
    {
        attendeesLeft++;
    }

    private void Update()
    {
        toastTimer-=Time.deltaTime;

        closeToToast = toastTimer<60 && currToast<toastIntervals.Length;

        if (toastTimerText != null)
        {
            if (currToast == toastIntervals.Length)
            {
                if (toastTimer < 0)
                {
                    toastTimer = 0;
                }
                toastTimerText.text = "Time 'til Clock Out: " + Mathf.CeilToInt(toastTimer);
            } else
            if (currToast == toastIntervals.Length - 1)
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
                    attendee.IncreaseIrritation(20);
                }
                else
                {
                    attendee.hasDrink = false;
                }
            }

            toastParticle.Play();
            SFXManager.instance.PlaySound(SFXManager.instance.toast);
            
            currToast++;
            if(currToast<toastIntervals.Length)
                toastTimer = toastIntervals[currToast];
            if (currToast == toastIntervals.Length)
            {
                GameEnd.instance.finalTimerLength = endingTimeLength;
                GameEnd.instance.ending = true;
                toastTimer = endingTimeLength;
            }
        }
    }
}
