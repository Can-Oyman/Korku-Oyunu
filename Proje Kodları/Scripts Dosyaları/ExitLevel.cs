using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SAHNELER ARASINDA GEÇÝÞ SAÐLAMASI ÝÇÝN

public class ExitLevel : MonoBehaviour
{
    public float theDistance;
    public GameObject tuþ;
    public GameObject kapýaçýldý;
    public GameObject ActionSonKey;


    void Start()
    {
        ActionSonKey.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "tuþ" ) // eðer tagi tuþ olan collider ile çarpýþtýðýnda
        {
            if (theDistance <= 2)
            {
                ActionSonKey.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                ActionSonKey.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "tuþ" ) // eðer tagi tuþ olan collider ile çarpýþtýðýnda
        {
            ActionSonKey.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && ActionSonKey.activeSelf)
        {

            SceneManager.LoadScene(2); //build settingsde yeni sahneyi 2 olarak belirledim
            kapýaçýldý.SetActive(true);
            Destroy(kapýaçýldý, 3f);
            ActionSonKey.SetActive(false);
        }

    }



    void OnMouseExit()
    {



        ActionSonKey.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle



    }





}
