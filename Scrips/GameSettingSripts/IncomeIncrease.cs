using UnityEngine;
using System.Collections;

public class IncomeIncrease : MonoBehaviour {
    public float Cooldown;
    private float cd;
    public float income;
    private Money moneyscript;

	// Use this for initialization
	void Start () {
        moneyscript = GameObject.Find("GameLogic").GetComponent<Money>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cd > 0)
        {
            cd -= Time.deltaTime;


        }
        else
        {
            cd = Cooldown;
            moneyscript.money += income;

        }
        
	
	}
}
