using UnityEngine;

public class PointerScript : MonoBehaviour
{
    public Transform targetTransform;
    [SerializeField] float pointerDist;
    [SerializeField] Sprite noDrink;
    [SerializeField] Sprite social;
    [SerializeField] Sprite table;
    [SerializeField] Sprite hungry;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void Update()
    {
        //Vector3 targetViewportPos = Camera.main.WorldToViewportPoint(targetTransform.position);
        //if(targetViewportPos.x>0&&targetViewportPos.x<1 &&  targetViewportPos.y>0 && targetViewportPos.y < 1)
        //{
        //    transform.position = targetTransform.position;
        //}
        //else
        //{
        //    targetViewportPos -= new Vector3(0.5f, 0.5f, 0f);
        //    targetViewportPos = new Vector3(targetViewportPos.x,targetViewportPos.y,0f).normalized;
        //    Vector3 intersectX = targetViewportPos * (1 / Mathf.Abs(targetViewportPos.x));
        //    Vector3 intersectY = targetViewportPos * (1 / Mathf.Abs(targetViewportPos.y));
        //    float dist = Mathf.Min(intersectX.magnitude, intersectY.magnitude);
        //    transform.position = targetViewportPos.normalized* pointerDist + PlayerScript.instance.transform.position;
        //}

        Vector2 difference = targetTransform.position - PlayerScript.instance.transform.position;
        if (difference.magnitude < pointerDist)
        {
            transform.position = targetTransform.position;
        }
        else
        {
            transform.position = (Vector2)PlayerScript.instance.transform.position+difference.normalized*pointerDist;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(int spriteIndex)
    {
        gameObject.SetActive(true);

        if (spriteIndex == 0)
        {
            spriteRenderer.sprite = noDrink;
        }
        else if(spriteIndex == 1)
        {
            spriteRenderer.sprite = social;
        }else if (spriteIndex == 2)
        {
            spriteRenderer.sprite = table;
        } else if(spriteIndex == 3)
        {
            spriteRenderer.sprite = hungry;
        }
    }


}
