using UnityEngine;

public class TableNPC : NPCScript
{
    [SerializeField] TableScript table;
    [SerializeField] public float timeToEat;
    [SerializeField] float munchiesIncreasePerFood;

    float etiquette = 100;
    float munchies = 100;

    private void Awake()
    {
        pointer.Hide();
        table.SetUp(this);
        irritateTimer -= Random.Range(0f, 5f);
    }

    public override void CompleteTask(GameType type, bool success)
    {
        if (type == GameType.deliver)
        {
            munchies += munchiesIncreasePerFood;
        }
        else if (type == GameType.clean)
        {
            table.Clean();
            pointer.Hide();
        }
    }

    protected override void Leave()
    {
        table.Clean();
        Destroy(table);
        base.Leave();
    }

    private void Update()
    {
        if (table.state == TableState.dirty)
        {
            etiquette -= Time.deltaTime;
            pointer.Show(2);
        }
        else
        {
            etiquette += Time.deltaTime;
        }
        munchies -= Time.deltaTime;

        if (munchies <= 0 || etiquette <= 0)
        {
            IncreaseIrritation(Time.deltaTime);
        }
        else
        {
            IncreaseIrritation(-Time.deltaTime * 0.5f);
            if (irritateTimer < 0)
            {
                irritateTimer = 0;
            }
        }
    }
}
