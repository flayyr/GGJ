using Unity.Hierarchy;
using Unity.XR.GoogleVr;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    [SerializeField] float moveSpeed;
    [SerializeField] float dashAmount;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCD;
    [SerializeField] float crashDuration;

    [HideInInspector]public bool hasFood;

    bool dashing;
    float crashTimer;
    float dashTimer;
    Vector2 prevMoveDir;

    Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (MinigameManager.instance.state == GameState.inGame || crashTimer>0)
        {
            rb.linearVelocity = Vector3.zero;
            crashTimer -= Time.deltaTime;
            return;
        }

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

        if (moveDir != Vector2.zero)
        {
            prevMoveDir= moveDir;
        }


        dashTimer -= Time.deltaTime;

        if (!dashing && dashTimer<0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashing = true;
            rb.linearVelocity = prevMoveDir * moveSpeed * dashAmount;
            dashTimer = dashDuration;
        }

        if (dashing)
        {
            if(dashTimer < 0)
            {
                dashing = false;
                dashTimer = dashCD;
            }
        }
        else
        {
            rb.linearVelocity = moveDir * moveSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dashing)
        {
            crashTimer = crashDuration;
        }
    }
}
