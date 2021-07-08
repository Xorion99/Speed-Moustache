using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestione_player : MonoBehaviour
{
    public static bool gameOver;
    public GameObject PannelloGameOver;
    public static bool is_started;
    public GameObject testo_iniziale;

    public GameObject pannello_new_record;

    public static int count_monete;

    public Text testo_monete;


    public int score;

     public Text scoreText;

     public Text new_record;

     private static Gestione_player istanza;



       void Awake (){
        if(istanza == null)
            istanza = this;
        else
            Destroy (gameObject);
    }

    public static Gestione_player getIstance(){
        return istanza;
    }


    void Start()
    {
        score = 0;
        gameOver = false;
        is_started = false;
        Time.timeScale = 1;
        count_monete = 0;
    }

    // Update is called once per frame
    void Update()
    {
       PlayerPrefs.SetInt("coins", count_monete);
       testo_monete.text = PlayerPrefs.GetInt("Coins", 0).ToString();
         
        if (gameOver){
            Time.timeScale = 0;
              if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                pannello_new_record.SetActive(true);
                new_record.text = "NEW RECORD: " + score;
                PlayerPrefs.SetInt("HighScore", score);                
            }
            else
                PannelloGameOver.SetActive(true);
        }
        
        scoreText.text = "Score: " + score;
        testo_monete.text = "Coins: " + count_monete;
        //Debug.Log ("Score:" + score);

        if(SwipeManager.tap){
            is_started = true;
            Destroy (testo_iniziale);
        }

    }




}