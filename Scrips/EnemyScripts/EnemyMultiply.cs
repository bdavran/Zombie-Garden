using UnityEngine;
using System.Collections;

public class EnemyMultiply : MonoBehaviour {

    public float CoolDown;
    private float cd;
    public GameObject enemy;
    public Vector3 initpos1;
    // Use this for initialization
    void Start () {
         initpos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
         cd = CoolDown;

    }
	
	// Update is called once per frame
	void Update () {
        if(cd > 0)
        {
            cd -= Time.deltaTime;
        }
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (cd < 0)
        {
            cd = CoolDown;
            if (col.tag == "projectile")
            {
                if (transform.tag == "tile")
                {
                    return;
                }
                else
                {
                    Instantiate(enemy, initpos1, Quaternion.identity);
                }


            }
        }
    }
}
