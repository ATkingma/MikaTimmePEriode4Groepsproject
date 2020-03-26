using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject godWeapon11;
    public GameObject godWeapon22;
    public bool godWeapon1;
    public bool godWeapon2;
    public GameObject currentWeapon;
    public List<GameObject> weaponsList = new List<GameObject>();
    public int currentWeaponIndex = 0;
    public bool swapDelay = false;
    public float swapTime;

    //zorgt dat je begint met een wapen
    void Start()
    {
        currentWeapon.SetActive(true);
    }

    //de scroll weapon swap
    private void Update()
    {
        //swap delay
        if (swapDelay == false)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Invoke("SwapTimer", swapTime);
                swapDelay = true;

                currentWeaponIndex--;

                if (currentWeaponIndex >= weaponsList.Count)
                {
                    currentWeaponIndex = 0;
                }
                currentWeapon.SetActive(false);
                currentWeapon = weaponsList[currentWeaponIndex];

                if (currentWeaponIndex <= 0)
                {
                    currentWeaponIndex = weaponsList.Capacity;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Invoke("SwapTimer", swapTime);
                swapDelay = true;

                currentWeaponIndex++;

                if (currentWeaponIndex >= weaponsList.Count)
                {
                    currentWeaponIndex = 0;
                }
                currentWeapon.SetActive(false);
                currentWeapon = weaponsList[currentWeaponIndex];
            }

            //de 1/2/3 weapon select
            if (Input.GetButton("1"))
            {
                Invoke("SwapTimer", swapTime);
                swapDelay = true;

                currentWeapon.SetActive(false);
                currentWeapon = weaponsList[currentWeaponIndex];
                currentWeaponIndex = 0;
            }

            if (Input.GetButton("2"))
            {
                Invoke("SwapTimer", swapTime);
                swapDelay = true;

                currentWeapon.SetActive(false);
                currentWeapon = weaponsList[currentWeaponIndex];
                currentWeaponIndex = 1;
            }


            if (godWeapon1 == true)
            {
                weaponsList.Add(godWeapon11);
                if (Input.GetButton("4"))
                {
                    Invoke("SwapTimer", swapTime);
                    swapDelay = true;

                    currentWeapon.SetActive(false);
                    currentWeapon = weaponsList[currentWeaponIndex];
                    currentWeaponIndex = 3;
                }
            }
            if (godWeapon2 == true)
            {
                weaponsList.Add(godWeapon22);
                if (Input.GetButton("5"))
                {
                    Invoke("SwapTimer", swapTime);
                    swapDelay = true;

                    currentWeapon.SetActive(false);
                    currentWeapon = weaponsList[currentWeaponIndex];
                    currentWeaponIndex = 4;
                }
            
          
            }
        }
        currentWeapon.SetActive(true);
    }
    private void SwapTimer()
    {
        swapDelay = false;
    }
}
