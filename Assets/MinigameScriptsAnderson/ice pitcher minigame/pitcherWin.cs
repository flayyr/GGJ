using UnityEngine;

public class pitcherWin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float timer = 2f;

    //private bool win;

    public GameObject winCard;
    public GameObject loseCard;

    private int ice;

    public GameObject parentPrefab;

    void Start()
    {
        ice = GameObject.FindGameObjectsWithTag("ice").Length;
    }

    // Update is called once per frame
    void Update()
    {
        ice = GameObject.FindGameObjectsWithTag("ice").Length;

        if (ice <= 0)
        {
            if (!loseCard.activeInHierarchy)
            {
                loseCard.SetActive(true);
                parentPrefab.GetComponent<minigameExit>().win = false;
            }
        }

        if (winCard.activeInHierarchy)
        {
            timer -= 1f * Time.deltaTime;
        }

        if (loseCard.activeInHierarchy)
        {
            timer -= 1f * Time.deltaTime;
        }

        if (timer < 0)
        {
            if (!parentPrefab.GetComponent<minigameExit>().exit)
            {
                parentPrefab.GetComponent<minigameExit>().exit = true;
                
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ice")
        {
            if (!winCard.activeInHierarchy)
            {
                winCard.SetActive(true);
            }
        }
    }


}
