using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  //Yapay Zekayý kullanmak için klütüphane ekledik

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent; //yapay zeka nav deðiþkeni oyunda Enemy karakterimizin içinde 
    Animator anim;
    Transform target; //kendi karakterimizin konumu transformu
    public bool isDead=false; // ölü iken 
    public float TurnSpeed; // enemynin dönüþ hýzý AttackPlayer kýsmýnda kullanacagýz
    public bool canAttack; // düþman bize saldýrabilir durumda mý diye tanýmlama yaptýk

    [SerializeField]
    float attackTimer = 4f; // enemy vurma animasyonu gerçekleþirken 2 saniyede bir canýmýzýn 25f düþmesi için timer ataadýk
    
    public float damage = 10f;  // enemynin vurduðu hasarý damage olarak tanýmladýk hasarýný ise 25 olarak belirledik


    void Start()
    {
        canAttack = true; // oyunun baþlangýcýnda enemy bize hasar verebilecek olarak ayarladým
        agent = GetComponent<NavMeshAgent>(); // agenti çaðýrdýðýmýzda componentimize ulaþabilmek için 
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform; //tagi player olan gami objesini bul ve transformunu bul yani karakterimizin tagi ve transformu

        
    }

    // Update is called once per frame
    void Update()
    {
        float distance=Vector3.Distance(transform.position, target.position); // 3 boyutlu dünyada zombinin pozisyonundan ,  karakterimizin targetin pozisyonuna gidecek

        if(distance <10 && distance>agent.stoppingDistance && !isDead)  // enemye attýðýmýz  nav mesh agentteki stoppingDistance deðerini ne girdiysek ona göre durmasýný istiyoryz
        {
            ChasePlayer();
        }
        else if (distance < agent.stoppingDistance && canAttack  ) //  playerim ölü deðilse
        {
            agent.updateRotation = false; // pozisyon bilgisini güncellemesine gerek yok çünkü atack yapcak
            Vector3 direction = target.position - transform.position; // 3 boyutluda yön deðiþkeni tanýmladýk karakterimizin pozisyonundan enemynin pozisyonundaki aradaki farký alýcak
            direction.y = 0; //enemy takip ederken sadece karakterimize bakmasý kafasý saða sola dönmemesi için y 0 tanýmladýk
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime); // karakterimizin peþinden saniye saniye dönüþ yapacak kýsacasý dönüþ fonksiyonu

            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("Attack", true);

        //    StartCoroutine(AttackTime());           //zaman aralýðý oldugu için coroutine kullandýk 

        }
        else if (distance>10 )
        {
           StopChase();

        }
    }


    void StopChase()
    {
        agent.updatePosition = false;
        anim.SetBool("isWalking", false); //ajan karakteri takip ederken  yüreyerek gelsin
        anim.SetBool("Attack", false);


    }


    void ChasePlayer()
    {

        agent.updateRotation = true; 
        agent.updatePosition=true; // zombi ajanýnýn koþul saðlandýðýnda pozisyonunu güncellemesi gerekmektedir
        agent.SetDestination(target.position); // zombi ajanýnýn karakterimizi takip etmesi için yazdýðým ko
        anim.SetBool("isWalking", true);  //ajan karakteri takip ederken  yüreyerek gelsin
        anim.SetBool("Attack", false);  ////ajan karakteri yürürken saldýrmasýn 

    }




     void AttackPlayer()
    {

        PlayerHealth.PH.DamagePlayer(damage);

        // PlayerHealth.PH.DamagePlayer(damage); // stattick olarak atadýðýmýz playerhealthden damagaPlayer fonksiyonunu çaðýrýyor IEnumerator tanýmladýðým 121.satýrda çalýsacak



    }



    public void Hurt() // zombinin hasar almasý için yazdk
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
          canAttack = false; // saldýrýp duracak 
          yield return new WaitForSeconds(0.8f); // 
          PlayerHealth.PH.DamagePlayer(damage); //25 can düþecek
          yield return new WaitForSeconds(attackTimer);
          canAttack = true;  // 2saniye sonra tekrar saldýracak


      }*/


}

