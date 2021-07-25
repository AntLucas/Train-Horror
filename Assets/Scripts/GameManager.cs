using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int vida = 1;
    // Start is called before the first frame update
    private int mala = 0;

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

    public void SetDica(int malas)
    {
        mala += malas;
        if(mala >= 3)
        {
            mala= 0;
        }
        AtualizaHud();
    }

    public int getVida()
    {
        return vida;
    }

    public void AtualizaHud()
    {
        //GameObject.Find("Dica1Text").GetComponent<Text>().text = mala.ToString();
    }
}
