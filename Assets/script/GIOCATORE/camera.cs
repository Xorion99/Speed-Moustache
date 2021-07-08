using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform giocatore;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - giocatore.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newpos = new Vector3 (transform.position.x,transform.position.y,offset.z + giocatore.position.z);
        transform.position = Vector3.Lerp(transform.position,newpos,10*Time.deltaTime);
            }
}
