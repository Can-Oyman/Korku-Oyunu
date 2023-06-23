 using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
   RaycastHit hit; // ���n�n �arpt��� noktaya hit diyoruz

    public ParticleSystem muzzleFlash; // silah ate� etme efektini tan�mlad�k

    AudioSource pistolAS; // silah�n sesi i�in atad�k   
    public AudioClip shootAC; // silah at�� sesi i�in atad�k *birden �ok ses efekti ekleleyece�im i�in clip �eklinde ekliyorum
    public AudioClip emptyFire; // door soundu �almas�
    public AudioClip Reoladsound;

    Animator anim; // animasyon de�i�ken�n� tan�mlad�k

    bool isReloading;

    public int currentAmmo=12; //�arj�rdeki mermi miktari
    public int maxAmmo=12; //�arj�rdeki mermi kapasitesi mesela 10 mermi al�yor     ShootRay k�sm�nda �al��acak
    public int carriedAmmo=60; // ta��yabilece�imiz mermi miktar�  


    public GameObject metalBolletHole; // mermi izi i�in gameobjesi tan�mlad�m      
    public AudioClip shootMetalAC; // mermi izinin ��kard��� ses i�in audio clip tan�mlad�m


    [SerializeField]
    float rateOffire; // ne kadar s�rede bir ate� edece�imizi hesaplayacag�nm�z float de�i�ken
    float nextFire=0; // s�re hesaplayacag�m�z de�i�ken 

    [SerializeField]
    float weaponRange; //silah�n mermisinin gidebilece�i mesafesi


    public float damage = 20f; //silah�n verdi�i hasar
    public Transform shootPoint; // merminin ��kaca�� yeri tan�mlamak i�in
    //EnemyHealth enemy; //d��man�n sa�l��� i�in tan�mlad�k

    public Text currentAmmoText; // canvasda yazd���m�z textleri tan�mlad�k
    public Text carriedAmmoText; // canvasda yazd���m�z textleri tan�mlad�k
    public GameObject bloodEffect; // zombiyi silahla vurunca kan partical efektini kullanmak i�in tan�mlad�k

    void Start()
    {
        UpdateAmmoUI(); //  currentAmmoText  ve carriedAmmoTex de�erlerimizi 129.sat�ra g�re yazd�racak
        anim = GetComponent<Animator>(); //i�indeki scriptteki animator componentini getir
        pistolAS = GetComponent<AudioSource>(); //Audio Source Componentini getirsin
        muzzleFlash.Stop(); // oyunu ba�latt���m�zda silah�n ate� efekti �al��mas�n
      //   enemy = FindObjectOfType<EnemyHealth>(); // i�inde enemy health metodu olan componenti bulup ona ula�ss�n
        
    }

   
    void Update() // bu i�lemleri ne zaman yapacak 
    {
        
        if(Input.GetButton("Fire1")&& currentAmmo>0 ) // Fire1 yani oyunda mouse0 olarak atanan tu�a bas�ld���nda ve mermi varken shooot fonksiyonunu �al��t�r
        {
            Shoot();
        }

        else if(Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
 
            EmptyFire(); // mermim 02 dan k���k oldu�unda EmptyFire fonksiyonunu �al��t�r

        }

         else if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo &&  !isReloading)        //R tu�una bast���mda ve �arj�rdeki mermim maxammoda dan k���k oldu�unda
        {
            isReloading = true;
            Reolad(); // Reolad� �al��t�r

        }
        
        
    }


    void Shoot()   // Time.time oyunda ge�en s�re demek
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOffire; //bu fonksiyon ile mermi s�karken aras�ndak� mermi ate�leme zaman�n� ayarlayaca��z
            anim.SetTrigger("Shoot");
            currentAmmo -= 1; //merminin 1  er 1  er azalmas�n� sa�layan fonksiyon
                              // StartCoroutine(pistolEffect()); //93.sat�rda pistol effectin yapacaklar� yaz�yor

            ShootRay(); //enemyn�n can� azalmas� i�in gitti�i metod

            UpdateAmmoUI(); // burda ise harcad���m�z merminin azalarak ekrana yaz�lmas�n� sa�layacak
      
        }
    
    
    }


    void ShootRay() //mermiyi att���m�z k�s�m
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))    // shootPoint.position ��kan ray shootPoint ileri do�ru gidicek ve out hit yani biryere �arpacak ayn� zamanda weaponrange i�indeyken bu olaylar oldu ise
        {


            if (hit.transform.tag == "Enemy") // �arp��� yerin tag� Enemy  ise console log k�sm�nda hit Enemy yazs�n
            {

                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();   // hit yani vurdu�um transformun enemyhealth componentini getir
                Instantiate(bloodEffect, hit.point, transform.rotation); // hitin bizden ��kan rayin collidera �arp�t�g� noktada transform rotation yan� gitti�i noktada kalacak
                
                enemy.ReduceHealth(damage);

            }

         
            else if (hit.transform.tag=="duvar") // bunlar�n d���nda duvar tagli nesneye vurdu�umda
            {

                pistolAS.PlayOneShot(shootMetalAC);  // Instantiate olu�turmak yaratmak bunun sayesinde sahnede bir �eyi yaratabiliyor
                Instantiate(metalBolletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            }

            else                               // E�er  �arp��� yerin tag� Enemy de�il ise  ise console log k�sm�nda Something else yazs�n
            {

                Debug.Log("Something else");



            }


        }

    }

    void Reolad()
    {

        if (carriedAmmo < 0) return;// ta��d���m mermi 0 dan k���k veya e�itse hi�bir i�lev yapma 
        anim.SetTrigger("�arj�r");
        pistolAS.PlayOneShot(Reoladsound);
        StartCoroutine(ReloadCountDown(2f)); // aksi halde  164.sat�rda yazd���m d�ng�y� �al��t�r time ise  2f yap

    }

    public void UpdateAmmoUI() // int de�erleri stringe �evirip ekrana yazmas� i�in
    {
        currentAmmoText.text=currentAmmo.ToString(); // Current Ammo int de�erinden stringe �evirdk
        carriedAmmoText.text=carriedAmmo.ToString(); // Carried Ammo int de�erinden stringe �evirdk
       
    }

    void EmptyFire() //Empty Fire =yani hi� mermimiz yokken
    {
        if(Time.time > nextFire) // time ekleme sebebim her tick yapt�g�m�zda merminin olmay���n�n sesi zaman kavram� olmadan �al��mas�n� �nlemek.
        {
          nextFire -= Time.time + rateOffire;
            pistolAS.PlayOneShot(emptyFire); // sadece bir kereye mahsus mermimin olmad��� zamanki triggerin animasyonunda door soundu �almas�n� istiyorum
            anim.SetTrigger("Empty");

        }

    }

    IEnumerator PistolEffect()
    {
        muzzleFlash.Play(); // Silah Ate� Efektini Oynat
        pistolAS.PlayOneShot(shootAC); // Silah� s�kt���m�zda bir kere �almas�n� istedi�imiz i�in PlayOneShot tan�mlayarak yazd�k
        yield return new WaitForEndOfFrame(); //frame bitti�i anda 
        muzzleFlash.Stop();   // Silah  Ate� Efektini Durdur


    }

    IEnumerator ReloadCountDown(float timer=2f)
    {


        while (timer>0f)
        {
        
      
           timer -= Time.deltaTime; //Time.deltaTime= oyun ba�lad�ktan sonra ge�en zamana denir
           yield return null;
        
        
        }
        if(timer<=0 ) 
        {
           isReloading = false;
           int bulletNeeded = maxAmmo - currentAmmo; //mermi al�rken ka� adet mermi alaca��n� bilmesi i�in bu kod , yani �arj�r� tamamlamam i�in ka� mermiye ihtiyac�m var sorusunun cevabi
           int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;//azalan d��en mermi say�s� *carriedAmo >= bulletNeeded = ( carriedAmo yani ta��nan mermi ihtiyac�m olan mermiden fazla ise bulletNeeded = maxAmmo - currentAmmo ge�erlidir ) 
                                                                                           // e�er de�ilse *bulletNeeded : carriedAmo ( bulletsToDeduct carriedAmo ya e�ittir)
           carriedAmmo-= bulletsToDeduct; // ta��d���m mermi say�s�n� bulletsToDeducta kadar d���r
           currentAmmo += bulletsToDeduct; // �arj�r�mdeki mermi says�s�na bulletsToDeducta miktar�na e�it olana kadar ekleyece�im
            UpdateAmmoUI();


        }


    }

}
