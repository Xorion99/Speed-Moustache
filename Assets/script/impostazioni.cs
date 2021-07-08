using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class impostazioni : MonoBehaviour
{
    public GameObject pannello_impostazioni;
    int count = 0;

      public void attiva_pannello (){
    
    
     if(count % 2 == 0){
            Time.timeScale = 0; // blocchiamo il gioco
            pannello_impostazioni.SetActive(true);
            count++;
        }
        else 
        {
            Time.timeScale = 1; //riprendiamo
             pannello_impostazioni.SetActive(false); 
            
            count++;
        }
    }

    public void menu_iniziale (){
        SceneManager.LoadScene("menu");

    }
    
  
}
