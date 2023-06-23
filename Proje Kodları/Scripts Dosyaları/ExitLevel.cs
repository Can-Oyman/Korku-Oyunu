using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SAHNELER ARASINDA GE��� SA�LAMASI ���N

public class ExitLevel : MonoBehaviour
{
    public float theDistance;
    public GameObject tu�;
    public GameObject kap�a��ld�;
    public GameObject ActionSonKey;


    void Start()
    {
        ActionSonKey.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "tu�" ) // e�er tagi tu� olan collider ile �arp��t���nda
        {
            if (theDistance <= 2)
            {
                ActionSonKey.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                ActionSonKey.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "tu�" ) // e�er tagi tu� olan collider ile �arp��t���nda
        {
            ActionSonKey.SetActive(false); // Yaz�y� gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && ActionSonKey.activeSelf)
        {

            SceneManager.LoadScene(2); //build settingsde yeni sahneyi 2 olarak belirledim
            kap�a��ld�.SetActive(true);
            Destroy(kap�a��ld�, 3f);
            ActionSonKey.SetActive(false);
        }

    }



    void OnMouseExit()
    {



        ActionSonKey.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle



    }





}
