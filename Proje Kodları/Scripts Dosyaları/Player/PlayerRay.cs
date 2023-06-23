using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public static float distanceFromTarget; //birden fazla nesnenin uzaklýðýný hesaplayacaðýmýz için diðer scriptlerde ulaþmamýz için static olarak açtým.
    public float toTarget;   // toTarget Her nesnelere olan uzaklýðýmýzý hesaplar duvar masa 

  
    void Update()
    {
        RaycastHit hit; // playerdan çýkan bir yere çarpan ýþýk demeti,hit= ýþýk demeti

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) //eðer bu ýþýnýn bir nesneye çarparsa karakterden çýkan ýþýnlar,3 boyutlu dünyada ileri doðru gidip çýktýsýda ýþýn demeti olsun.
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
