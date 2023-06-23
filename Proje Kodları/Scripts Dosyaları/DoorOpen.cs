using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance; // bu kod hangi nesnenin i�ine atarsak o nesneye olan mesafeyi tan�maya yarar
    public GameObject actionKey; // mouse kap�n�n �st�ne tuttu�umuzda aktif olmas�n� istedi�imiz text yaz�s�
    public GameObject Door;
    
 
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }



     void OnMouseOver() // mouse kap�n�n �st�ndeyken
    {
        if (theDistance <=2) 
        { 
        actionKey.SetActive(true); // mouse kap�n�n �st�ne gelince yaz�y� aktif edecek
        
        }

         else
        {
 
        actionKey.SetActive(false); // mouse kap�n�n �st�ne gelince yaz�y� inaktif edecek
        }


        
            }
        

    

     void OnMouseExit()
{
    actionKey.SetActive(false); // mouse kap�n�n �st�ne gelince yaz�y� inaktif edecek
    
}


}