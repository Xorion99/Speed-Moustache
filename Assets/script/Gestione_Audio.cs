using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]


public  class Suoni  {

    public  string nome;
    public  AudioClip clip;
    public  float volume;
    public bool loop;
    public AudioSource source;

    
}




public class Gestione_Audio : MonoBehaviour
{

    private bool muted;


    public Suoni[] suoni;
    private static Gestione_Audio istanza;

    void Awake (){
        if(istanza == null)
            istanza = this;
        else
            Destroy (gameObject);
    }

    public static Gestione_Audio GetIstance(){
        return istanza;
    }
    void Start()
    {


        foreach (Suoni s in suoni){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

        }

        muted = PlayerPrefs.GetInt("muted") == 1;
        suoni_game("Principale");
        
        if (muted){
            AudioListener.pause = true;
            
            

        }  

    }


    public void suoni_game (string nome){
         foreach (Suoni s in suoni){
           if(s.nome == nome){
                s.source.Play();
            
           }

        }
        

    }
    public void pausa_suoni (string nome){
         foreach (Suoni s in suoni){
           if(s.nome == nome){
                s.source.Pause();
           }
        }
        
    }
  

  public void its_muted (){
      muted = !muted;

      if(muted)
        PlayerPrefs.SetInt("muted",1);
     else
        PlayerPrefs.SetInt("muted",0);

    if(muted)
        AudioListener.pause = true;
    else
        AudioListener.pause = false;


  }
}
