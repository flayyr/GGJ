using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController1 : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] minigameExit parent;

    int prevButton = -1;
    int progress = 0;

    private void ShuffleButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            Swap(buttons[Random.Range(0, 3)].transform, buttons[Random.Range(0, 3)].transform);
        }
    }

    private void Swap(Transform a, Transform b)
    {
        Vector3 temp = a.position;
        a.position = b.position;
        b.position = temp;
    }

    public void Match()
    {
        if (prevButton != 0)
        {
            progress = 0;
        }
        progress++;
        if(progress >= 6)
        {
            MinigameManager.instance.EndMinigame(2);
            parent.exit = true;
        }
        prevButton = 0;
        ShuffleButtons();
    }

    public void NonCommit()
    {
        if (prevButton != 1)
        {
            progress = 0;
        }
        progress++;
        if (progress >= 3)
        {
            MinigameManager.instance.EndMinigame(1);
            parent.exit = true;
        }
        prevButton = 1;
        ShuffleButtons();
    }

    public void RunAway()
    {
        MinigameManager.instance.EndMinigame(0);
        parent.exit = true;
    }
}
