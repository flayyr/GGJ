using TMPro;
using UnityEngine;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        int attendeesLeft = AttendeeManager.instance.attendeesLeft;

        if(attendeesLeft<=0)
        {
            scoreText.text = "S";
        }
        else if(attendeesLeft == 1)
        {
            scoreText.text = "A";
        }
        else if (attendeesLeft == 2)
        {
            scoreText.text = "B";
        }
        else if (attendeesLeft == 3)
        {
            scoreText.text = "C";
        }
        else if (attendeesLeft == 4)
        {
            scoreText.text = "D";
        }
        else if (attendeesLeft >= 5)
        {
            scoreText.text = "F";
        }
    }
}
