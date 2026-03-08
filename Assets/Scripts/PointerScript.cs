using UnityEngine;

public class PointerScript : MonoBehaviour
{
    public Transform targetTransform;
    [SerializeField] float pointerDist;
    private void Update()
    {
        Vector3 targetViewportPos = Camera.main.WorldToViewportPoint(targetTransform.position);
        if(targetViewportPos.x>0&&targetViewportPos.x<1 &&  targetViewportPos.y>0 && targetViewportPos.y < 1)
        {
            transform.position = targetTransform.position;
        }
        else
        {
            targetViewportPos -= new Vector3(0.5f, 0.5f, 0f);
            targetViewportPos = new Vector3(targetViewportPos.x,targetViewportPos.y,0f).normalized;
            Vector3 intersectX = targetViewportPos * (1 / Mathf.Abs(targetViewportPos.x));
            Vector3 intersectY = targetViewportPos * (1 / Mathf.Abs(targetViewportPos.y));
            float dist = Mathf.Min(intersectX.magnitude, intersectY.magnitude);
            transform.position = targetViewportPos.normalized* pointerDist + PlayerScript.instance.transform.position;
            //transform.position = Camera.main.ViewportToWorldPoint(targetViewportPos * dist) + PlayerScript.Instance.transform.position;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }


}
