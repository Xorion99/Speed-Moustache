using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logo_video : MonoBehaviour
{
   public float wait_time = 3f;
    void Start()
    {
        StartCoroutine(fermo());
    }
    IEnumerator fermo (){
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("menu");

    }
  
}