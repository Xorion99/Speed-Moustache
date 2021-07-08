using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloPlayer : MonoBehaviour
{
   private CharacterController controller;
   private Vector3 direzione; 
   private int corsia = 1; // 0 sinistra, 1 centro, 2 destra
   public float distcorsia = 4;
   public float velocita;

   public float vel_massima;
   public float potenza_salto;
   public float gravita = -20;
   public Animator animator;

   private bool si_sta_calando = false;
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
    
            if(!Gestione_player.is_started){
            return;
        }

        //la  velocità va gradualmente incrementando fino ad un massimo
        if(velocita < vel_massima)
            velocita += 0.1f * Time.deltaTime;
        
        animator.SetBool("inizio",true);

        controller.Move(direzione*Time.deltaTime);

        direzione.z = velocita;
        
        

        animator.SetBool("terra", controller.isGrounded);

        if(controller.isGrounded){
            
               if(SwipeManager.swipeUp){
                    salta();
        }
        }
        else { 
            direzione.y += gravita * Time.deltaTime;
        }

       if(SwipeManager.swipeDown && !si_sta_calando){
            StartCoroutine(si_cala());
        }
     

        if(SwipeManager.swipeRight){
            corsia++;
            if(corsia == 3)
                corsia = 2;

        }
        if(SwipeManager.swipeLeft){
            corsia--;
            if(corsia == -1)
                corsia = 0;

        }

        Vector3 posizione = transform.position.z * transform.forward + transform.position.y * transform.up;

      if(corsia == 0){
          posizione += Vector3.left * distcorsia;

    }else if(corsia == 2){
        posizione += Vector3.right * distcorsia;

    }
    if(transform.position == posizione)
        return;
    Vector3 diff = posizione - transform.position;
    Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
    if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        controller.Move (moveDir);
    else
        controller.Move(diff);     
    }
  

   private void FixedUpdate(){
           if(!Gestione_player.is_started){
            return;
        }

    }

    private void salta(){
        direzione.y = potenza_salto;
    }

 private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Ostacoli")
        {
            Gestione_player.gameOver = true;
            FindObjectOfType<Gestione_Audio>().suoni_game("GameOver");
        }
    }

    private IEnumerator si_cala (){
        si_sta_calando = true;
        animator.SetBool("calata",true );
        controller.center = new Vector3 (0,-0.5f,0);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3 (0,0,0);
        controller.height = 2;
        animator.SetBool("calata",false);
        si_sta_calando = false;

    }
}
