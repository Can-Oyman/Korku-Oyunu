 using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
   RaycastHit hit; // ýþýnýn çarptýðý noktaya hit diyoruz

    public ParticleSystem muzzleFlash; // silah ateþ etme efektini tanýmladýk

    AudioSource pistolAS; // silahýn sesi için atadýk   
    public AudioClip shootAC; // silah atýþ sesi için atadýk *birden çok ses efekti ekleleyeceðim için clip þeklinde ekliyorum
    public AudioClip emptyFire; // door soundu çalmasý
    public AudioClip Reoladsound;

    Animator anim; // animasyon deðiþkenýný tanýmladýk

    bool isReloading;

    public int currentAmmo=12; //þarjördeki mermi miktari
    public int maxAmmo=12; //þarjördeki mermi kapasitesi mesela 10 mermi alýyor     ShootRay kýsmýnda çalýþacak
    public int carriedAmmo=60; // taþýyabileceðimiz mermi miktarý  


    public GameObject metalBolletHole; // mermi izi için gameobjesi tanýmladým      
    public AudioClip shootMetalAC; // mermi izinin çýkardýðý ses için audio clip tanýmladým


    [SerializeField]
    float rateOffire; // ne kadar sürede bir ateþ edeceðimizi hesaplayacagýnmýz float deðiþken
    float nextFire=0; // süre hesaplayacagýmýz deðiþken 

    [SerializeField]
    float weaponRange; //silahýn mermisinin gidebileceði mesafesi


    public float damage = 20f; //silahýn verdiði hasar
    public Transform shootPoint; // merminin çýkacaðý yeri tanýmlamak için
    //EnemyHealth enemy; //düþmanýn saðlýðý için tanýmladýk

    public Text currentAmmoText; // canvasda yazdýðýmýz textleri tanýmladýk
    public Text carriedAmmoText; // canvasda yazdýðýmýz textleri tanýmladýk
    public GameObject bloodEffect; // zombiyi silahla vurunca kan partical efektini kullanmak için tanýmladýk

    void Start()
    {
        UpdateAmmoUI(); //  currentAmmoText  ve carriedAmmoTex deðerlerimizi 129.satýra göre yazdýracak
        anim = GetComponent<Animator>(); //içindeki scriptteki animator componentini getir
        pistolAS = GetComponent<AudioSource>(); //Audio Source Componentini getirsin
        muzzleFlash.Stop(); // oyunu baþlattýðýmýzda silahýn ateþ efekti çalýþmasýn
      //   enemy = FindObjectOfType<EnemyHealth>(); // içinde enemy health metodu olan componenti bulup ona ulaþssýn
        
    }

   
    void Update() // bu iþlemleri ne zaman yapacak 
    {
        
        if(Input.GetButton("Fire1")&& currentAmmo>0 ) // Fire1 yani oyunda mouse0 olarak atanan tuþa basýldýðýnda ve mermi varken shooot fonksiyonunu çalýþtýr
        {
            Shoot();
        }

        else if(Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
 
            EmptyFire(); // mermim 02 dan küçük olduðunda EmptyFire fonksiyonunu çalýþtýr

        }

         else if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo &&  !isReloading)        //R tuþuna bastýðýmda ve þarjördeki mermim maxammoda dan küçük olduðunda
        {
            isReloading = true;
            Reolad(); // Reoladý çalýþtýr

        }
        
        
    }


    void Shoot()   // Time.time oyunda geçen süre demek
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOffire; //bu fonksiyon ile mermi sýkarken arasýndaký mermi ateþleme zamanýný ayarlayacaðýz
            anim.SetTrigger("Shoot");
            currentAmmo -= 1; //merminin 1  er 1  er azalmasýný saðlayan fonksiyon
                              // StartCoroutine(pistolEffect()); //93.satýrda pistol effectin yapacaklarý yazýyor

            ShootRay(); //enemynýn caný azalmasý için gittiði metod

            UpdateAmmoUI(); // burda ise harcadýðýmýz merminin azalarak ekrana yazýlmasýný saðlayacak
      
        }
    
    
    }


    void ShootRay() //mermiyi attýðýmýz kýsým
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))    // shootPoint.position çýkan ray shootPoint ileri doðru gidicek ve out hit yani biryere çarpacak ayný zamanda weaponrange içindeyken bu olaylar oldu ise
        {


            if (hit.transform.tag == "Enemy") // çarpýðý yerin tagý Enemy  ise console log kýsmýnda hit Enemy yazsýn
            {

                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();   // hit yani vurduðum transformun enemyhealth componentini getir
                Instantiate(bloodEffect, hit.point, transform.rotation); // hitin bizden çýkan rayin collidera çarpýtýgý noktada transform rotation yaný gittiði noktada kalacak
                
                enemy.ReduceHealth(damage);

            }

         
            else if (hit.transform.tag=="duvar") // bunlarýn dýþýnda duvar tagli nesneye vurduðumda
            {

                pistolAS.PlayOneShot(shootMetalAC);  // Instantiate oluþturmak yaratmak bunun sayesinde sahnede bir þeyi yaratabiliyor
                Instantiate(metalBolletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            }

            else                               // Eðer  çarpýðý yerin tagý Enemy deðil ise  ise console log kýsmýnda Something else yazsýn
            {

                Debug.Log("Something else");



            }


        }

    }

    void Reolad()
    {

        if (carriedAmmo < 0) return;// taþýdýðým mermi 0 dan küçük veya eþitse hiçbir iþlev yapma 
        anim.SetTrigger("Þarjör");
        pistolAS.PlayOneShot(Reoladsound);
        StartCoroutine(ReloadCountDown(2f)); // aksi halde  164.satýrda yazdýðým döngüyü çalýþtýr time ise  2f yap

    }

    public void UpdateAmmoUI() // int deðerleri stringe çevirip ekrana yazmasý için
    {
        currentAmmoText.text=currentAmmo.ToString(); // Current Ammo int deðerinden stringe çevirdk
        carriedAmmoText.text=carriedAmmo.ToString(); // Carried Ammo int deðerinden stringe çevirdk
       
    }

    void EmptyFire() //Empty Fire =yani hiç mermimiz yokken
    {
        if(Time.time > nextFire) // time ekleme sebebim her tick yaptýgýmýzda merminin olmayýþýnýn sesi zaman kavramý olmadan çalýþmasýný önlemek.
        {
          nextFire -= Time.time + rateOffire;
            pistolAS.PlayOneShot(emptyFire); // sadece bir kereye mahsus mermimin olmadýðý zamanki triggerin animasyonunda door soundu çalmasýný istiyorum
            anim.SetTrigger("Empty");

        }

    }

    IEnumerator PistolEffect()
    {
        muzzleFlash.Play(); // Silah Ateþ Efektini Oynat
        pistolAS.PlayOneShot(shootAC); // Silahý sýktýðýmýzda bir kere çalmasýný istediðimiz için PlayOneShot tanýmlayarak yazdýk
        yield return new WaitForEndOfFrame(); //frame bittiði anda 
        muzzleFlash.Stop();   // Silah  Ateþ Efektini Durdur


    }

    IEnumerator ReloadCountDown(float timer=2f)
    {


        while (timer>0f)
        {
        
      
           timer -= Time.deltaTime; //Time.deltaTime= oyun baþladýktan sonra geçen zamana denir
           yield return null;
        
        
        }
        if(timer<=0 ) 
        {
           isReloading = false;
           int bulletNeeded = maxAmmo - currentAmmo; //mermi alýrken kaç adet mermi alacaðýný bilmesi için bu kod , yani þarjörü tamamlamam için kaç mermiye ihtiyacým var sorusunun cevabi
           int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;//azalan düþen mermi sayýsý *carriedAmo >= bulletNeeded = ( carriedAmo yani taþýnan mermi ihtiyacým olan mermiden fazla ise bulletNeeded = maxAmmo - currentAmmo geçerlidir ) 
                                                                                           // eðer deðilse *bulletNeeded : carriedAmo ( bulletsToDeduct carriedAmo ya eþittir)
           carriedAmmo-= bulletsToDeduct; // taþýdýðým mermi sayýsýný bulletsToDeducta kadar düþür
           currentAmmo += bulletsToDeduct; // þarjörümdeki mermi saysýsýna bulletsToDeducta miktarýna eþit olana kadar ekleyeceðim
            UpdateAmmoUI();


        }


    }

}
