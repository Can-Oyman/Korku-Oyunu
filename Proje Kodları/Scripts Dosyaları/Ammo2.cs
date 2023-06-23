using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo2 : MonoBehaviour
{


    public float theDistance;
    // silah alýndý mý diye tanýmlama yapýyoruz  unityde tikle kontrol ediyor
    public GameObject mermýalýndý1;
    public bool mermýalýndýmý1;
    public GameObject actionAmmo1;
    public GameObject pistol1;

    public GameObject ammoBox1;


    void Start()
    {

        actionAmmo1.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ammo2" && !mermýalýndýmý1) // eðer tagi sýlah2 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {

                actionAmmo1.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionAmmo1.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ammo2" && !mermýalýndýmý1) // eðer tagi sýlah2 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionAmmo1.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && actionAmmo1.activeSelf && !mermýalýndýmý1)
        {

            Pistol pistolScript = pistol1.GetComponent<Pistol>(); //pistol scriptý çaðýrdýk
            pistolScript.carriedAmmo += 8; //her etkileþime girdikce scriptdeký carriedamoyu 8 arttýrmasýný istedik  
            pistolScript.UpdateAmmoUI();

            if (pistolScript.carriedAmmo >= 40) //carriedamonun en fazla 40 olma koþulu-
            {

                pistolScript.carriedAmmo = 40;
            }



            mermýalýndý1.SetActive(true);
            mermýalýndýmý1 = true;
            Destroy(mermýalýndý1, 3f);
            actionAmmo1.SetActive(false);
            Destroy(ammoBox1, 2f);
        }

    }



    void OnMouseExit()
    {



        actionAmmo1.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle



    }




}


