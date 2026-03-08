using UnityEngine;

public class pitcherWin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float timer = 2f;

    //private bool win;

    public GameObject winCard;

    public GameObject parentPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winCard.activeInHierarchy)
        {
            timer -= 1f * Time.deltaTime;
        }

        if(timer < 0)
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
            Debug.Log("yo");
            if (!winCard.activeInHierarchy)
            {
                Debug.Log("activating");
                winCard.SetActive(true);
            }
        }
    }


}
