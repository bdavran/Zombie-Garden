using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    private EnemyMove  movescript;
    public float Damage;
    public float CoolDown;
    private float cd;
    


    // Use this for initialization
    void Start () {
        
        movescript = gameObject.GetComponent<EnemyMove>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if(cd > 0)
        {

            cd -= Time.deltaTime;

        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, .6F))
        {
            if (hit.transform.tag == "tower")
            {
                if (cd <= 0)
                {
                    Health healthscript = hit.transform.gameObject.GetComponent<Health>();
                    healthscript.health -= Damage;
                    cd = CoolDown;
                }

            }
            else if (hit.transform.tag == "house")
            {
                GameObject.Find("GameLogic").GetComponent<GameLost>().lost = true;
            }
            
            movescript.canmove = false;
        }
        else if (movescript.canmove == false)

        {
            movescript.canmove = true;
        }
        

    }
}
