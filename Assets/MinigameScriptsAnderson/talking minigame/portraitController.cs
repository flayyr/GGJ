using UnityEngine;

public class portraitController : MonoBehaviour
{

    public GameObject redRef;

    public RuntimeAnimatorController[] portraits;
    private Animator animator;

    private int refNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetUp()
    {
        animator = GetComponent<Animator>();
        refNum = redRef.GetComponent<redTextController>().select;
        animator.runtimeAnimatorController = portraits[refNum];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
