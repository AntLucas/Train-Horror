using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    List<int> esconderijos = new List<int>();
    List<int> escadas = new List<int>();
    public float speed;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private Animator anim;

    private bool noChao = false;
    private Transform groundCheck;
    Vector3 novaPosicao;
    public bool embaixo;
    public bool entreVagao; 
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");

        esconderijos.Add(-60);
        esconderijos.Add(-40);
        esconderijos.Add(-15);
        esconderijos.Add(-3);
        esconderijos.Add(0);
        esconderijos.Add(13);
        esconderijos.Add(55);
        esconderijos.Add(100);
        esconderijos.Add(130);
        
        escadas.Add(-24);
        escadas.Add(32);
        escadas.Add(89);
        escadas.Add(146);

        embaixo = true;    
        entreVagao = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 5) {
            embaixo = false;
        } else {
            embaixo = true;
        }

        if (transform.position.y < -2f) {

            novaPosicao.y = 0.7193992f;
            novaPosicao.x = transform.position.x;
            transform.position = novaPosicao;

        }

        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (noChao) {
            entreVagao = false;
        } else {
            entreVagao = true;
        }

    //     if (Input.GetKeyDown(KeyCode.X)) {
    //     Vector3 theScale = transform.localScale;
    //     float a = 4.5f;
    //     theScale.x += a;
    //     theScale.y += a;
    //     transform.localScale = theScale;
    // }

    // if (Input.GetKeyDown(KeyCode.B)) {
        
    //      Vector3 theScale = transform.localScale;
    //     theScale.x *= 0;
    //     theScale.y *= 0;
    //     transform.localScale = theScale;
    // }

        
       
    }

    void FixedUpdate()
    {

        if (Input.GetKey("up") || Input.GetKeyUp(KeyCode.W)) {

            foreach (int subir in escadas) {
                if (transform.position.x >= subir - 2 && (transform.position.x <= subir + 1)) {
                    Debug.Log("OLA");

                    novaPosicao.y = 6.5f;
                    novaPosicao.x = transform.position.x + 4f;
                    transform.position = novaPosicao;
                }
            }
        
            
            
    //     Vector3 theScale = transform.localScale;
    //     float a = 4.5f;
    //     theScale.x += a;
    //     theScale.y += a;
    //     transform.localScale = theScale;
        }
        
       
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (h > 0 && !facingRight) {
            Flip();
        } else if (h < 0 && facingRight) {
            Flip();
        }
        bool escondido = false;

        foreach (int malas in esconderijos)
        {

            if (transform.position.x > (malas -1) && transform.position.x < (malas + 1) && embaixo) {

                escondido = true;

            }

        }

        if (escondido) {
            Esconder();
        } else {
            Aparecer();
        }

    }

    void Flip() 
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        if(theScale.x == 0f && facingRight == true) {
            theScale.x = 4.5f;
        } else if (theScale.x == 0f && facingRight == false){
            theScale.x = -4.5f;
        } else {
            theScale.x *= -1;
        }
        
        transform.localScale = theScale;
    }

    void Esconder() {
    
        Vector3 theScale = transform.localScale;
        theScale.x *= 0;
        theScale.y *= 0;
        transform.localScale = theScale;   
        
    }

    void Aparecer() {
        Vector3 theScale = transform.localScale;  
        float h = Input.GetAxisRaw("Horizontal");
        if(h > 0.0) {
            facingRight = true;
            theScale.x = 4.5f; 
        } else if (h < 0.0) {
            facingRight = false;
            theScale.x = -4.5f;
        }
        theScale.y = 4.5f;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bloqueio"))
        {   

            if (GameManager.gm.getMalas() > 14) {

                Destroy(other.gameObject);
               
            } else {
                
            }

        } 
    }
}
