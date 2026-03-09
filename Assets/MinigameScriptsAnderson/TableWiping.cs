using Unity.VisualScripting;
using UnityEngine;

public class TableWiping : MonoBehaviour
{
    [SerializeField] float wipeAmount = 255;
    [SerializeField] minigameExit parent;

    public GameObject stain1;
    public GameObject stain2;
    public GameObject stain3;

    public float timer = 2f;

    public GameObject winCard;

    float dist = 0;
    Vector3 prevPos;

    private void Start()
    {
        prevPos = transform.position;
    }
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        dist += (transform.position - prevPos).magnitude;
        prevPos = transform.position;

        stain1.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, wipeAmount/255);
        stain2.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, wipeAmount/255);
        stain3.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, wipeAmount/255);

        if (winCard.activeInHierarchy)
        {
            timer -= 1f * Time.deltaTime;
        }

        if (timer < 0)
        {
            if (!parent.exit)
            {
                parent.exit = true;
            }
        }


        if (dist >= wipeAmount)
        {
            //parent.exit = true;
            if (!winCard.activeInHierarchy)
            {
                winCard.SetActive(true);
            }
        }
    }
}
