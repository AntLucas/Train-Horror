using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int vida = 1;
    // Start is called before the first frame update
    public int malas = 0;

    private void Start()
    {
        GameObject.Find("msgMala").GetComponent<Text>().enabled = false;
    }
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

    public void SetDica(int mala)
    {
        malas += mala;
        if(malas >= 50)
        {
            malas = 0;

        }
        AtualizaHud();
    }

    public int getVida()
    {
        return vida;
    }

    public void AtualizaHud()
    {
        Debug.Log(malas.ToString());
        GameObject.Find("Dica1Text").GetComponent<Text>().text = malas.ToString();
    }

    public int getMalas()
    {
        return malas;
    }
}
