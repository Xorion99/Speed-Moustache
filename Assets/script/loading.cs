using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
   public float wait_time = 3f;
    void Start()
    {
        StartCoroutine(stop());
    }
    IEnumerator stop (){
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("video_logo");

    }
  
}