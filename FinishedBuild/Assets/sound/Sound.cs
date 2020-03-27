using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource famas;
    public AudioSource reload;
    public AudioSource handGun;

    public void Update()
    {
        if (Input.GetButton("r"))
        {
            reload.Play();

        }

        if (Input.GetButtonDown("Fire1"))
        {
            famas.Play();

        }
        if (Input.GetButtonDown("Fire1"))
        {
            handGun.Play();

        }
    }
    

}
