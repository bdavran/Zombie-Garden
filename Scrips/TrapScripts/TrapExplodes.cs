using UnityEngine;
using System.Collections;

public class TrapExplodes : MonoBehaviour {

    public float Damage;
    private SetTower tiletakenscript;
    public float timeTillDestroyed = 20f;

    // Use this for initialization
    void Start () {
        tiletakenscript = GameObject.Find("GameLogic").GetComponent<SetTower>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        timeTillDestroyed -= Time.deltaTime;

        if (Physics.Raycast(transform.position, Vector3.one, out hit, .6F))
        {
            if (hit.transform.tag == "enemy")
            {
                    Health healthscript = hit.transform.gameObject.GetComponent<Health>();
                    healthscript.health -= Damage;
                    Destroy(gameObject);
                    tiletakenscript.TileTakensSetFalse();
            }

        }
        if (timeTillDestroyed <= 0)
        {
            Destroy(gameObject);
            tiletakenscript.TileTakensSetFalse();
        }

    }
    void BombDamage()
    {

    }
    /*
    void Explode()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }
    */
}
