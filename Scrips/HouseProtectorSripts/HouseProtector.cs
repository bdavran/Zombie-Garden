using UnityEngine;
using System.Collections;
using System;



public class HouseProtector : MonoBehaviour
{

    private HouseProtectorMotion movescript;
    public float Damage;
 
    // Use this for initialization
    void Start()
    {
  
        movescript = gameObject.GetComponent<HouseProtectorMotion>();
        movescript.canmove = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, .8F))
        {

            if (hit.transform.tag == "enemy")
            {
                movescript.canmove = true;
                Health healthscript = hit.transform.gameObject.GetComponent<Health>();
                healthscript.health -= Damage;
            }
        }
    }


}



    

