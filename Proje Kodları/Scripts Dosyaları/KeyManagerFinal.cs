using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerFinal : MonoBehaviour
{
    public float theDistance;
    public bool anahtar2;   // anahtar al�nd� m� diye tan�mlama yap�yoruz
    public GameObject key2;
    public GameObject anahtarAlindi2;
    public GameObject actionKey3;



    void Start()
    {
        anahtar2 = false; // ba�lang��ta trigger alan�na girmedi�i i�in anahtar elimizde de�il.
        actionKey3.SetActive(false); // Yaz�y� ba�lang��ta gizle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key2" && !anahtar2) // e�er tagi key1 olan collider ile �arp��t���nda ve anahtar al�nmam��sa...
        {
            if (theDistance <= 2)
            {
                actionKey3.SetActive(true); // Yaz�y� aktif et
            }
            else
            {
                actionKey3.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key2" && !anahtar2) // e�er tagi key1 olan collider ile temas kesildi�inde ve anahtar al�nmam��sa...
        {
            actionKey3.SetActive(false); // Yaz�y� gizle
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
            Destroy(key2, 0.5f); // Anahtar� yok et

        }
    }

    void OnMouseExit()
    {
        actionKey3.SetActive(false); // mouse kap�n�n �st�nden ��k�nca yaz�y� gizle
    }

    IEnumerator Sayac3()
    {
        yield return new WaitForSeconds(0.5f);
        anahtarAlindi2.SetActive(false);
    }
}