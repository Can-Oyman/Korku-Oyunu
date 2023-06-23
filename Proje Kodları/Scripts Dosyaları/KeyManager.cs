using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public float theDistance;
    public bool anahtar;   // anahtar al�nd� m� diye tan�mlama yap�yoruz
    public GameObject key;
    public GameObject anahtarAlindi;
    public GameObject actionKey1;

   

    void Start()
    {
        anahtar = false; // ba�lang��ta trigger alan�na girmedi�i i�in anahtar elimizde de�il.
        actionKey1.SetActive(false); // Yaz�y� ba�lang��ta gizle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key1" && !anahtar) // e�er tagi key1 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {
                actionKey1.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionKey1.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key1" && !anahtar) // e�er tagi key1 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionKey1.SetActive(false); // Yaz�y� gizle
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
            Destroy(key, 0.5f); // Anahtar� yok et
        
    }
    }

    void OnMouseExit()
    {
        actionKey1.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        anahtarAlindi.SetActive(false);
    }
}