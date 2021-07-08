using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monete_rosse : monete
{
  public override void Monete (){
             Gestione_player.count_monete++;
             FindObjectOfType<Gestione_Audio>().suoni_game("monete");
             Destroy(gameObject);
 }

}
