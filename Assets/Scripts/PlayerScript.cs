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

    private Animator animator;
    public RuntimeAnimatorController[] animations;
    //0 - walk, 1 - idle, 2 - fall, 3 - dash, 4 - shrimp walk, 5 - shrimp idle, 6 - shrimp dash

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
        animator = GetComponent<Animator>();
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
            animator.runtimeAnimatorController = animations[0];
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector2.right;
            animator.runtimeAnimatorController = animations[0];
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector2.up;
            animator.runtimeAnimatorController = animations[0];
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector2.down;
            animator.runtimeAnimatorController = animations[0];
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
            animator.runtimeAnimatorController = animations[2];
            if (dashTimer < 0)
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
