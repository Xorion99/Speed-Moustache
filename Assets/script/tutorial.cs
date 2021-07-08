using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tutorial : MonoBehaviour
{

    public GameObject pannello_tutorial;
    public GameObject pannello_tutorial2;

    public GameObject pannello_tutorial3;
    public int count = 0;
    public int count2 = 0;
    
    private static tutorial istanza;


    void Awake (){
        if(istanza == null)
            istanza = this;
        else
            Destroy (gameObject);
    }
    public static tutorial getIstance(){
        return istanza;
    }
  public void attiva_pannello (){
    
    
     if(count % 2 == 0){
            pannello_tutorial.SetActive(true);
            count++;
        }
        else 
        {
            pannello_tutorial.SetActive(false);
            pannello_tutorial2.SetActive(false);
            pannello_tutorial3.SetActive(false);
            
            count++;
        }
    }
public void attiva_pannello2 (){
    pannello_tutorial2.SetActive(true);
}

public void attiva_pannello3 (){
    pannello_tutorial3.SetActive(true);
}
public void close (){
            pannello_tutorial.SetActive(false);
            pannello_tutorial2.SetActive(false);
            pannello_tutorial3.SetActive(false);
            count++;
}

}