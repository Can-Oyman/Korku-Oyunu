using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f; // d��man�n can� 100
    EnemyAI enemy;
    public GameObject bloodEffectPng; // �ld���nde ortaya ��kan png kan

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

    public void ReduceHealth(float azalancan)  // d��mana giden her mermide ne kadar  can�n gitti�ini g�steren metod   *public ile yazma sebebim pistol scriptten  bu metoda ula�abilmek*
    {

        
        enemyHealth -= azalancan; // d��man can�n� her seferinde  azalancan miktar� kadar d���r.
        
        if( !enemy.isDead)
        {
            enemy.Hurt();
        }


        if(enemyHealth == 0) // E�er d��man�n sa�l���  0 ve  0 a e�itse
        {
            Dead();
            enemy.DeadAnim(); //EnemyAI den �ekti�imiz zombibinin �l�m animasyonu

        }
            
   
    }


    void Dead() 
    { 
        bloodEffectPng.SetActive(true);
      enemy.canAttack = false; //zombi �ld�kten sonra Enemey A� deki enemynin sald�r�s�n� durdur
        Destroy(gameObject,10f);
         
    }


}
