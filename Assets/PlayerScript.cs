using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector2.down;
        }

        moveDir = moveDir.normalized;

        rb.linearVelocity = moveDir * moveSpeed;
    }
}
