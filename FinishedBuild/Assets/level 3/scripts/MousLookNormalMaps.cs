using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MousLookNormalMaps : MonoBehaviour
{
    public GameObject groep1;
    public GameObject groep2;

    public GameObject image1;
    public GameObject image2;

    public Text handgunmeg;
    public Text famasmeg;

    public Animator schooting;

    public bool bosalive;



    public float time;
    public float impactforce = 30F;
    public float Mousesence = 100f;
    float xRotation = 0f;
    public Transform Player;
    public int Punten;
    public int kills;

    public float magHandGun;
    public float magFamas;

    public WeaponSwitch weaponswitch;

    RaycastHit hit;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      

        bosalive = true;
        magHandGun = 10;
        magFamas = 30;

    }
    void Update()
    {
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            image1.SetActive(true);
            image2.SetActive(false);
            groep1.SetActive(true);
            groep2.SetActive(false);
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            groep1.SetActive(false);
            groep2.SetActive(true);

        }

        handgunmeg.text = magHandGun.ToString();
        famasmeg.text = magFamas.ToString();



        time += Time.deltaTime;




        if (magFamas >= 31)
        {
            magFamas = 30;
        }
        if (magFamas <= 0)
        {
            magFamas = 0;
        }
        if (magHandGun >= 11)
        {
            magHandGun = 10;
        }
        if (magHandGun <= 0)
        {
            magHandGun = 0;
        }

     

        if (Input.GetKey("r"))
        {
            StartCoroutine(Reload());
        }
        float mouseX = Input.GetAxis("Mouse X") * Mousesence * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Mousesence * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -5, 15);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        Vector3 rot = new Vector3(0, mouseX, 0);
        Player.Rotate(rot);
        DoCast();
    }

  
    
    public IEnumerator Reload()
    {
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            yield return new WaitForSeconds(1);
            {
                magHandGun += 10;
            }
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            yield return new WaitForSeconds(4);
            {
                magFamas += 30;
            }
        }



    }
    public void MagazijnMin()
    {
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            if (magHandGun >= 1)
            {
                magHandGun -= 1;
            }
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            if (magFamas >= 1)
            {
                magFamas -= 1;
            }
        }

    }
    //hier gaat hij schieten
    void DoCast()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            MagazijnMin();
            
            if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
            {
                if (magHandGun >= 1)
                {
                DoShoot();
                }
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                if (hit.transform.tag == "Boss")
                {
                    Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.red, 100);
                    if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                    {
                        if (magHandGun >= 1)
                        {
                            schooting.SetInteger("condition", 1);
                            hit.transform.GetComponent<Health>().DoDamage(5);
                            print("boshit1");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }

                    }
                    else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                    {
                        if (magFamas >= 1)
                        {
                            hit.transform.GetComponent<Health>().DoDamage(10);
                            print("boshit2");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }
                }


                if (hit.transform.tag == "Heavy")
                {
                    Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.green, 100);
                    if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                    {
                        if (magHandGun >= 1)
                        {

                            hit.transform.GetComponent<Health>().DoDamage(5);
                            print("heavyhit1");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }
                    else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                    {
                        if (magFamas >= 1)
                        {
                            hit.transform.GetComponent<Health>().DoDamage(10);
                            print("heavyhit2");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }

                }


                if (hit.transform.tag == "Light")
                {
                    Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.blue, 100);

                    if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                    {
                        if (magHandGun >= 1)
                        {
                            schooting.SetInteger("condition", 1);
                            hit.transform.GetComponent<Health>().DoDamage(5);
                            print("lighthit1");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }

                    }
                    else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                    {
                        if (magFamas >= 1)
                        {
                            hit.transform.GetComponent<Health>().DoDamage(10);
                            print("lighthit2");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }
                }



            }

        }



        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {

            if (hit.transform.tag == "DoorLevel1")
            {
                print("kaul1o");
                if (Input.GetButton("e"))
                {
                    print("kaulo");
                    SceneManager.LoadScene(sceneBuildIndex: 3);
                }
            }
            if (hit.transform.tag == "DoorLevel2")
            {
                if (Input.GetButton("e"))
                {
                    SceneManager.LoadScene(sceneBuildIndex: 4);
                }
            }
            if (hit.transform.tag == "DoorLevel3")
            {
                if (Input.GetButton("e"))
                {
                    SceneManager.LoadScene(sceneBuildIndex: 5);
                }
            }


            if (hit.transform.tag == "GodWeapon1")
            {
                if (Input.GetButton("e"))
                {
                    weaponswitch.godWeapon1 = true;
                }
            }
            if (hit.transform.tag == "GodWeapon2")
            {
                if (Input.GetButton("e"))
                {
                    weaponswitch.godWeapon2 = true;
                }
            }

        }
    }
            public void DoShoot()
            {

                schooting.Play("Schoot");
                

            }
    
}

  
