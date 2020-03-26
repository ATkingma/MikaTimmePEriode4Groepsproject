using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public GameObject bird;
    public  Vector3 move;
    public float a;
    public float fo;
    public float fs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move);

        move.x = Random.Range(-30.95f, -30.95f);
        move.y = Random.Range(21.37405f, 21.37405f);
        move.z = Random.Range(144.0299f, 144.0299f);

        Invoke("spawn", 2f);

            


    }
    public void spawn()
    {
        Instantiate(bird, move, Quaternion.identity);
        


    }
}
