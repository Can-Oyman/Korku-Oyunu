using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo2 : MonoBehaviour
{


    public float theDistance;
    // silah al�nd� m� diye tan�mlama yap�yoruz  unityde tikle kontrol ediyor
    public GameObject merm�al�nd�1;
    public bool merm�al�nd�m�1;
    public GameObject actionAmmo1;
    public GameObject pistol1;

    public GameObject ammoBox1;


    void Start()
    {

        actionAmmo1.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ammo2" && !merm�al�nd�m�1) // e�er tagi s�lah2 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {

                actionAmmo1.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionAmmo1.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ammo2" && !merm�al�nd�m�1) // e�er tagi s�lah2 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionAmmo1.SetActive(false); // Yaz�y� gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionAmmo1.activeSelf && !merm�al�nd�m�1)
        {

            Pistol pistolScript = pistol1.GetComponent<Pistol>(); //pistol script� �a��rd�k
            pistolScript.carriedAmmo += 8; //her etkile�ime girdikce scriptdek� carriedamoyu 8 artt�rmas�n� istedik  
            pistolScript.UpdateAmmoUI();

            if (pistolScript.carriedAmmo >= 40) //carriedamonun en fazla 40 olma ko�ulu-
            {

                pistolScript.carriedAmmo = 40;
            }



            merm�al�nd�1.SetActive(true);
            merm�al�nd�m�1 = true;
            Destroy(merm�al�nd�1, 3f);
            actionAmmo1.SetActive(false);
            Destroy(ammoBox1, 2f);
        }

    }



    void OnMouseExit()
    {



        actionAmmo1.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle



    }




}


