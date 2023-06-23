using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float theDistance;
    // silah al�nd� m� diye tan�mlama yap�yoruz  unityde tikle kontrol ediyor
    public GameObject CanK�tAl�nd�;
    public bool K�tal�nd�m�;
    public GameObject actionKit;
    public GameObject medkitbox;
    public GameObject CanFull;   
    PlayerHealth player; //playerhealth scriptini �a��r�caz ��nk� her kiti ald���m�zda can�m�z�n 25 artmas� gerekmekte


    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>(); // burda �a��r�yoruz
        K�tal�nd�m� = false;
        actionKit.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "cank�t" && !K�tal�nd�m�) // e�er tagi s�lah2 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {

                actionKit.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionKit.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cank�t" && !K�tal�nd�m�) // e�er tagi s�lah2 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionKit.SetActive(false); // Yaz�y� gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionKit.activeSelf && !K�tal�nd�m�)
        {
            if (player.currentHealth == 100)
            {

                CanFull.SetActive(true);



            }

            else
            {

            
            player.currentHealth += 10;          
           player.UptadeText(); //player scriptindeki uptade text metodu sayesinde kiti al�nca healthy bar ekran�ndada can�m�z e� zamanl� y�klenecek
            player.HealthBarSlider.value += 25; //  health bar�n 1 kitte ne kadar artaca��n� tan�mlad�k

            CanK�tAl�nd�.SetActive(true);
            K�tal�nd�m� = true;
            Destroy(CanK�tAl�nd�, 3f);
            actionKit.SetActive(false);
            Destroy(medkitbox, 2f);
            }

    }

    }


    void OnMouseExit()
    {



            actionKit.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle
            CanFull.SetActive(false);


    }

    

}
