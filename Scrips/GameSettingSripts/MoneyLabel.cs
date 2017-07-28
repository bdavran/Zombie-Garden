using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyLabel : MonoBehaviour {
    public Money moneyscript;
    public Text moneytext;
        
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.moneytext.text = "Money: " + this.moneyscript.money;
	}
}
