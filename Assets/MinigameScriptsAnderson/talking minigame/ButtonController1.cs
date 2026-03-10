using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController1 : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] minigameExit parent;
    [SerializeField] redTextController redTextController;
    [SerializeField] TextMeshProUGUI matchText;
    [SerializeField] float talkSoundInterval;

    int prevButton = -1;
    int progress = 0;

    float talkTimer = 0;
    private void Update()
    {
        talkTimer += Time.deltaTime;
        if(talkTimer > talkSoundInterval)
        {
            talkTimer = 0;
            SFXManager.instance.PlaySound(SFXManager.instance.talk);
        }
    }

    private void ShuffleButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            Swap(buttons[Random.Range(0, 3)].transform, buttons[Random.Range(0, 3)].transform);
        }
    }

    public void SetRedTextIndex(int index)
    {
        redTextController.select = index;
        redTextController.SetUp();
        matchText.text = redTextController.sansWords[index];
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
            parent.EndTalk(2);
            parent.exit = true;
        }
        prevButton = 0;
        ShuffleButtons();

        SFXManager.instance.PlaySound(SFXManager.instance.menuPress);
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
            parent.EndTalk(1);
            parent.exit = true;
        }
        prevButton = 1;
        ShuffleButtons();

        SFXManager.instance.PlaySound(SFXManager.instance.menuPress);
    }

    public void RunAway()
    {
        parent.EndTalk(0);
        parent.exit = true;

        SFXManager.instance.PlaySound(SFXManager.instance.menuPress);
    }
}
