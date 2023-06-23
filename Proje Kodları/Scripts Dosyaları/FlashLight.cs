using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flight; // olu�turdu�um spotlighdi flight olarak tan�mlad�m
    public bool drainOverTime; // ���k sabit olarak yanmaycak g�c� azal�nca parlakl��� azal�cak
    public float maxBrigtness; // max parlakl��� g�c� fullken   
    public float minBrigtness; // min parlakl��� g�c� azken
    public float drainRate; // bu pilin ne kadar s�rede bitece�ini gistermek i�in
    void Start()
    {

        flight = GetComponent<Light>(); //componenti kullanca��m�z i�in yazd�k 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            flight.enabled = !flight.enabled; // e�er f tu�una bast���mda enabled ise disable yap disable ise enabled yap kapat�p a�mas� i�in

        }

        if(drainOverTime==true && flight.enabled==true) //  pil sistemini kullan�rken flight aktif ise
        {

            flight.intensity = Mathf.Clamp(flight.intensity, minBrigtness, maxBrigtness); //Mathf.Clamp =  flight.intensity nin  minBrigtness ve  maxBrigtness aras�nda azal�p artmas�n� sa�l�cak
            if(flight.intensity > minBrigtness)  //e�er oyunun i�indeki intensity belirledi�imiz en d���k intensityden b�y�kse yani pilim daha varssa
            {

                flight.intensity -= Time.deltaTime * (drainRate / 1000); // her saniyede drainrate girdi�im de�er kadar azalmas�n� istiyorum �rn 100 girelim el fenerim hep a��ksa 10 saniyede �arj� biter


            }
        }
     
        else if (drainOverTime==true && flight.enabled==false) // pil sistemi akttifken el fenerim kapal� ise
        {
            if (flight.intensity < maxBrigtness)
            {
                flight.intensity += Time.deltaTime * (drainRate / 1000);
            }


        }



    }
}
