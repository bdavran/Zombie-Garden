using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float MovementSpeed;
    public bool canmove;
    public float initvalue;
    public GameObject enemyAI;
    public Vector3 initpos1;
    public Vector3 initpos2;
    public float TimeTillPositionChange;
    public float upperTime = 4f;
    public float lowerTime = 2f;
    public GameObject zombi;
    public GameObject EnemyFast;

    // Use this for initialization
    void Start() {
        TimeTillPositionChange = upperTime;

        initvalue = MovementSpeed;
        initpos1 = new Vector3(0, 0, 1.2f);
        initpos2 = new Vector3(0, 0, -1.2f);


    }
        // Update is called once per frame
        void Update () {

        TimeTillPositionChange -= Time.deltaTime;
            if (canmove)
            {/*
           zombi.GetComponent<Animation>().Play("walk");
            
            if(EnemyFast)
            {
                EnemyFast.GetComponent<Animation>().Play("run");
            }*/
           transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
                if (enemyAI)
                {

                if (TimeTillPositionChange <= upperTime && lowerTime <= TimeTillPositionChange)
                {
                    transform.Translate(initpos1 * MovementSpeed * Time.deltaTime);
                }
                else if(TimeTillPositionChange < lowerTime)
                {
                    transform.Translate(initpos2 * MovementSpeed * Time.deltaTime);
                }



                }
                if(TimeTillPositionChange <0)
            {
                TimeTillPositionChange = upperTime;
            }

            }



        }


    }


