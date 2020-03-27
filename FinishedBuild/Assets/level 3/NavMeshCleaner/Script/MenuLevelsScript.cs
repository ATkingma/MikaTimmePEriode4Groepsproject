using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Boaz()
    {
        SceneManager.LoadScene(4);
    }
    public void Mika1()
    {
        SceneManager.LoadScene(1);
    }
    public void Mika2()
    {
        SceneManager.LoadScene(3);
    }
    public void Timme1()
    {
        SceneManager.LoadScene(2);
    }
    public void Timme2()
    {
        SceneManager.LoadScene(5);
    }
    public void Timme3()
    {
        SceneManager.LoadScene(6);
    }
   
}
