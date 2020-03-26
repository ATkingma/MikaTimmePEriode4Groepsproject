using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound1 : MonoBehaviour
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
