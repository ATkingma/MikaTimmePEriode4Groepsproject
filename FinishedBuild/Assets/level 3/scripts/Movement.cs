using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    // you can initialize variables at their declaration
    private float speed;
    public float norSpeed, sprSpeed;
    private Vector3 movementSpeed;
    public Slider staminaSlider;
    public bool stamina;
    public float staminaValue = 100;

    private void Start()
    {
        stamina = true;
    }
    private void Update()
    {
       staminaSlider.value = staminaValue;
        // movement player x en z axis
        movementSpeed.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movementSpeed.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(movementSpeed);

        // sprint movement
        if (Input.GetButton("Sprint"))
        {
            staminaValue -= 10 * Time.deltaTime;
            speed = sprSpeed;
        }
        else
        {
            if (staminaValue <= 100)
            {
                staminaValue += 10 * Time.deltaTime;
                speed = norSpeed;
            }
        }

      
    }
}