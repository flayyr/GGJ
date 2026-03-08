using UnityEngine;

public class pitcherWin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float timer = 2f;

    private bool win;

    public GameObject parentPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timer);

        /*
        if(timer < 0)
        {
            parentPrefab.GetComponent<minigameExit>().exit = true;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ice")
        {
            win = true;
        }
    }


}
