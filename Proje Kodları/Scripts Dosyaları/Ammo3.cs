using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo3 : MonoBehaviour
{
    public float theDistance;
    // silah al�nd� m� diye tan�mlama yap�yoruz  unityde tikle kontrol ediyor
    public GameObject merm�al�nd�;
    public bool merm�al�nd�m�;
    public GameObject actionAmmo;
    public GameObject pistol;

    public GameObject ammoBox;


    void Start()
    {

        actionAmmo.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ammo3" && !merm�al�nd�m�) // e�er tagi s�lah2 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {

                actionAmmo.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionAmmo.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ammo" && !merm�al�nd�m�) // e�er tagi s�lah2 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionAmmo.SetActive(false); // Yaz�y� gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionAmmo.activeSelf && !merm�al�nd�m�)
        {

            Pistol pistolScript = pistol.GetComponent<Pistol>(); //pistol script� �a��rd�k
            pistolScript.carriedAmmo += 8; //her etkile�ime girdikce scriptdek� carriedamoyu 8 artt�rmas�n� istedik  
            pistolScript.UpdateAmmoUI();

            if (pistolScript.carriedAmmo >= 40) //carriedamonun en fazla 40 olma ko�ulu-
            {

                pistolScript.carriedAmmo = 40;
            }



            merm�al�nd�.SetActive(true);
            merm�al�nd�m� = true;
            Destroy(merm�al�nd�, 3f);
            actionAmmo.SetActive(false);
            Destroy(ammoBox, 2f);
        }

    }



    void OnMouseExit()
    {



        actionAmmo.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle



    }




}
