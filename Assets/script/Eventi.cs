using UnityEngine.SceneManagement;
using UnityEngine;

public class Eventi : MonoBehaviour
{
    private static Eventi istanza;

    void Awake(){
        if(istanza == null)
            istanza = this;
        else    
            Destroy(gameObject);    
    }
    public void rigioca (){
        SceneManager.LoadScene("Level");
    }

    public void esci_dal_gioco (){
        Application.Quit();
    }

}
