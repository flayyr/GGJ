using UnityEditor.SceneManagement;
using UnityEngine;

public class shrimpStats : MonoBehaviour
{

    public bool moving;

    private GameObject closestLock;
    public GameObject handRef;

    private Rigidbody2D rb;

    public bool rotatable;

    private bool added;

    public bool locked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            moving = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "shrimpLock" && !other.gameObject.GetComponent<shrimpLock>().occupied)
        {
            closestLock = other.gameObject;
            //Debug.Log(closestLock);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!moving && closestLock != null && other.gameObject.tag == "shrimpLock" && other.gameObject == closestLock)
        {
            rotatable = false;
            other.gameObject.GetComponent<shrimpLock>().occupied = true;
            locked = true;
            GetComponent<Collider2D>().enabled = false;
            rb.transform.rotation = Quaternion.Euler(0, 0, other.gameObject.GetComponent<shrimpLock>().angle);
            if (!added)
            {
                handRef.GetComponent<handShrimpMinigame>().score++;
                added = true;
                SFXManager.instance.PlaySound(SFXManager.instance.placeShrimp);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == closestLock)
        {
            closestLock = null;
        }
    }

}
