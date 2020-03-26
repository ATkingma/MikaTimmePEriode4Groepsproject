using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private GameObject[] heavys;
    private GameObject[] lights;
    private GameObject boss;

    public GameObject InGameUi;
    public GameObject MenuUi;
    public bool menubool;
    public bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        menubool = false;
        InGameUi.SetActive(true);
        MenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            
            if (menubool == true)
            {
                Invoke("InGame", 0.5f);
             
              
            
            }
            if (inGame == true)
            {
                Invoke("CanvasMenu", 0.5f);
              
            }


        }
        heavys = GameObject.FindGameObjectsWithTag("Heavy");
       lights = GameObject.FindGameObjectsWithTag("Light");
        boss = GameObject.FindGameObjectWithTag("Boss");


        if (menubool == true)
        {
            //Menustaat aan
            Cursor.lockState = CursorLockMode.None;
            InGameUi.SetActive(false);
            MenuUi.SetActive(true);
        }
        if (inGame == true)
        {
            //Menustaat aan
            Cursor.lockState = CursorLockMode.Locked;
            InGameUi.SetActive(true);
            MenuUi.SetActive(false);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Overworld()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitMenu()
    {
        Application.Quit();
    }
    public void InGame()
    {
        inGame = true;
        menubool = false;
        foreach (GameObject heavy in heavys)
        {
            heavy.GetComponent<NavMeshAgent>().speed = 3;
        }
        foreach (GameObject light in lights)
        {
            light.GetComponent<NavMeshAgent>().speed = 2;
        }
        boss.GetComponent<NavMeshAgent>().speed = 5;
    }
    public void CanvasMenu()
    {
        menubool = true;
        inGame = false;
        foreach (GameObject heavy in heavys)
        {
            heavy.GetComponent<NavMeshAgent>().speed = 0;
        }
        foreach (GameObject light in lights)
        {
            light.GetComponent<NavMeshAgent>().speed = 0;
        }
        boss.GetComponent<NavMeshAgent>().speed = 0;
    }

}
