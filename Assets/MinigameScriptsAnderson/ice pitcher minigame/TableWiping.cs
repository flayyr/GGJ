using Unity.VisualScripting;
using UnityEngine;

public class TableWiping : MonoBehaviour
{
    [SerializeField] float wipeAmount = 300;
    [SerializeField] minigameExit parent;
    float dist = 0;
    Vector3 prevPos;

    private void Start()
    {
        prevPos = transform.position;
    }
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        dist += (transform.position - prevPos).magnitude;
        prevPos = transform.position;

        if (dist >= 300)
        {
            parent.exit = true;
        }
    }
}
