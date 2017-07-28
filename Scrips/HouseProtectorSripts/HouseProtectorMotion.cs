using UnityEngine;
using System.Collections;

public class HouseProtecterMotion : MonoBehaviour {

    public float MovementSpeed;
    public bool canmove;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (canmove)
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);


        }

    }
}
