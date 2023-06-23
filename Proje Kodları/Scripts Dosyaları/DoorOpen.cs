using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance; // bu kod hangi nesnenin içine atarsak o nesneye olan mesafeyi tanýmaya yarar
    public GameObject actionKey; // mouse kapýnýn üstüne tuttuðumuzda aktif olmasýný istediðimiz text yazýsý
    public GameObject Door;
    
 
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }



     void OnMouseOver() // mouse kapýnýn üstündeyken
    {
        if (theDistance <=2) 
        { 
        actionKey.SetActive(true); // mouse kapýnýn üstüne gelince yazýyý aktif edecek
        
        }

         else
        {
 
        actionKey.SetActive(false); // mouse kapýnýn üstüne gelince yazýyý inaktif edecek
        }


        
            }
        

    

     void OnMouseExit()
{
    actionKey.SetActive(false); // mouse kapýnýn üstüne gelince yazýyý inaktif edecek
    
}


}