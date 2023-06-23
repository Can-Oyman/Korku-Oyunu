using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etkıdemırkapı : MonoBehaviour
{
    public AudioSource doorSound1;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "demırkapı")
        {

            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("openclose");
                doorSound1.Play();



            }

        }
    }
}