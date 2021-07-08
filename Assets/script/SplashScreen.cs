using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
   public float wait_time = 5f;
    void Start()
    {
        StartCoroutine(fermo());
    }
    IEnumerator fermo (){
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("loading");

    }
  
}