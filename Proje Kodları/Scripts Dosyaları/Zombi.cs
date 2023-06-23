using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    AudioSource zombiAc; // zombi sesi için
    public AudioClip ScreamAC;
    public AudioClip punchAc;
    public AudioClip AgonizingAc; // delirme sesi için
    void Start()
    {
        zombiAc = GetComponent<AudioSource>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scream () // çýðlýk fonksiyonu
    {
        zombiAc.PlayOneShot(ScreamAC);


    }


    public void Punch () // vurma yumruk
    {
        zombiAc.PlayOneShot(punchAc);

    }

    public void Agonizing ()
    {

        zombiAc.PlayOneShot(AgonizingAc);


    }



}
