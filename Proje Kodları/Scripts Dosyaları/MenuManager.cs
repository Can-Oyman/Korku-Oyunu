using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeOut; // ge�i�te kararan ekran 
    public GameObject loadtext; //loading yaz�s�
    public GameObject hinttext; // ipucu i�im
    void Start()
    {

    }

    public void NewGameButton ()  // butona bast�g�m�zda coroutine devreye girecek
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
