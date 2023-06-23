using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI; //canvaslar için gerekli olan kütüphanemizi ekledik
using UnityEngine.SceneManagement; // farklý bir sahneye eriþmek için bu kütüphaneyi kullanýyoruz

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth; // oyuna baþlarken fiziki health yani caným
    public float maxHealth = 100f; // En yüksek healthim
    public static PlayerHealth PH; // diðer scriptlerden de ulaþabilmek için
   

    public Slider HealthBarSlider; // oyunda slider olarak oluþturduðumuz health barý tanýmladýk
    public Text HealthText;  //oyunda text olarak oluþturduðumuz health texti tanýmladýk

    [Header("Damage Screen")] // bu baþlýk altýnda yazdýklarýmý kolay yoldan çaðýrabileceðim
    public Color damageColor; // damage colorumuz yani efektimiz kýrmýzý rengi verecek tanýmnlama yaptýk
    public Image damageImage; // oluþturdðumuz kan efekti damage ýmage tanýmladýk
    bool isTakingDamage=false; // hasar alýyorsa damage screen çalýþmasý için kontrolcu olarak isTakingDamage tanýmladýk
    public float colorSpeed = 5f;  // Þeffaflýða geçerkenki color speedini tanýmladýk



    public bool isDead = false;


    void Awake()  //ph paylaþýma sunduðumuz için kodlaro component olarak yazmayacaðýz   //awake start metodundan önce çalýþýr
    {
        PH = this;
        
    }


    void Start()
    {
        HealthText.text=maxHealth.ToString(); // textimiz floattan stringe çevrilmeli ve baþlangýçta canýmýz max health yani 100 gözükmeli
        currentHealth = maxHealth; // oyuna baþlarken 100 canla baþlayacagýz
        HealthBarSlider.value = maxHealth; // oyuna baþlarken sliderimiz yeþil olarak gözüksün diye
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0) // canýmýzýn 0 dan aþþaðý inmemeye saðlýyor
        {

            currentHealth = 0;
        }

        if (isTakingDamage) // eðer hasar alýyorsa damage rengini ayarlamamýz için oluþturdum.
        {

            damageImage.color = damageColor;  // isTakingDamage = true olduðu zaman damage ýmagemizin rengini kýrmýzýya dönüþtürücek

        }

        else 
        {

            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSpeed * Time.deltaTime); // lerp= geçiþi zamanla saðlamak için kullanýlýr  örn: color A dan Color B ye geçerken  color.clear þeffaflýk
                                                                                                // isTakingDamage = false; olduðunda devreye girer

        }

        isTakingDamage = false; // if ve else dýþýnda damage efeckt false olacak

    }


    public void DamagePlayer(float damage) //karakterimizin canýnýn azalmasý için tanýmladðýmýz metod
    {

        //        currentHealth -= damage;

        if (currentHealth > 0) // karakterimizin caný 0 dan büyükken
        {

            if (damage >= currentHealth)   // enemynin vurduðu hasar bizim canýmýzdan büyükse öl
            {
                isTakingDamage = true; // öldüðümüzde damage efeckt ekraný true olmasýný saðladýk
                Dead();    // void dead fonksiyonunu çalýþtýr.
                SceneManager.LoadScene(1); // öldüðümüzde diðer sahneye geçmesi için 1 olma sebebi ise file - building settings de  1.sahne oolarak atayýp ölüm canvasýný ona oluþturdum

            }

            else
            {
                isTakingDamage = true; // hasar aldýðýmýzda damage efeckt ekraný true olmasýný saðladýk
                currentHealth -= damage; // eðer verdiði hasar kendi canýmdan küçükse canýmý azalt
                HealthBarSlider.value -= damage; // sliderin value deðeri aldýðýmýz hasar kadar  düþsün
                UptadeText(); // barýmýzýn azaldýðý veya arttýðýnda uptadetexte gidecek

            }



        }

    }
        public void UptadeText()
        {


            HealthText.text=currentHealth.ToString(); // canýmýzý textda sayýsal olarak gösteremediði için stringe çevirdik ve yansttýk
            


        }





        void Dead()
        {
            currentHealth = 0;
            isDead= true;
            HealthBarSlider.value = 0; // öldüðümüz zaman sliderin value deðer 0 olsun
            UptadeText(); // barýmýzýn azaldýðý veya arttýðýnda uptadetexte gidecek
            

        }



    }


