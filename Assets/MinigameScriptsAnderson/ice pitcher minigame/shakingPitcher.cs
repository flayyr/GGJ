using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class shakingPitcher : MonoBehaviour
{

    public float wigglePower = 4f;
    public float followSpeed = 4f;
    public float xPositionClamp = -3f;

    //public bool noFollow = false;

    //private float offset;

    private Vector2 mousePos;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //offset = transform.position.x - 4f;
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.rotation *= Quaternion.Euler(0, 0, wigglePower * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.rotation *= Quaternion.Euler(0, 0, -wigglePower * Time.deltaTime);
        }
        else
        {
            rb.transform.rotation *= Quaternion.Euler(0, 0, 0);
        }

        
        
    }

    private void FixedUpdate()
    {
        float clampedX = Mathf.Clamp(mousePos.x, transform.parent.position.x + xPositionClamp, float.MaxValue);
        rb.MovePosition(new Vector2(clampedX, mousePos.y));
    }

}
