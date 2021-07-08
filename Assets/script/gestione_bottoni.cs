using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestione_bottoni : MonoBehaviour
{
    public Button btn;
    
    
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
    tutorial.getIstance().attiva_pannello();
    }
}
