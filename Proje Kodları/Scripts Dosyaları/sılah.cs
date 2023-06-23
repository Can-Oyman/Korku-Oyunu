using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class sılah : MonoBehaviour
{
    public float theDistance;
    public bool sılahalındımı;   // silah alındı mı diye tanımlama yapıyoruz  unityde tikle kontrol ediyor
    public GameObject silah;
    public GameObject silahalındı;
    public GameObject actionKey2;
    public GameObject R_arm;
    public GameObject ammoPanel; // silahı aldığımızda ammo panel aktif olsun diye 


    void Start()
    {
        sılahalındımı = false; // başlangıçta trigger alanına girmediği için anahtar elimizde değil.
        actionKey2.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "sılah2" && !sılahalındımı) // eğer tagi sılah2 olan collider ile çarpıştığında ve anahtar alınmamışsa...
        {
            if (theDistance <= 2)
            {
                actionKey2.SetActive(true); // Yazıyı aktif et
            }
            else
            {
                actionKey2.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "sılah2" && !sılahalındımı) // eğer tagi sılah2 olan collider ile temas kesildiğinde ve anahtar alınmamışsa...
        {
            actionKey2.SetActive(false); // Yazıyı gizle
        }
    }

     void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionKey2.activeSelf && !sılahalındımı)
        {


            silahalındı.SetActive(true);
            Destroy(silahalındı, 3f);
           

            actionKey2.SetActive(false);
            sılahalındımı = true;
            Destroy(silah, 2f); // Silahı yok et
            R_arm.SetActive(true);
              //tagini silah2 yaptığım karakterimin elinde gözüknesini istediğim silahımı true çevirecek *güncelleme el animasyonuda eklediğim için R_arm active edicek
            ammoPanel.SetActive(true);
        }

    }

  

    void OnMouseExit()
    {

        
        
     actionKey2.SetActive(false); // mouse kapının üstünden çıkınca yazıyı gizle

       

    }

    
    


}
