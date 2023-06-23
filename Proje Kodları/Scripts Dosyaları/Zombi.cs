using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    AudioSource zombiAc; // zombi sesi i�in
    public AudioClip ScreamAC;
    public AudioClip punchAc;
    public AudioClip AgonizingAc; // delirme sesi i�in
    void Start()
    {
        zombiAc = GetComponent<AudioSource>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scream () // ���l�k fonksiyonu
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
