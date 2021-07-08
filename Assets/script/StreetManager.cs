using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public GameObject[] StreetPrefabs;
    public double zspawn = 0;
    public double lungstreet = 16.334;

    public int numero_strade = 20;
    private List<GameObject> attiva_strade = new List<GameObject>();
    public Transform player;

 
    void Start()
    {
        for(int i = 0; i < numero_strade; i++){
          
           //Quando inizia il gioco spownano volontariamente solo percorsi semplici
           if(i == 0)
            spawnStreet(0);
            else if (i == 1)
                spawnStreet(Random.Range(1,5));
            else if (i == 2)
                spawnStreet(Random.Range(1,5));
            else if (i == 3)
                spawnStreet(Random.Range(1,5));
            
            else if (i == 4)
                spawnStreet(Random.Range(1,5));
                
            
            else if (i == 5)
                spawnStreet(Random.Range(1,5));
        else//dopo i primi 5 percorsi iniziano a spownare in modo casuale
            spawnStreet(Random.Range(1,StreetPrefabs.Length));     
            }
           
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - 30 > zspawn-(numero_strade*lungstreet)){
            spawnStreet(Random.Range(1,StreetPrefabs.Length));
            deleteStreet();    
        }
        
        
    }
    public void spawnStreet(int streetIndex){
         GameObject go =  Instantiate(StreetPrefabs[streetIndex],transform.forward *  (float) zspawn,transform.rotation);
         attiva_strade.Add(go);
         zspawn +=  lungstreet;
         
         
    }
    private void deleteStreet(){
        Destroy(attiva_strade[0]);
        attiva_strade.RemoveAt(0);
        Gestione_player.getIstance().score += 3;
        
    }
}
