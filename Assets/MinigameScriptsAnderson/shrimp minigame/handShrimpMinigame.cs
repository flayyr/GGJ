using UnityEngine;

public class handShrimpMinigame : MonoBehaviour
{

    public Sprite grabbed;
    public Sprite openHand;

    private SpriteRenderer sprender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sprender.sprite = grabbed;
        }
        else
        {
            sprender.sprite = openHand;
        }
    }
}
