using UnityEngine;
using UnityEngine.SceneManagement;  
public class Menu : MonoBehaviour
{
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Capitulo1");
        }
    }
}
