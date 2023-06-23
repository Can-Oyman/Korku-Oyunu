using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public float theDistance; // bu kod hangi nesnenin i�ine atarsak o nesneye olan mesafeyi tan�maya yarar
    public GameObject Closed_Door; // mouse kap�n�n �st�ne tuttu�umuzda aktif olmas�n� istedi�imiz text yaz�s�
    public GameObject Door;
    KeyManager key;
    public bool anahtar;
    public AudioSource doorSound;

    private void Start()
    {
        key=FindObjectOfType<KeyManager>(); // oyunu ba�latt���m�zda i�inde key manager olan nesnseyi bulsun
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }



    void OnMouseOver() // mouse kap�n�n �st�ndeyken
    {
        if (theDistance <= 2)
        {
            Closed_Door.SetActive(true); // mouse kap�n�n �st�ne gelince yaz�y� aktif edecek

        }

        else
        {

            Closed_Door.SetActive(false); // mouse kap�n�n �st�ne gelince yaz�y� inaktif edecek
        }

}

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "kilitlikap�")
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
        Closed_Door.SetActive(false); // mouse kap�n�n �st�ne gelince yaz�y� inaktif edecek

    }


}


