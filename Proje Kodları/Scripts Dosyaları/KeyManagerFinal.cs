using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerFinal : MonoBehaviour
{
    public float theDistance;
    public bool anahtar2;   // anahtar alýndý mý diye tanýmlama yapýyoruz
    public GameObject key2;
    public GameObject anahtarAlindi2;
    public GameObject actionKey3;



    void Start()
    {
        anahtar2 = false; // baþlangýçta trigger alanýna girmediði için anahtar elimizde deðil.
        actionKey3.SetActive(false); // Yazýyý baþlangýçta gizle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key2" && !anahtar2) // eðer tagi key1 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {
                actionKey3.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionKey3.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key2" && !anahtar2) // eðer tagi key1 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionKey3.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        if (Input.GetKeyDown(KeyCode.E) && actionKey3.activeSelf && !anahtar2)
        {

            anahtarAlindi2.SetActive(true);
            StartCoroutine(Sayac3());
            actionKey3.SetActive(false);
            anahtar2 = true;
            Destroy(key2, 0.5f); // Anahtarý yok et

        }
    }

    void OnMouseExit()
    {
        actionKey3.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        anahtarAlindi2.SetActive(false);
    }
}