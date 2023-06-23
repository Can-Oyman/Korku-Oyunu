using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeOut; // geçiþte kararan ekran 
    public GameObject loadtext; //loading yazýsý
    public GameObject hinttext; // ipucu içim
    void Start()
    {

    }

    public void NewGameButton ()  // butona bastýgýmýzda coroutine devreye girecek
    {

        StartCoroutine(NewGame());
    
    }


    IEnumerator NewGame()
    {

        fadeOut.SetActive(true); // siyah ekran gelicek 
        yield return new WaitForSeconds(3);
        loadtext.SetActive(true);
        hinttext.SetActive(true);
        SceneManager.LoadScene(0);
        

    }
   
}
