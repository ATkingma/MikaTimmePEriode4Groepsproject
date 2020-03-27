using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorld : MonoBehaviour
{
    public GameObject context;
        public GameObject uitleg;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        context.SetActive(true);
        uitleg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Context()
    {
        context.SetActive(false);
        uitleg.SetActive(true);

    }
    public void Uitleg()
    {
        context.SetActive(false);
        uitleg.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
