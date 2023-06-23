using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieCollider : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.mute = true;
        }
    }
}
