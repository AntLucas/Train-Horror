using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    bool vivo = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
    }

    public void perdeVida() 
    {
        if(vivo)
        {
            vivo = false;
            GameManager.gm.setVida(-1);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

 
}
