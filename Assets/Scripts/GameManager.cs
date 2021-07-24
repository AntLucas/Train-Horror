using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int vida = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }  
        else
        {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVida(int vidas) 
    {
        vida += vidas;
    }

    public int getVida()
    {
        return vida;
    }
}
