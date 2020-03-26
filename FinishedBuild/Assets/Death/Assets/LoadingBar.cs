using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingBar : MonoBehaviour
{
    public bool loop;
    public bool overworld;
    public bool rest;
    public bool go;
    public Slider reaper;
    public Slider redBar;
    public float redBarValue;
    public float reaperValue;
    public float speed1;
    public float speed2;
    public GameObject dot;
    public GameObject dot1;
    public GameObject dot2;
    public GameObject dot3;
    // Start is called before the first frame update
    void Start()
    {
        speed1 = 1;
        dot.SetActive(true);
        dot1.SetActive(false);
        dot2.SetActive(false);
        dot3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
            if (loop == false)
        {
            Punt0();
        }


        if (go == true)
        {
            reaper.value = reaperValue;
            redBar.value = redBarValue;
            if (redBarValue >= 100)
            {
                if (overworld == true)
                {
                SceneManager.LoadScene(1);

                }
            }



            if (redBarValue <= 100)
            {
                redBarValue = Time.time * 1;
            }
            if (redBarValue >= 100)
            {
                redBarValue = 100;
            }
            if (reaperValue <= 60)
            {

                reaperValue = Time.time * 0.6f;


            }
            if (reaperValue >= 60)
            {
                reaperValue = 60;
            }



        }
        if (go == false)
        {
            reaperValue = 0;
            redBarValue = 0;
        }

    }
    public void SetActiveGo()
        {
            go = true;
        }
public void SetFalseGo()
        {
            go = false;
        }
    public void CloseNowG()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        rest = true;
        overworld = false;
    }
    public void Overworld()
    {
        overworld = true;
            rest = false;
    }
    public void Punt0()
    {
        dot3.SetActive(false);
        dot.SetActive(true);
        loop = true;
        Invoke("Punt1", 1.25f);
    }
    public void Punt1()
    {
        dot.SetActive(false);
        dot1.SetActive(true);
        Invoke("Punt2", 1.25f);
    }
    public void Punt2()
    {
        dot1.SetActive(false);
        dot2.SetActive(true);
        Invoke("Punt3", 1.25f);
    }
    public void Punt3()
    {
        dot2.SetActive(false);
        dot3.SetActive(true);
        Invoke("Punt0", 1.25f);
    }
    public void HooftMenu()
    {
        SceneManager.LoadScene(0);
    }
}
  
        

    

