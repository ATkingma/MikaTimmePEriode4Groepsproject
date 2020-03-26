using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDestroy : MonoBehaviour
{

    public GameObject kip;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag== "river")
        {
            Destroy (gameObject); 
        }
    }
}
