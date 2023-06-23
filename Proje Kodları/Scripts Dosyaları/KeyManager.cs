using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public float theDistance;
    public bool anahtar;   // anahtar alýndý mý diye tanýmlama yapýyoruz
    public GameObject key;
    public GameObject anahtarAlindi;
    public GameObject actionKey1;

   

    void Start()
    {
        anahtar = false; // baþlangýçta trigger alanýna girmediði için anahtar elimizde deðil.
        actionKey1.SetActive(false); // Yazýyý baþlangýçta gizle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key1" && !anahtar) // eðer tagi key1 olan collider ile çarpýþtýðýnda ve anahtar alýnmamýþsa...
        {
            if (theDistance <= 2)
            {
                actionKey1.SetActive(true); // Yazýyý aktif et
            }
            else
            {
                actionKey1.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key1" && !anahtar) // eðer tagi key1 olan collider ile temas kesildiðinde ve anahtar alýnmamýþsa...
        {
            actionKey1.SetActive(false); // Yazýyý gizle
        }
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        if (Input.GetKeyDown(KeyCode.E) && actionKey1.activeSelf && !anahtar)
        {
                     
            anahtarAlindi.SetActive(true);
            StartCoroutine(Sayac3());
            actionKey1.SetActive(false);
            anahtar = true;
            Destroy(key, 0.5f); // Anahtarý yok et
        
    }
    }

    void OnMouseExit()
    {
        actionKey1.SetActive(false); // mouse kapýnýn üstünden çýkýnca yazýyý gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        anahtarAlindi.SetActive(false);
    }
}