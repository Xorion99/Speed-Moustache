using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monete_blu : monete
{

     public override void Monete (){
             Gestione_player.count_monete += 2;
             Gestione_Audio.GetIstance().suoni_game("monete");
             Destroy(gameObject);
 }

}


