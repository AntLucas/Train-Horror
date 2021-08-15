using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterScript : MonoBehaviour
{

    List<int> esconderijos = new List<int>();

    public float speed;

    private Animator anim;
    Rigidbody2D rb;
    bool facingRight = false;
    bool noChao = false;
    Transform groundCheck;

    public GameObject jogador;

    bool playerVivo = true;
    private float fixedDeltaTime;

    Vector3 novaPosicao;


    
    // Start is called before the first frame update
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();
     anim = gameObject.GetComponent<Animator>();
     groundCheck = transform.Find("MonsterGroundCheck");   

    esconderijos.Add(-60);
    esconderijos.Add(-40);
    esconderijos.Add(-15);
    esconderijos.Add(-3);
    esconderijos.Add(0);
    esconderijos.Add(13);
    esconderijos.Add(55);
    esconderijos.Add(100);
    esconderijos.Add(130);

    }


    // Update is called once per frame
    void Update()
    {


        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!noChao) {
            speed *= -1;
        }

        if(jogador.gameObject.GetComponent<PlayerLife>().vivo) {
            bool playerEncontrado = true;

            foreach (int malas in esconderijos)
            {

                    if (jogador.transform.position.x > (malas -1) && jogador.transform.position.x < (malas + 1)) {

                        playerEncontrado = false;

                    }

            }
            
                if (!playerEncontrado || !jogador.gameObject.GetComponent<PlayerController>().embaixo || !jogador.gameObject.GetComponent<PlayerController>().embaixo || jogador.gameObject.GetComponent<PlayerController>().entreVagao) {
                         
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                        
                    if( speed > 0) {
                        speed = 1;
                    } else {
                        speed = -1;
                    }
                        
                } else if (noChao) {

                    if (transform.position.x - 30 < jogador.transform.position.x && transform.position.x + 30 > jogador.transform.position.x) {
                            
                        if (jogador.transform.position.x < transform.position.x && speed > 0)  {
                            speed = -2.5f;
                        } else if (jogador.transform.position.x > transform.position.x && speed < 0) {
                            speed = 2.5f;
                        } else if (jogador.transform.position.x < transform.position.x && speed < 0) {
                            speed = -2.5f;
                        } else if (jogador.transform.position.x > transform.position.x && speed > 0) {
                            speed = 2.5f;
                        }
                            
                    }

                    rb.velocity = new Vector2(speed, rb.velocity.y);

                }

        }
            
        else if (!playerVivo) {
                

            if(jogador.transform.position.y > -1.2f) {
                if (this.fixedDeltaTime < 1) {
                        
                    novaPosicao.y += -0.0035f;
                    novaPosicao.x = jogador.transform.position.x;
                    jogador.transform.position = novaPosicao;
                        
                }
            } else {
                     novaPosicao.y = -1.2f;
                     novaPosicao.x = jogador.transform.position.x;
                     jogador.transform.position = novaPosicao;
            }
   
            anim.SetTrigger("Atacou");
                   
        }
        
    }

    void FixedUpdate() {
        
        if (speed > 0 && !facingRight) {
            Flip();
        } else if (speed < 0 && facingRight) {
            Flip();
        }

    }

    void Flip() 
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   

            bool playerEncontrado = true;

            foreach (int malas in esconderijos)
            {

                    if (jogador.transform.position.x > (malas -1) && jogador.transform.position.x < (malas + 1)) {

                        playerEncontrado = false;

                    }

            } 
            if (playerEncontrado) {
                 
                    other.gameObject.GetComponent<PlayerLife>().perdeVida();
                    novaPosicao = jogador.transform.position;
                    playerVivo = false;
                
            } 
        } else if (other.gameObject.CompareTag("Monster")){
                speed *= -1;
        }
            
    }

}
