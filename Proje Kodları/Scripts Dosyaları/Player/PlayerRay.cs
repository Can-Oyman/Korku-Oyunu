using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public static float distanceFromTarget; //birden fazla nesnenin uzakl���n� hesaplayaca��m�z i�in di�er scriptlerde ula�mam�z i�in static olarak a�t�m.
    public float toTarget;   // toTarget Her nesnelere olan uzakl���m�z� hesaplar duvar masa 

  
    void Update()
    {
        RaycastHit hit; // playerdan ��kan bir yere �arpan ���k demeti,hit= ���k demeti

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) //e�er bu ���n�n bir nesneye �arparsa karakterden ��kan ���nlar,3 boyutlu d�nyada ileri do�ru gidip ��kt�s�da ���n demeti olsun.
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
