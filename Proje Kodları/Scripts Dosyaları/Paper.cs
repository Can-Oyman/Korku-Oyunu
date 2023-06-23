using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject PaperPanel; //açtýðýmýz paneli tanýmladýk
    public GameObject RealPaper; //Masanýn üzerindeki sayfayý yok etmek için tanýmladým
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //collider oluþturdðum alana girince
    {
    
        if (other.tag=="Player")  // player adlý tagli karakterim bu alana girince yapýlacaklar
        {


            PaperPanel.SetActive(true);
            RealPaper.SetActive(false); //kaðýdý okurken masada sayfa gözükmesin
        }
       
     }

    private void OnTriggerExit(Collider other) //collider oluþturdðum alandan çýkýnca
    {

        if (other.tag == "Player")  // player adlý tagli karakterim bu alana girince yapýlacaklar
        {

            PaperPanel.SetActive(false);
            RealPaper.SetActive(true); // kaðýdý okuyunca yeniden masada sayfa gözüksün 
        }



    }




}
