using UnityEngine;
using System.Collections;

public class GameLost : MonoBehaviour {

    public bool lost;
    public GameObject HousePotecter;    
    private Money moneyscript;
    private float initmoney;
    private LevelManager wavemanagerscript;
    // Use this for initialization
    void Start()
    {

        InitiateTowerPotector();
        moneyscript = gameObject.GetComponent<Money>();
        wavemanagerscript = gameObject.GetComponent<LevelManager>();
        initmoney = moneyscript.money;
    }

    // Update is called once per frame
    void Update()
    {
        if (lost)
        {
            lost = false;
            wavemanagerscript.NumOut = 0;
            wavemanagerscript.resetcd();
            GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < towers.Length; i++)
            {

                Destroy(towers[i]);
            }
            for (int j = 0; j < enemies.Length; j++)
            {
                Destroy(enemies[j]);
            }
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");
            for (int n = 0; n < tiles.Length; n++)
            {
                TileTaken tilescript = tiles[n].GetComponent<TileTaken>();
                tilescript.isTaken = false;
            }
            GameObject[] projecitles = GameObject.FindGameObjectsWithTag("projectile");
            for (int k = 0; k < projecitles.Length; k++)
            {
                Destroy(projecitles[k]);
            }
            GameObject[] houseptorectors = GameObject.FindGameObjectsWithTag("houseprotecter");
            for(int a =0;a < houseptorectors.Length;a++)
            {
                Destroy(houseptorectors[a]);
            }
            moneyscript.money = initmoney;
            InitiateTowerPotector();
        }
       

    }
    void InitiateTowerPotector()
    {
        for (int i = -1; i < 4; i++)
        {
            Vector3 pos = new Vector3(-3, 2, i);
            Instantiate(HousePotecter, pos, Quaternion.identity);
        }
    }
}
