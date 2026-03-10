using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handShrimpMinigame : MonoBehaviour
{
    public Sprite grabbed;
    public Sprite openHand;

    public GameObject winCard;

    public float timer = 2f;

    public GameObject parentPrefab;

    public float softlockTimer = 25f;

    public int score;

    private GameObject closestShrimp;

    public GameObject child;

    [SerializeField] private bool pinched = false;

    private Vector2 mousePos;

    private SpriteRenderer sprender;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprender = child.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //handles mouse inputs and animations
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButton(0))
        {
            sprender.sprite = grabbed;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sprender.sprite = openHand;
            pinched = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (closestShrimp != null)
            {
                closestShrimp.GetComponent<SpriteRenderer>().sortingOrder += 1;
            }
        }

        softlockTimer -= Time.deltaTime;

        //handles win condition
        if(score >= 8 || softlockTimer <= 0)
        {
            if (!winCard.activeInHierarchy)
            {
                winCard.SetActive(true);
            }
        }

        if (winCard.activeInHierarchy)
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


    private void FixedUpdate()
    {
        if (!winCard.activeInHierarchy)
        {
            rb.MovePosition(mousePos);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "shrimp" && !pinched)
        {
            closestShrimp = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == closestShrimp)
        {

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButton(0) && closestShrimp != null && !closestShrimp.GetComponent<shrimpStats>().locked)
        {
            closestShrimp.GetComponent<Rigidbody2D>().transform.position = rb.transform.position;
            pinched = true;
            closestShrimp.GetComponent<shrimpStats>().moving = true;
        }
    }

}
