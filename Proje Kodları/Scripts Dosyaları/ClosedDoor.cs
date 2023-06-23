using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public float theDistance; // bu kod hangi nesnenin içine atarsak o nesneye olan mesafeyi tanýmaya yarar
    public GameObject Closed_Door; // mouse kapýnýn üstüne tuttuðumuzda aktif olmasýný istediðimiz text yazýsý
    public GameObject Door;
    KeyManager key;
    public bool anahtar;
    public AudioSource doorSound;

    private void Start()
    {
        key=FindObjectOfType<KeyManager>(); // oyunu baþlattýðýmýzda içinde key manager olan nesnseyi bulsun
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }



    void OnMouseOver() // mouse kapýnýn üstündeyken
    {
        if (theDistance <= 2)
        {
            Closed_Door.SetActive(true); // mouse kapýnýn üstüne gelince yazýyý aktif edecek

        }

        else
        {

            Closed_Door.SetActive(false); // mouse kapýnýn üstüne gelince yazýyý inaktif edecek
        }

}

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "kilitlikapý")
        {
            Animator anim = other.GetComponentInChildren<Animator>();


            if (Input.GetKeyDown(KeyCode.E) && key.anahtar == true)
            {

                anim.SetTrigger("openclose");

                doorSound.Play();


            }
        }
    }




    void OnMouseExit()
    {
        Closed_Door.SetActive(false); // mouse kapýnýn üstüne gelince yazýyý inaktif edecek

    }


}


