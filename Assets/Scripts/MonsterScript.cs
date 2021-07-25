using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float speed;

    private Animator anim;
    Rigidbody2D rb;
    bool facingRight = false;
    bool noChao = false;
    Transform groundCheck;

    public GameObject jogador;

    
    // Start is called before the first frame update
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();
     anim = gameObject.GetComponent<Animator>();
     groundCheck = transform.Find("MonsterGroundCheck");   
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!noChao) {
            speed *= -1;
        }

        if ((jogador.transform.position.x + 1.2 < transform.position.x || jogador.transform.position.x - 1.2 > transform.position.x) || (jogador.transform.position.x > -1 && jogador.transform.position.x < 1) || (jogador.transform.position.x > -4 && jogador.transform.position.x < -2)) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else if (jogador.transform.position.x + 1.2 >= transform.position.x || jogador.transform.position.x - 1.2 <= transform.position.x){
            anim.SetTrigger("Atacou");
        }  
            if ((jogador.transform.position.x >= -1 && jogador.transform.position.x <= 1) || (jogador.transform.position.x >= -4 && jogador.transform.position.x <= -2)) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                
                if( speed > 0) {
                    speed = 1;
                } else {
                    speed = -1;
                }
                
            } else {
                
                if (jogador.transform.position.x < transform.position.x && speed > 0)  {
                    speed = -2;
                } else if (jogador.transform.position.x > transform.position.x && speed < 0) {
                    speed = 2;
                } else if (jogador.transform.position.x < transform.position.x && speed < 0) {
                    speed = -2;
                } else if (jogador.transform.position.x > transform.position.x && speed > 0) {
                    speed = 2;
                }
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            anim.SetTrigger("Atacou");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            if ((jogador.transform.position.x >= -1 && jogador.transform.position.x <= 1) || (jogador.transform.position.x >= -4 && jogador.transform.position.x <= -2)) {    
            } else {
                
                other.gameObject.GetComponent<PlayerLife>().perdeVida();
            }
            
        } else if (other.gameObject.CompareTag("Monster")){
            speed *= -1;
        }
    }

}
