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
    [SerializeField] float stepDistance;

    [HideInInspector]public bool hasFood;

    bool dashing;
    float crashTimer;
    float dashTimer;
    Vector2 prevMoveDir;

    Rigidbody2D rb;
    SpriteRenderer sprender;
    private Animator animator;
    public RuntimeAnimatorController[] animations;
    //0 - walk, 1 - idle, 2 - fall, 3 - dash, 4 - shrimp walk, 5 - shrimp idle, 6 - shrimp dash

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    Vector3 lastStepPosition;

    void Update()
    {
        if (!dashing && (transform.position - lastStepPosition).magnitude > stepDistance)
        {
            lastStepPosition = transform.position;
            SFXManager.instance.PlaySound(SFXManager.instance.footsteps);
        }


        if (MinigameManager.instance.state == GameState.inGame || crashTimer>0)
        {
            rb.linearVelocity = Vector3.zero;
            crashTimer -= Time.deltaTime;
            return;
        }

        //anderson's nested if statement fix for moonwalking, im sorry for this GENERATIONAL FAMILY REUNION
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            if (dashing)
            {
                if (!hasFood)
                {
                    animator.runtimeAnimatorController = animations[3];
                }
                else if (hasFood)
                {
                    animator.runtimeAnimatorController = animations[6];
                }
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (dashing)
            {
                if (!hasFood)
                {
                    animator.runtimeAnimatorController = animations[3];
                }
                else if (hasFood)
                {
                    animator.runtimeAnimatorController = animations[6];
                }
            }
        }
        else if (!Input.anyKey && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[1];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[5];
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[1];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[5];
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && !dashing)
        {
            if (prevMoveDir == Vector2.right)
            {
                sprender.flipX = true;
            }
            else if (prevMoveDir == Vector2.left)
            {
                sprender.flipX = false;
            }

            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[1];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[5];
            }
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[1];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[5];
            }
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && !dashing)
        {
            if (prevMoveDir == Vector2.right)
            {
                sprender.flipX = true;
            }
            else if (prevMoveDir == Vector2.left)
            {
                sprender.flipX = false;
            }

            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[1];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[5];
            }
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !dashing)
        {
            sprender.flipX = false;
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
        }
        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && !dashing)
        {
            sprender.flipX = true;
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
        }
        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && !dashing)
        {
            if (!hasFood)
            {
                animator.runtimeAnimatorController = animations[0];
            }
            else if (hasFood)
            {
                animator.runtimeAnimatorController = animations[4];
            }
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
            prevMoveDir = moveDir;
        }

        dashTimer -= Time.deltaTime;

        if (!dashing && dashTimer < 0 && Input.GetKey(KeyCode.LeftShift))
        {
            dashing = true;
            rb.linearVelocity = prevMoveDir * moveSpeed * dashAmount;
            dashTimer = dashDuration;
            SFXManager.instance.PlaySound(SFXManager.instance.dash);
        }

        if (dashing)
        {
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
            animator.runtimeAnimatorController = animations[2];
            crashTimer = crashDuration;
            hasFood = false;
            if (collision.gameObject.tag == "NPC")
            {
                collision.gameObject.GetComponent<NPCScript>().IncreaseIrritation(10f);
            }

            SFXManager.instance.PlaySound(SFXManager.instance.collisions);
        }
    }
}
