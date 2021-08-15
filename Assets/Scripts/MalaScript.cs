using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MalaScript : MonoBehaviour
{
    BoxCollider2D col; 
    Text msgMala;  
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gm.SetDica(1);
            col.enabled = false;
            Destroy(gameObject, 0.2f);
        }    
    }
}
