using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource fx; // ses için tanýmlama
    public AudioClip hoverfx;// sesleri klipten cekmek icin
    public AudioClip clickfx; //click yaptýgýmýzdaki ses
  

    public void HoverSound()
    {

        fx.PlayOneShot(hoverfx);

    } 
    public void ClickSound
        ()
    {

        fx.PlayOneShot(clickfx);

    }


   

}
