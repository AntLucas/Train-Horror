using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    bool facingRight = false;
    bool noChao = false;
    Transform groundCheck;

    
    // Start is called before the first frame update
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();
     groundCheck = transform.Find("MonsterGroundCheck");   
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!noChao) {
            speed *= -1;
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(speed, rb.velocity.y);

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
            speed *= -1;
        }
    }
}
