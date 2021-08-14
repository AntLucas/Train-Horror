using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    Animator anim;
    public bool vivo = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
    }

    public void perdeVida() 
    {
        if(vivo)
        {
            anim.SetTrigger("Morreu");
            vivo = false;
            GetComponent<BoxCollider2D>().size = new Vector2(0.6168906f, 0.225641f);
            GameManager.gm.setVida(-1);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

 
}
