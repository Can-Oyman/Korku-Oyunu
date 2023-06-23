using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{

    public float theDistance;
    public bool Flash;   // elfeneri al�nd� m� diye tan�mlama yap�yoruz
    public GameObject FlashLight; //el feneri objesi
    public GameObject FlashLightAl�nd�;
    public GameObject actionFlash;
    public GameObject realFlashLight;// elimizde olan el feneri
    public GameObject flashActivition; // F tu�una Bas�n�z yaz�s�



    void Start()
    {
        Flash = false; // ba�lang��ta trigger alan�na girmedi�i i�in anahtar elimizde de�il.
        actionFlash.SetActive(false); // Yaz�y� ba�lang��ta gizle

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlashLight" && !Flash) // e�er tagi key1 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {
                actionFlash.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionFlash.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FlashLight" && !Flash) // e�er tagi key1 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionFlash.SetActive(false); // Yaz�y� gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        if (Input.GetKeyDown(KeyCode.E) && actionFlash.activeSelf && !Flash)
        {
            realFlashLight.SetActive(true);
            flashActivition.SetActive(true);
            FlashLightAl�nd�.SetActive(true);
            StartCoroutine(Sayac3());
            actionFlash.SetActive(false);
            Flash = true;
            Destroy(FlashLight, 0.5f); // Anahtar� yok et

            

        }
    }

    void OnMouseExit()
    {
        actionFlash.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        FlashLightAl�nd�.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        flashActivition.SetActive(false);
    }



}
