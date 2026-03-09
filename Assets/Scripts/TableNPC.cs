using UnityEngine;

public class TableNPC : NPCScript
{
    [SerializeField] TableScript table;
    [SerializeField] public float timeToEat;

    float etiquette = 100;
    float munchies = 100;

    private void Awake()
    {
        table.SetUp(this);
        irritateTimer -= Random.Range(0f, 5f);
    }

    public override void CompleteTask(GameType type, bool success)
    {
        if (type == GameType.deliver)
        {
            munchies += 50;
        }
        else if (type == GameType.clean)
        {
            table.Clean();
        }
    }

    private void Update()
    {
        if (table.state == TableState.dirty)
        {
            etiquette -= Time.deltaTime;
        }
        else
        {
            etiquette += Time.deltaTime;
        }
        munchies -= Time.deltaTime;

        if (munchies <= 0 || etiquette <= 0)
        {
            irritateTimer += Time.deltaTime;
            if (irritateTimer > irritationThreshold)
            {
                Debug.Log("Too irritated, attendee leaving");
            }
        }
        else
        {
            irritateTimer -= Time.deltaTime * 0.5f;
            if (irritateTimer < 0)
            {
                irritateTimer = 0;
            }
        }
    }
}
