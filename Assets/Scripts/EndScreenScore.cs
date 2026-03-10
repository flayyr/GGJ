using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public Sprite[] scoreImg;
    public RuntimeAnimatorController S;
    private Animator toUse;

    //public int attendeesLeft;

    public Image imgChange;

    private void Start()
    {

        toUse = GetComponent<Animator>();

        
        FadeToWhite.instance.FadeIn();
        int attendeesLeft = AttendeeManager.instance.attendeesLeft;

        if(attendeesLeft<=0)
        {
            //scoreText.text = "S";
            imgChange.sprite = scoreImg[5];
            //toUse.runtimeAnimatorController = S;
            imgChange.GetComponent<Animator>().runtimeAnimatorController = S;
        }
        else if (attendeesLeft == 1)
        {
            //scoreText.text = "A";
            imgChange.sprite = scoreImg[0];
        }
        else if (attendeesLeft == 2)
        {
            //scoreText.text = "B";
            imgChange.sprite = scoreImg[1];
        }
        else if (attendeesLeft == 3)
        {
            //scoreText.text = "C";
            imgChange.sprite = scoreImg[2];
        }
        else if (attendeesLeft == 4)
        {
            //scoreText.text = "D";
            imgChange.sprite = scoreImg[3];
        }
        else if (attendeesLeft >= 5)
        {
            //scoreText.text = "F";
            imgChange.sprite = scoreImg[4];
        }
        
    }

    private void Update()
    {
        /*
        if (attendeesLeft <= 0)
        {
            //scoreText.text = "S";
            imgChange.sprite = scoreImg[5];
            //toUse.runtimeAnimatorController = S;
            imgChange.GetComponent<Animator>().runtimeAnimatorController = S;
        }
        else if (attendeesLeft == 1)
        {
            //scoreText.text = "A";
            imgChange.sprite = scoreImg[0];
        }
        else if (attendeesLeft == 2)
        {
            //scoreText.text = "B";
            imgChange.sprite = scoreImg[1];
        }
        else if (attendeesLeft == 3)
        {
            //scoreText.text = "C";
            imgChange.sprite = scoreImg[2];
        }
        else if (attendeesLeft == 4)
        {
            //scoreText.text = "D";
            imgChange.sprite = scoreImg[3];
        }
        else if (attendeesLeft >= 5)
        {
            //scoreText.text = "F";
            imgChange.sprite = scoreImg[4];
        }
        */
    }
}
