using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flight; // oluþturduðum spotlighdi flight olarak tanýmladým
    public bool drainOverTime; // ýþýk sabit olarak yanmaycak gücü azalýnca parlaklýðý azalýcak
    public float maxBrigtness; // max parlaklýðý gücü fullken   
    public float minBrigtness; // min parlaklýðý gücü azken
    public float drainRate; // bu pilin ne kadar sürede biteceðini gistermek için
    void Start()
    {

        flight = GetComponent<Light>(); //componenti kullancaðýmýz için yazdýk 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            flight.enabled = !flight.enabled; // eðer f tuþuna bastýðýmda enabled ise disable yap disable ise enabled yap kapatýp açmasý için

        }

        if(drainOverTime==true && flight.enabled==true) //  pil sistemini kullanýrken flight aktif ise
        {

            flight.intensity = Mathf.Clamp(flight.intensity, minBrigtness, maxBrigtness); //Mathf.Clamp =  flight.intensity nin  minBrigtness ve  maxBrigtness arasýnda azalýp artmasýný saðlýcak
            if(flight.intensity > minBrigtness)  //eðer oyunun içindeki intensity belirlediðimiz en düþük intensityden büyükse yani pilim daha varssa
            {

                flight.intensity -= Time.deltaTime * (drainRate / 1000); // her saniyede drainrate girdiðim deðer kadar azalmasýný istiyorum örn 100 girelim el fenerim hep açýksa 10 saniyede þarjý biter


            }
        }
     
        else if (drainOverTime==true && flight.enabled==false) // pil sistemi akttifken el fenerim kapalý ise
        {
            if (flight.intensity < maxBrigtness)
            {
                flight.intensity += Time.deltaTime * (drainRate / 1000);
            }


        }



    }
}
