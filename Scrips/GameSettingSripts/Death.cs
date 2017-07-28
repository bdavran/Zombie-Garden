using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

    public bool isTower;
    private Health healthscript;
    private Money moneyscript;
    private EnemyStats enemyscript;
    private LevelManager levelmanmagerscript;
    private SetTower tiletakenscript;


    // Use this for initialization
    void Start()
    {
        tiletakenscript = GameObject.Find("GameLogic").GetComponent<SetTower>();
        levelmanmagerscript = GameObject.Find("GameLogic").GetComponent<LevelManager>();
        healthscript = gameObject.GetComponent<Health>();
        moneyscript = GameObject.Find("GameLogic").GetComponent<Money>();
        if (!isTower)
        {
            enemyscript = gameObject.GetComponent<EnemyStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthscript.health <= 0)
        {
            if (isTower)
            {
                Destroy(gameObject);
                tiletakenscript.TileTakensSetFalse();
            }
            else
            {
                moneyscript.money += enemyscript.worth;               
                Destroy(gameObject);
                levelmanmagerscript.Add(100);
                

            }

        }

    }
}
