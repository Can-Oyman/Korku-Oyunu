using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI; //canvaslar i�in gerekli olan k�t�phanemizi ekledik
using UnityEngine.SceneManagement; // farkl� bir sahneye eri�mek i�in bu k�t�phaneyi kullan�yoruz

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth; // oyuna ba�larken fiziki health yani can�m
    public float maxHealth = 100f; // En y�ksek healthim
    public static PlayerHealth PH; // di�er scriptlerden de ula�abilmek i�in
   

    public Slider HealthBarSlider; // oyunda slider olarak olu�turdu�umuz health bar� tan�mlad�k
    public Text HealthText;  //oyunda text olarak olu�turdu�umuz health texti tan�mlad�k

    [Header("Damage Screen")] // bu ba�l�k alt�nda yazd�klar�m� kolay yoldan �a��rabilece�im
    public Color damageColor; // damage colorumuz yani efektimiz k�rm�z� rengi verecek tan�mnlama yapt�k
    public Image damageImage; // olu�turd�umuz kan efekti damage �mage tan�mlad�k
    bool isTakingDamage=false; // hasar al�yorsa damage screen �al��mas� i�in kontrolcu olarak isTakingDamage tan�mlad�k
    public float colorSpeed = 5f;  // �effafl��a ge�erkenki color speedini tan�mlad�k



    public bool isDead = false;


    void Awake()  //ph payla��ma sundu�umuz i�in kodlaro component olarak yazmayaca��z   //awake start metodundan �nce �al���r
    {
        PH = this;
        
    }


    void Start()
    {
        HealthText.text=maxHealth.ToString(); // textimiz floattan stringe �evrilmeli ve ba�lang��ta can�m�z max health yani 100 g�z�kmeli
        currentHealth = maxHealth; // oyuna ba�larken 100 canla ba�layacag�z
        HealthBarSlider.value = maxHealth; // oyuna ba�larken sliderimiz ye�il olarak g�z�ks�n diye
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0) // can�m�z�n 0 dan a��a�� inmemeye sa�l�yor
        {

            currentHealth = 0;
        }

        if (isTakingDamage) // e�er hasar al�yorsa damage rengini ayarlamam�z i�in olu�turdum.
        {

            damageImage.color = damageColor;  // isTakingDamage = true oldu�u zaman damage �magemizin rengini k�rm�z�ya d�n��t�r�cek

        }

        else 
        {

            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSpeed * Time.deltaTime); // lerp= ge�i�i zamanla sa�lamak i�in kullan�l�r  �rn: color A dan Color B ye ge�erken  color.clear �effafl�k
                                                                                                // isTakingDamage = false; oldu�unda devreye girer

        }

        isTakingDamage = false; // if ve else d���nda damage efeckt false olacak

    }


    public void DamagePlayer(float damage) //karakterimizin can�n�n azalmas� i�in tan�mlad��m�z metod
    {

        //        currentHealth -= damage;

        if (currentHealth > 0) // karakterimizin can� 0 dan b�y�kken
        {

            if (damage >= currentHealth)   // enemynin vurdu�u hasar bizim can�m�zdan b�y�kse �l
            {
                isTakingDamage = true; // �ld���m�zde damage efeckt ekran� true olmas�n� sa�lad�k
                Dead();    // void dead fonksiyonunu �al��t�r.
                SceneManager.LoadScene(1); // �ld���m�zde di�er sahneye ge�mesi i�in 1 olma sebebi ise file - building settings de  1.sahne oolarak atay�p �l�m canvas�n� ona olu�turdum

            }

            else
            {
                isTakingDamage = true; // hasar ald���m�zda damage efeckt ekran� true olmas�n� sa�lad�k
                currentHealth -= damage; // e�er verdi�i hasar kendi can�mdan k���kse can�m� azalt
                HealthBarSlider.value -= damage; // sliderin value de�eri ald���m�z hasar kadar  d��s�n
                UptadeText(); // bar�m�z�n azald��� veya artt���nda uptadetexte gidecek

            }



        }

    }
        public void UptadeText()
        {


            HealthText.text=currentHealth.ToString(); // can�m�z� textda say�sal olarak g�steremedi�i i�in stringe �evirdik ve yanstt�k
            


        }





        void Dead()
        {
            currentHealth = 0;
            isDead= true;
            HealthBarSlider.value = 0; // �ld���m�z zaman sliderin value de�er 0 olsun
            UptadeText(); // bar�m�z�n azald��� veya artt���nda uptadetexte gidecek
            

        }



    }


