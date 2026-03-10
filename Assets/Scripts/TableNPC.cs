using UnityEngine;

public class TableNPC : NPCScript
{
    [SerializeField] TableScript table;
    [SerializeField] public float timeToEat;
    [SerializeField] float munchiesIncreasePerFood;

    [SerializeField]float etiquette = 50;
    [SerializeField]float munchies = 50;
    [SerializeField] float reducedIrritationOnFoodDeliver = 10f;

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
            IncreaseIrritation(-reducedIrritationOnFoodDeliver);
            pointer.Hide();
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
            if (etiquette < 0)
            {
                etiquette = 0;
            }
        }
        else
        {
            etiquette += Time.deltaTime * 0.33f;
            if(etiquette > 100f)
            {
                etiquette = 100;
            }
        }

        if (table.state != TableState.eating)
        {
            munchies -= Time.deltaTime;
            if(munchies < 0)
            {
                munchies = 0;
            }
        }

        if (etiquette <= 0)
        {
            pointer.Show(2);
            IncreaseIrritation(Time.deltaTime);
        }else if(munchies <= 0)
        {
            pointer.Show(3);
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
