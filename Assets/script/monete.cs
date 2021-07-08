using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monete : MonoBehaviour
{
  

  public virtual void Monete (){
    return;
  }


    // Update is called once per frame
    void Update()
    {
        transform.vai(); //facciamo ruotare la moneta

    }

    //metodo per la scomparsa e incremento delle monete
    private void OnTriggerEnter(Collider other){
         if(other.tag == "Player"){
             Gestione_player.count_monete++;
            //Debug.Log ("Coins:" + Gestione_player.count_monete);
            // FindObjectOfType<Gestione_Audio>().suoni_game("monete");
            Gestione_Audio.GetIstance().suoni_game("monete");
             Destroy(gameObject);

         }   
         Monete ();
        }
         
        
}