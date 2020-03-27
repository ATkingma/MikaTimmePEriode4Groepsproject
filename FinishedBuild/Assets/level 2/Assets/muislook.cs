using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuisLook : MonoBehaviour
{
    public float Mousesence = 500f;
    float xRotation = 0f;
    public Transform Player;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Mousesence * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Mousesence * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Vector3 rot = new Vector3(0, mouseX, 0);
        Player.Rotate(rot);

    }
}
