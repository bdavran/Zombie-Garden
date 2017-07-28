using UnityEngine;
using System.Collections;
using System;

public class ProjectilePoison : MonoBehaviour
{


    private bool poisoned;
    public ParticleEmitter fireEffect;
    public float MovementSpeed;
    public float Damage;
    private float HpOfEnemy;
    public Vector3 initpos;
    public GameObject explosion;   
    private EnemyMove movesSlowscript;
    private Health healthscript;   
    private float cd;
    private float hp;
   

    


    // Use this for initialization
    void Start()
    {
        initpos = transform.position;
        healthscript = gameObject.GetComponent<Health>();
        
        

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, initpos) > 20)
        {
            Destroy(gameObject);
        }

    }
    IEnumerator DoFireDamage(float damageDuration, int damageCount, float damageAmount,float hp)
    {
        
        poisoned = true;
        int currentCount = 0;
        while (currentCount < damageCount)
        {       
            hp -= damageAmount;
            yield return new WaitForSeconds(damageDuration);
            currentCount++;
        }
        poisoned= false;
    }
    void OnTriggerEnter(Collider col)
    {
       

        if (col.tag == "enemy" && (!poisoned))
        {
            
            HpOfEnemy  = col.GetComponent<Health>().health;
            StartCoroutine(DoFireDamage(3, 4, 20,HpOfEnemy));
            col.GetComponent<Health>().health -= Damage;
            Destroy(gameObject);
        }
       
    }

    
}
    



