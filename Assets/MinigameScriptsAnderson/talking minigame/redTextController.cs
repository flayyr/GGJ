using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redTextController : MonoBehaviour
{
    //turn this ON for randomization leave it off if you want to choose a specific one
    public bool rando;

    [SerializeField] portraitController portraitController;

    private TextMeshProUGUI tmp;

    private int randNum;
    private string randWord;

    public string[] sansWords;

    public int select;
    //0 for woman (backstabber), 1 for man with glass (dead parents), 2 for crossed arms man (politics)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetUp()
    {
        tmp = GetComponent<TextMeshProUGUI>();

        if (rando)
        {
            randNum = Mathf.FloorToInt(Random.Range(0, 3));
            randWord = sansWords[randNum];

            tmp.text = randWord;
        }
        else
        {
            tmp.text = sansWords[select];
        }

        portraitController.SetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
