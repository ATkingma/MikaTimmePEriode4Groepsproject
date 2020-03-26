using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playerhealth : MonoBehaviour
{
    public Slider php;
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        php.value = maxHealth;
    }
    public void DoDamage(int i)
    {
        maxHealth -= i;
        if (maxHealth <= (0))

        {
            SceneManager.LoadScene(sceneBuildIndex: 7);



        }
    }

}
