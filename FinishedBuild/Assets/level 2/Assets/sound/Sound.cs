using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource famas;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            famas.Play();
        }
    }

}
