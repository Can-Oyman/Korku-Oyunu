using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{

    public float theDistance;
    public bool Flash;   // elfeneri alýndý mý diye tanýmlama yapýyoruz
    public GameObject FlashLight; //el feneri objesi
    public GameObject FlashLightAlýndý;
    public GameObject actionFlash;
    public GameObject realFlashLight;// elimizde olan el feneri
    public GameObject flashActivition; // F tuþuna Basýnýz yazýsý



    void Start()
    {
        Flash = false; // baþlangýçta trigger alanýna girmediði için anahtar elimizde deðil.
        actionFlash.SetActive(false); // Yazýyý baþlangýçta gizle

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlashLight" && !Flash) // eðer tagi key1 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {
                actionFlash.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionFlash.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FlashLight" && !Flash) // eðer tagi key1 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionFlash.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        if (Input.GetKeyDown(KeyCode.E) && actionFlash.activeSelf && !Flash)
        {
            realFlashLight.SetActive(true);
            flashActivition.SetActive(true);
            FlashLightAlýndý.SetActive(true);
            StartCoroutine(Sayac3());
            actionFlash.SetActive(false);
            Flash = true;
            Destroy(FlashLight, 0.5f); // Anahtarý yok et

            

        }
    }

    void OnMouseExit()
    {
        actionFlash.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        FlashLightAlýndý.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        flashActivition.SetActive(false);
    }



}
