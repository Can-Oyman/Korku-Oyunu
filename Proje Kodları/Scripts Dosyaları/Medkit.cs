using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float theDistance;
    // silah alýndý mý diye tanýmlama yapýyoruz  unityde tikle kontrol ediyor
    public GameObject CanKýtAlýndý;
    public bool Kýtalýndýmý;
    public GameObject actionKit;
    public GameObject medkitbox;
    public GameObject CanFull;   
    PlayerHealth player; //playerhealth scriptini çaðýrýcaz çünkü her kiti aldýðýmýzda canýmýzýn 25 artmasý gerekmekte


    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>(); // burda çaðýrýyoruz
        Kýtalýndýmý = false;
        actionKit.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "cankýt" && !Kýtalýndýmý) // eðer tagi sýlah2 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {

                actionKit.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionKit.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cankýt" && !Kýtalýndýmý) // eðer tagi sýlah2 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionKit.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionKit.activeSelf && !Kýtalýndýmý)
        {
            if (player.currentHealth == 100)
            {

                CanFull.SetActive(true);



            }

            else
            {

            
            player.currentHealth += 10;          
           player.UptadeText(); //player scriptindeki uptade text metodu sayesinde kiti alýnca healthy bar ekranýndada canýmýz eþ zamanlý yüklenecek
            player.HealthBarSlider.value += 25; //  health barýn 1 kitte ne kadar artacaðýný tanýmladýk

            CanKýtAlýndý.SetActive(true);
            Kýtalýndýmý = true;
            Destroy(CanKýtAlýndý, 3f);
            actionKit.SetActive(false);
            Destroy(medkitbox, 2f);
            }

    }

    }


    void OnMouseExit()
    {



            actionKit.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle
            CanFull.SetActive(false);


    }

    

}
