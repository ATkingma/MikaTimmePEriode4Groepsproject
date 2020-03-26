using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour
{
    public Slider health;
    public Slider stamina;
  
    public void SetMaxHealth(int hp)
    {
        health.maxValue = hp;
        health.value = hp;
    }
    public void SetHealth(int hp)
    {
        health.value = hp;
    }
    public void SetMaxStamina(int st)
    {
        stamina.maxValue = st;
        stamina.value = st;
    }
    public void SetStamina(int st)
    {
        stamina.value = st;
    }
}
