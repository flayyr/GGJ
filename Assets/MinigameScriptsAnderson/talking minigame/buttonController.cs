using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    private void PressButton(int num)
    {

    }

    public void Button1()
    {
        PressButton(0);
    }
    public void Button2()
    {
        PressButton(1);
    }
    public void Button3()
    {
        PressButton(2);
    }
}
