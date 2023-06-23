using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoorFınal : MonoBehaviour
{
    public float theDistance; // bu kod hangi nesnenin içine atarsak o nesneye olan mesafeyi tanımaya yarar
    public GameObject Closed_DoorFinal; // mouse kapının üstüne tuttuğumuzda aktif olmasını istediğimiz text yazısı
    public GameObject Door;
    KeyManagerFinal key2;
    public bool anahtar2;
    public AudioSource doorSound;

    private void Start()
    {
        key2 = FindObjectOfType<KeyManagerFinal>(); // oyunu başlattığımızda içinde key manager olan nesnseyi bulsun
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }



    void OnMouseOver() // mouse kapının üstündeyken
    {
        if (theDistance <= 2)
        {
            Closed_DoorFinal.SetActive(true); // mouse kapının üstüne gelince yazıyı aktif edecek

        }

        else
        {

            Closed_DoorFinal.SetActive(false); // mouse kapının üstüne gelince yazıyı inaktif edecek
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "kilitlikapi2")
        {
            Animator anim = other.GetComponentInChildren<Animator>();


            if (Input.GetKeyDown(KeyCode.E) && key2.anahtar2 == true)
            {

                anim.SetTrigger("openclose");

                doorSound.Play();


            }
        }
    }




    void OnMouseExit()
    {
        Closed_DoorFinal.SetActive(false); // mouse kapının üstüne gelince yazıyı inaktif edecek

    }


}


