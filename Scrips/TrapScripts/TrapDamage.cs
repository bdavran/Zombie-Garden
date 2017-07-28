using UnityEngine;
using System.Collections;

public class TrapDamage : MonoBehaviour
{

    public float timeTillDestroyed = 20f;
    public float Damage;
    public float CoolDown;
    private float cd;
    private SetTower tiletakenscript;
    // Use this for initialization
    void Start()
    {
        tiletakenscript = GameObject.Find("GameLogic").GetComponent<SetTower>();
    }

    // Update is called once per frame
    void Update()
    {
        timeTillDestroyed -= Time.deltaTime;
        if (cd > 0)
        {

            cd -= Time.deltaTime;

        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.one, out hit, 1))
        {
            if (hit.transform.tag == "enemy")
            {
                if (cd <= 0)
                {
                    Health healthscript = hit.transform.gameObject.GetComponent<Health>();
                    healthscript.health -= Damage;
                    cd = CoolDown;
                }

            }

        }
        if(timeTillDestroyed <= 0)
        {
            Destroy(gameObject);
            tiletakenscript.TileTakensSetFalse();
        }
    }
}
