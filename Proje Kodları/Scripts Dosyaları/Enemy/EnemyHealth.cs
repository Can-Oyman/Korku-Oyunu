using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f; // düþmanýn caný 100
    EnemyAI enemy;
    public GameObject bloodEffectPng; // öldüðünde ortaya çýkan png kan

    void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth<=0) { 
           enemyHealth = 0;
        }
        
    }

    public void ReduceHealth(float azalancan)  // düþmana giden her mermide ne kadar  canýn gittiðini gösteren metod   *public ile yazma sebebim pistol scriptten  bu metoda ulaþabilmek*
    {

        
        enemyHealth -= azalancan; // düþman canýný her seferinde  azalancan miktarý kadar düþür.
        
        if( !enemy.isDead)
        {
            enemy.Hurt();
        }


        if(enemyHealth == 0) // Eðer düþmanýn saðlýðý  0 ve  0 a eþitse
        {
            Dead();
            enemy.DeadAnim(); //EnemyAI den çektiðimiz zombibinin ölüm animasyonu

        }
            
   
    }


    void Dead() 
    { 
        bloodEffectPng.SetActive(true);
      enemy.canAttack = false; //zombi öldükten sonra Enemey Aý deki enemynin saldýrýsýný durdur
        Destroy(gameObject,10f);
         
    }


}
