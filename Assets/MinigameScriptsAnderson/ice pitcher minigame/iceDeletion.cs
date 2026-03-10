using Unity.VisualScripting;
using UnityEngine;

public class iceDeletion : MonoBehaviour
{

    public float timer = 2f;

    private float startY;
    private float startX;

    public float offset;
    public float offsetX;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = gameObject.transform.position.y;
        startX = gameObject.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < startY - offset || gameObject.transform.position.x > startX + offsetX || gameObject.transform.position.x < startX - offsetX)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.linearVelocity.magnitude>8f)
            SFXManager.instance.PlaySound(SFXManager.instance.iceClink);
    }
}
