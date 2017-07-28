using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public float Cooldown;
    private float cd;
    public GameObject projectile;
    public bool hasenemy;


    // Use this for initialization
    void Start()
    {
        cd = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;


        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 8))//raycast hit belli bir uzaklıkta aynı doğrultuda gördüğü zaman düşmanı aktif olmasını sağlıyor
        {

            if (hit.transform.tag == "enemy")
            {
                if (cd <= 0)
                {
                    cd = Cooldown;
                    Instantiate(projectile, transform.position, Quaternion.identity);
                }
                hasenemy = true;

            }
            else if (hit.transform.tag == "tower")
            {
                Shoot shootscript = hit.transform.gameObject.GetComponent<Shoot>();
                if (shootscript.hasenemy)
                {
                    hasenemy = true;
                }
                else
                {
                    hasenemy = false;
                }
            }
            else
            {

                hasenemy = false;

            }

        }
        else
        {
            hasenemy = false;
        }
        if (hasenemy)
        {
            if (cd <= 0)
            {
                cd = Cooldown;
                Instantiate(projectile, transform.position, Quaternion.identity);
            }
        }
    }
}

      
	


