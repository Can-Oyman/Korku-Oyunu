using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  //Yapay Zekay� kullanmak i�in kl�t�phane ekledik

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent; //yapay zeka nav de�i�keni oyunda Enemy karakterimizin i�inde 
    Animator anim;
    Transform target; //kendi karakterimizin konumu transformu
    public bool isDead=false; // �l� iken 
    public float TurnSpeed; // enemynin d�n�� h�z� AttackPlayer k�sm�nda kullanacag�z
    public bool canAttack; // d��man bize sald�rabilir durumda m� diye tan�mlama yapt�k

    [SerializeField]
    float attackTimer = 4f; // enemy vurma animasyonu ger�ekle�irken 2 saniyede bir can�m�z�n 25f d��mesi i�in timer ataad�k
    
    public float damage = 10f;  // enemynin vurdu�u hasar� damage olarak tan�mlad�k hasar�n� ise 25 olarak belirledik


    void Start()
    {
        canAttack = true; // oyunun ba�lang�c�nda enemy bize hasar verebilecek olarak ayarlad�m
        agent = GetComponent<NavMeshAgent>(); // agenti �a��rd���m�zda componentimize ula�abilmek i�in 
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform; //tagi player olan gami objesini bul ve transformunu bul yani karakterimizin tagi ve transformu

        
    }

    // Update is called once per frame
    void Update()
    {
        float distance=Vector3.Distance(transform.position, target.position); // 3 boyutlu d�nyada zombinin pozisyonundan ,  karakterimizin targetin pozisyonuna gidecek

        if(distance <10 && distance>agent.stoppingDistance && !isDead)  // enemye att���m�z  nav mesh agentteki stoppingDistance de�erini ne girdiysek ona g�re durmas�n� istiyoryz
        {
            ChasePlayer();
        }
        else if (distance < agent.stoppingDistance && canAttack  ) //  playerim �l� de�ilse
        {
            agent.updateRotation = false; // pozisyon bilgisini g�ncellemesine gerek yok ��nk� atack yapcak
            Vector3 direction = target.position - transform.position; // 3 boyutluda y�n de�i�keni tan�mlad�k karakterimizin pozisyonundan enemynin pozisyonundaki aradaki fark� al�cak
            direction.y = 0; //enemy takip ederken sadece karakterimize bakmas� kafas� sa�a sola d�nmemesi i�in y 0 tan�mlad�k
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime); // karakterimizin pe�inden saniye saniye d�n�� yapacak k�sacas� d�n�� fonksiyonu

            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("Attack", true);

        //    StartCoroutine(AttackTime());           //zaman aral��� oldugu i�in coroutine kulland�k 

        }
        else if (distance>10 )
        {
           StopChase();

        }
    }


    void StopChase()
    {
        agent.updatePosition = false;
        anim.SetBool("isWalking", false); //ajan karakteri takip ederken  y�reyerek gelsin
        anim.SetBool("Attack", false);


    }


    void ChasePlayer()
    {

        agent.updateRotation = true; 
        agent.updatePosition=true; // zombi ajan�n�n ko�ul sa�land���nda pozisyonunu g�ncellemesi gerekmektedir
        agent.SetDestination(target.position); // zombi ajan�n�n karakterimizi takip etmesi i�in yazd���m ko
        anim.SetBool("isWalking", true);  //ajan karakteri takip ederken  y�reyerek gelsin
        anim.SetBool("Attack", false);  ////ajan karakteri y�r�rken sald�rmas�n 

    }




     void AttackPlayer()
    {

        PlayerHealth.PH.DamagePlayer(damage);

        // PlayerHealth.PH.DamagePlayer(damage); // stattick olarak atad���m�z playerhealthden damagaPlayer fonksiyonunu �a��r�yor IEnumerator tan�mlad���m 121.sat�rda �al�sacak



    }



    public void Hurt() // zombinin hasar almas� i�in yazdk
        {
      
        anim.SetTrigger("Hit");

        }

       public void DeadAnim()
        {
        
            isDead=true;
            anim.SetTrigger("Dead");
          
        }

    // IEnumerator Nav()
    // {
    //   yield return new WaitForSeconds(1.25f);
    // agent.enabled = true;

    //}

    /*  IEnumerator AttackTime()
      {
          canAttack = false; // sald�r�p duracak 
          yield return new WaitForSeconds(0.8f); // 
          PlayerHealth.PH.DamagePlayer(damage); //25 can d��ecek
          yield return new WaitForSeconds(attackTimer);
          canAttack = true;  // 2saniye sonra tekrar sald�racak


      }*/


}

