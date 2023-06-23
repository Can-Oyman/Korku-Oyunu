using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo3 : MonoBehaviour
{
    public float theDistance;
    // silah alýndý mý diye tanýmlama yapýyoruz  unityde tikle kontrol ediyor
    public GameObject mermýalýndý;
    public bool mermýalýndýmý;
    public GameObject actionAmmo;
    public GameObject pistol;

    public GameObject ammoBox;


    void Start()
    {

        actionAmmo.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ammo3" && !mermýalýndýmý) // eðer tagi sýlah2 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {

                actionAmmo.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionAmmo.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ammo" && !mermýalýndýmý) // eðer tagi sýlah2 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionAmmo.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionAmmo.activeSelf && !mermýalýndýmý)
        {

            Pistol pistolScript = pistol.GetComponent<Pistol>(); //pistol scriptý çaðýrdýk
            pistolScript.carriedAmmo += 8; //her etkileþime girdikce scriptdeký carriedamoyu 8 arttýrmasýný istedik  
            pistolScript.UpdateAmmoUI();

            if (pistolScript.carriedAmmo >= 40) //carriedamonun en fazla 40 olma koþulu-
            {

                pistolScript.carriedAmmo = 40;
            }



            mermýalýndý.SetActive(true);
            mermýalýndýmý = true;
            Destroy(mermýalýndý, 3f);
            actionAmmo.SetActive(false);
            Destroy(ammoBox, 2f);
        }

    }



    void OnMouseExit()
    {



        actionAmmo.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle



    }




}
