using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etkı : MonoBehaviour
{
    public AudioSource doorSound;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "door")
        {

            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("openclose");
                doorSound.Play();

               

            }
           
        }
    }
}
