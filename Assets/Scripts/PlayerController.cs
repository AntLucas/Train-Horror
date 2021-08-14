using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private Animator anim;

    private bool noChao = false;
    private Transform groundCheck;
    Vector3 novaPosicao;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        
           
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.y < -2f) {

            novaPosicao.y = 0.7193992f;
            novaPosicao.x = transform.position.x;
            transform.position = novaPosicao;

        }

        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


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
       
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (h > 0 && !facingRight) {
            Flip();
        } else if (h < 0 && facingRight) {
            Flip();
        }

        if ((transform.position.x > -1 && transform.position.x < 1) || transform.position.x > -4 && transform.position.x < -2) {
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
}
