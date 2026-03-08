using Unity.VisualScripting;
using UnityEngine;

public class iceDeletion : MonoBehaviour
{

    public float timer = 2f;

    private float startY;

    public float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < startY - offset)
        {
            Destroy(gameObject);
        }
    }
}
