using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int NumOut;
    public Text scoreText;
    public float inipause;
    public GameObject[] Enemies;
    public float Cooldown;
    private float cd;
    private int score = 0;
    

	// Use this for initialization
	void Start () {
        cd = Cooldown *inipause;
        scoreText.text = score.ToString();

	}
	
	// Update is called once per frame
	void Update () {
	    if(cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            cd = Cooldown;
            Vector3 pos = new Vector3(9, 2, Random.Range(3, -2));
            int index = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[index], pos, Quaternion.identity);
            NumOut++;
            
        }
	}
    public void resetcd()
    {
        cd = Cooldown;
    }
    public void Add(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
    
}
