using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject PaperPanel; //a�t���m�z paneli tan�mlad�k
    public GameObject RealPaper; //Masan�n �zerindeki sayfay� yok etmek i�in tan�mlad�m
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //collider olu�turd�um alana girince
    {
    
        if (other.tag=="Player")  // player adl� tagli karakterim bu alana girince yap�lacaklar
        {


            PaperPanel.SetActive(true);
            RealPaper.SetActive(false); //ka��d� okurken masada sayfa g�z�kmesin
        }
       
     }

    private void OnTriggerExit(Collider other) //collider olu�turd�um alandan ��k�nca
    {

        if (other.tag == "Player")  // player adl� tagli karakterim bu alana girince yap�lacaklar
        {

            PaperPanel.SetActive(false);
            RealPaper.SetActive(true); // ka��d� okuyunca yeniden masada sayfa g�z�ks�n 
        }



    }




}
