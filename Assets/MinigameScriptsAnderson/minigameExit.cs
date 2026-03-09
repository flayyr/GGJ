using UnityEngine;
using UnityEngine.UIElements;

public class minigameExit : MonoBehaviour
{
    [SerializeField] float killXOffset;

    private float startX;
    public bool win = true;

    public bool exit = false;

    private float leaveSpeed = -1f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(PlayerScript.instance.transform.position.x, PlayerScript.instance.transform.position.y, 0f);
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (exit == true)
        {
            leaveSpeed -= 20f * Time.deltaTime;
            transform.position = transform.position + new Vector3(leaveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x < startX + killXOffset)
            {
                MinigameManager.instance.EndMinigame(win);
                Destroy(gameObject);
            }
        } 
    }
}
