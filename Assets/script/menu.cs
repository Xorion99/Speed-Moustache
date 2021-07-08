using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class menu : MonoBehaviour
{
    [SerializeField] private GameObject pannello_progresso;
    [SerializeField] private Slider barra_progresso;
    [SerializeField] private Text percentuale_progresso;

    private static menu istanza;


    public Text highScoreText;
    public Text testo_monete;

   

   // public Animator messageAnim;

    void Awake(){
        if(istanza == null)
            istanza = this;
        else
            Destroy(gameObject);    
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        highScoreText.text = "High Score:" + PlayerPrefs.GetInt("HighScore", 0);
         testo_monete.text = "Coins:" + PlayerPrefs.GetInt("coins",0).ToString();
    }




    public void sveglia(){
        pannello_progresso.SetActive(false);
    }

    public void play(){
        SceneManager.LoadScene("level");
    }

    public void Menu (){
        SceneManager.LoadScene("menu");
    }

    public void quit (){
        Application.Quit();
    }

    public void carica_livello (string Nome_Livello){
        StartCoroutine(carica_livello_sync(Nome_Livello));
        pannello_progresso.SetActive(true);


    }

    private IEnumerator carica_livello_sync (string Nome_Livello ){
        AsyncOperation operation = SceneManager.LoadSceneAsync(Nome_Livello);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress);
            //Debug.Log(progress);
            barra_progresso.value = progress;
            percentuale_progresso.text = (progress * 100f).ToString("F0") + "%";
            yield return null;

        }
        
    }
}
