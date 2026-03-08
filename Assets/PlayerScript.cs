using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;

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

        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;
    }
}
