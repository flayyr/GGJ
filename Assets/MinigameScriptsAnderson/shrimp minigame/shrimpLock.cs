using UnityEditor.SceneManagement;
using UnityEngine;

public class shrimpLock : MonoBehaviour
{
    public float angle;

    public bool occupied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "shrimp" && !occupied)
        {

            if (!other.gameObject.GetComponent<shrimpStats>().moving)
            {
                other.gameObject.GetComponent<shrimpStats>().locked = true;
            }
        }
    }
    */
}
